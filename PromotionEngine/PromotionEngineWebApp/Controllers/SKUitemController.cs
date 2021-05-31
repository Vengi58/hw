using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Items;
using PromotionEngine.Store;
using PromotionEngineWebApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromotionEngineWebApp.Controllers
{
    [Route("api/SKUitems")]
    [ApiController]
    public class SKUitemController : ControllerBase
    {
        private readonly IStore Store;

        public SKUitemController(IStore store)
        {
            Store = store;
        }

        // GET: api/<SKUitemController>
        [HttpGet]
        public ActionResult<IEnumerable<SKUitem>> GetAllSKUitems()
        {
            return Store.GetSKUitems();
        }

        // GET api/<SKUitemController>/5
        [HttpGet("{id}")]
        public ActionResult<SKUitem> GetSKUitem(string id)
        {
            return Store.GetSKUitems().FirstOrDefault(i => id.Equals(i.ID));
        }

        // POST api/<SKUitemController>
        [HttpPost]
        public void PostSKUitem(SKUitemDTO item)
        {
            Store.AddSKUitem(new SKUitem(item.ID, item.UnitPrice));
        }

        // PUT api/<SKUitemController>/5
        [HttpPut("{skuID}")]
        public void Put(string skuID, float unitPrice)
        {
            Store.UpdateSKUitemUnitPrice(skuID, unitPrice);
        }

        // DELETE api/<SKUitemController>/5
        [HttpDelete("{skuID}")]
        public void DeleteSKU(string skuID)
        {
            Store.DeleteSKUitem(skuID);
        }
    }
}
