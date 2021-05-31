# Problem Statement: Promotion Engine

Implement a simple promotion engine for a checkout process. Our Cart contains a list of single character SKU ids (A, B, C.	) over which the promotion engine will need to run.

The promotion engine will need to calculate the total order value after applying the 2 promotion types:|
 - 	buy 'n' items of a SKU for a fixed price (3 A's for 130)
 - 	buy SKU 1 & SKU 2 for a fixed price ( C + D = 30 )

The promotion engine should be modular to allow for more promotion types to be added at a later date (e.g. a future promotion could be x% of a SKU unit price). For this coding exercise you can assume that the promotions will be mutually exclusive; in other words if one is applied the other promotions will not apply

## Test Setup

Unit price for SKU IDs A	50\
B	30\
C	20\
D	15

Active Promotions:\
3 of A's for 130\
2 of B's for 45 C & D for 30

Scenario A\
1	* A	50\
1	* B	30\
1	* C	20

Total	100

Scenario	B	\
5 * A		130 + 2*50\
5 * B		45 + 45 + 30\
1 * C		28

Total	370

Scenario C\
3	* A	130\
5	* B	45 + 45 + 1 * 30\
1	* C	-\
1	* D	30

Total	280

## Notes

•	The promotion rules are mutually exclusive, that implies only one promotion (individual SKU or combined) is applicable to a particular SKU. Rest depends on the imagination of the programmer for which scenarios they want to consider, for example (case 1 => 2A = 30 and A=A40%) or (case 2 => either 2A = 30 or A=A40%)


# Solution: PromotionEngine

.Net Core 5.0 application, implemented in C#, using Visual Studio 2019.

## Projects

### PromotionEngine

This .net core library contains the business logic, separated into 3 main parts:
 - PromotionRules
 - Cart
 - Store

#### PromotionRules

Supports to implement multiple different PromotionRules. Currently only 2 types are implemented:
 - `CombinedItemFixedPricePromotion`
 - `NitemForFixedPricePromotion`

The `PromotionRuleExtensions` provides functionality to parse a promotion from its text representation to a `PromotionRule` inherited C# object.

#### Cart

A `Cart` is used to store the list of `SKUItem`s and to maintain the `TotalPrice` of the items in the cart. It provides functionality to `AddItem` or `RemoveItem` from the `Cart`.

A `Cart` item wraps an `SKUitem` that was added to the `Cart` and tracks if a promotion was applied to it, and the `FinalPrice` which might differ from its unit price if a promotion was applied to it.

#### Store

The`Store` implements all the core functionalities defined in the `IStore` interface for `SKUitem`, `Cart` and `PromotionRule` CRUD operations.

### PromotionEngineTests

Contains several test classes and test methods, including unit tests and scenario tests.

### PromotionEngineWebApp

Asp.Net Core Web application that uses the IStore functionalities to expose the Store, Cart and Promotion related operations as a REST API.\
It also generates an Open API 3.1 specification and Swagger UI for easier testing.

3 main controllers defined:
 - `PromotionsController`
 - `SKUitemController`
 - `StoreController`

Data is mapped to DTO type from the types defined in the `PromotionEngine` project, wher applicable.
These DTO objects are exposed in the OpenApi schema.

## Notes, considerations

1. The core functionality is implemented in the `PromotionEngine` project, the `PromotionEngineWebApp` project is added only for easier testing and demo.
2. The `PromotionEngine` is tested via code tests from `PromotionEngineTests` project, but the test coverage could be further improved.
3. Currently the extension of the available `PromotionRule` types could be added only by adding further implementations. A future imrovement could be to use a Dependency Injection framework (e.g Autofac) that could pick up .dll files that contain an implementation of `PromotionRule` and inject the to the list of promotionrules.
4. The `PromotionEngineWebApp` does not contain code test. For simplicity, the web method's response is `HTTP 400 BadRequest` in every case when an Exception occurs, otherwise `HTTP 200 Ok`. 
