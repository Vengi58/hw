using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Store;
using PromotionEngineWebApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromotionEngineWebApp.Controllers
{
    [Route("api/Store")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStore Store;

        public StoreController(IStore store)
        {
            Store = store;
        }

        // GET: api/<StoreController>
        [HttpGet("items")]
        public ActionResult<IEnumerable<SKUitemDTO>> GetAllItems()
        {
            try
            {
                return Ok(Store.GetAllItems().Select(i => i.ToDTO()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<StoreController>/5
        [HttpGet("items/{sku}")]
        public ActionResult<SKUitemDTO> GetItem(string sku)
        {
            try
            {
                return Ok(Store.GetItem(sku).ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("cart")]
        public ActionResult<CartDTO> GetCart()
        {
            try
            {
                return Ok(Store.GetCart().ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("cart/{sku}")]
        public ActionResult<SKUitemDTO> AddItemToCart(string sku)
        {
            try
            {
                Store.AddItemToCart(sku);
                return Ok(Store.GetItem(sku).ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("cart/{sku}")]
        public ActionResult<SKUitemDTO> DeleteItemFromCart(string sku)
        {
            try
            {
                Store.AddItemToCart(sku);

                return Ok(Store.GetItem(sku).ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("cart/total")]
        public ActionResult<float> GetCartTotal()
        {
            try
            {
                return Ok(Store.GetCartTotal());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // GET api/<StoreController>/5
        [HttpGet("cart/checkout")]
        public ActionResult<float> Checkout()
        {
            try
            {
                Store.Checkout();
                return Ok(Store.GetCartTotal());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
