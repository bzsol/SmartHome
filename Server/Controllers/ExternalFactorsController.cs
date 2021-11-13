using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    // You can manage more than one API-s in one server
    [ApiController]
    [Route("api/extfacts")]
    public class ExternalFactorsController : Controller
    {
        // GET method to gather the existing data about the temperature
        [HttpGet]
        public ActionResult<IEnumerable<ExternalFactors>> Get()
        {
            return Ok(ExternalFactorsRepo.GetExternalFactors());
        }

        // POST method to save the temperature to the JSON file
        [HttpPost]
        public ActionResult Post([FromBody] ExternalFactors factor)
        {
            List<ExternalFactors> factors = ExternalFactorsRepo.GetExternalFactors().ToList();
            factor.ID = factors.Count < 1 ? 1 : factors.OrderByDescending(e => e.ID).FirstOrDefault().ID + 1;
            factors.Add(factor);
            ExternalFactorsRepo.SaveExternalFactors(factors);
            return Ok();
        }

        //UPDATE
        [HttpPut]
        public ActionResult Put([FromBody] ExternalFactors factor) {

            List<ExternalFactors> factors = ExternalFactorsRepo.GetExternalFactors().ToList();
            ExternalFactors chosenFactor = factors.FirstOrDefault(x => x.ID.Equals(factor.ID));
            if (chosenFactor == null)
            {
                return NotFound();
            }
            else 
            {
                //chosenFactor = factor;
                chosenFactor.Radio = factor.Radio;
                chosenFactor.TV = factor.TV;
                chosenFactor.entryClimate = factor.entryClimate;
                chosenFactor.bathClimate = factor.bathClimate;
                chosenFactor.kitchenClimate = factor.kitchenClimate;
                chosenFactor.livingroomClimate = factor.livingroomClimate;
                chosenFactor.officeClimate = factor.officeClimate;
                chosenFactor.roomno1Climate = factor.roomno1Climate;
                chosenFactor.roomno2Climate = factor.roomno2Climate;
                chosenFactor.roomno3Climate = factor.roomno3Climate;
                chosenFactor.terraceClimate = factor.terraceClimate;
                chosenFactor.Heating = factor.Heating;
                chosenFactor.Cooling = factor.Cooling;
                chosenFactor.isCO2sample = factor.isCO2sample;
                chosenFactor.isHumiditysample = factor.isHumiditysample;
                ExternalFactorsRepo.SaveExternalFactors(factors);
                return Ok();
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var factors = ExternalFactorsRepo.GetExternalFactors().ToList();
            var ChosenFactor = factors.FirstOrDefault(e => e.ID.Equals(id));
            if (ChosenFactor.Equals(null))
            {
                return NotFound();
            }
            else
            {
                factors.Remove(ChosenFactor);
                ExternalFactorsRepo.SaveExternalFactors(factors);
                return Ok();
            }

        }
    }
}
