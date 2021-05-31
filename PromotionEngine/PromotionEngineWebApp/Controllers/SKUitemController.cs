using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Items;
using PromotionEngine.Store;
using PromotionEngineWebApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using PromotionEngineWebApp.DTO;

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
        public ActionResult<IEnumerable<SKUitemDTO>> GetAllSKUitems()
        {
            try
            {
                return Ok(Store.GetSKUitems().Select(s => s.ToDTO()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<SKUitemController>/5
        [HttpGet("{id}")]
        public ActionResult<SKUitemDTO> GetSKUitem(string id)
        {
            try
            {
                return Ok(Store.GetSKUitems().FirstOrDefault(i => id.Equals(i.ID)).ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<SKUitemController>
        [HttpPost]
        public ActionResult<SKUitemDTO> PostSKUitem(SKUitemDTO item)
        {
            try
            {
                var itemDao = item.ToDAO();

                Store.AddSKUitem(itemDao);

                return CreatedAtAction(
                    nameof(GetSKUitem),
                    new { id = item.ID },
                    itemDao.ToDTO());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<SKUitemController>/5
        [HttpPut("{skuID}")]
        public ActionResult<SKUitemDTO> Put(string skuID, float unitPrice)
        {
            try
            {
                Store.UpdateSKUitemUnitPrice(skuID, unitPrice);

                return CreatedAtAction(
                    nameof(GetSKUitem),
                    new { id = skuID },
                    new SKUitem(skuID, unitPrice).ToDTO());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<SKUitemController>/5
        [HttpDelete("{skuID}")]
        public ActionResult<string> DeleteSKU(string skuID)
        {
            try
            {
                Store.DeleteSKUitem(skuID);
                return Ok(skuID);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
