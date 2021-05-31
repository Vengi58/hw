using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PromotionEngineWebApp.Controllers
{
    [Route("api/Promotions")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly IStore Store;

        public PromotionsController(IStore store)
        {
            Store = store;
        }

        // GET: api/<PromotionsController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAllPromotions()
        {
            try
            {
                var promotions = Store.GetPromotions();
                return promotions == null || promotions.Count() == 0 ? 
                    Ok(new List<string>()) :
                    Ok(promotions.Select(p => p.ToString()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<PromotionsController>
        [HttpPost("{promotion}")]
        public ActionResult<string> PostPromotion(string promotion)
        {
            try
            {
                Store.AddPromotion(promotion);

                return CreatedAtAction(
                    nameof(GetAllPromotions),
                    new { id = promotion },
                    promotion);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<PromotionsController>/5
        [HttpDelete("{promotion}")]
        public ActionResult<string> Delete(string promotion)
        {
            try
            {
                Store.DeletePromotion(promotion);
                return Ok(promotion);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
