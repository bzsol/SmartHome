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
    [Route("api/temp")]
    public class TempController : Controller
    {
        // GET method to gather the existing data about the temperature
        [HttpGet]
        public ActionResult<IEnumerable<Temperature>> Get()
        {
            return Ok(TempRepo.GetTemperatures());
        }

        // POST method to save the temperature to the JSON file
        [HttpPost]
        public ActionResult Post([FromBody] Temperature temperature)
        {
            List<Temperature> temps = TempRepo.GetTemperatures().ToList();
            temperature.ID = temps.Count < 1 ? 1 : temps.OrderByDescending(e => e.ID).FirstOrDefault().ID + 1;
            temps.Add(temperature);
            TempRepo.SaveTemperature(temps);
            return Ok();
        }

        //UPDATE
        [HttpPut]
        public ActionResult Put([FromBody] Temperature temperature) {

            List<Temperature> temperatures = TempRepo.GetTemperatures().ToList();
            Temperature chosenTemperature = temperatures.FirstOrDefault(x => x.ID.Equals(temperature.ID));
            if (chosenTemperature == null)
            {
                return NotFound();
            }
            else {

                chosenTemperature.Temp = temperature.Temp;
                chosenTemperature.Humidity = temperature.Humidity;
                TempRepo.SaveTemperature(temperatures);
                return Ok();
            }
        }

        //DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var temperatures = TempRepo.GetTemperatures().ToList();
            var ChosenTemperature = temperatures.FirstOrDefault(e => e.ID.Equals(id));
            if (ChosenTemperature.Equals(null))
            {
                return NotFound();
            }
            else
            {
                temperatures.Remove(ChosenTemperature);
                TempRepo.SaveTemperature(temperatures);
                return Ok();
            }

        }
    }
}
