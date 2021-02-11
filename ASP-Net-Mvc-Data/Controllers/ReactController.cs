using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Net_Mvc_Data.Models;
using ASP_Net_Mvc_Data.Models.Services;
using ASP_Net_Mvc_Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Net_Mvc_Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IPeopleService _peopleService;
        private readonly ICountryService _countryService;

        public ReactController(ICityService cityService, IPeopleService peopleService, ICountryService countryService)
        {
            _cityService = cityService;
            _peopleService = peopleService;
            _countryService = countryService;
        }

        // GET: api/<ReactController>
        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            var result = _peopleService.All();

            return result.PersonList;
        }

        // GET: api/<ReactController>
        [HttpGet("cities")]
        public IEnumerable<City> GetCities()
        {
            var result = _cityService.All();

            return result;
        }

        // GET: api/<ReactController>
        [HttpGet("countries")]
        public IEnumerable<Country> GetCountries()
        {
            var result = _countryService.All();

            return result;
        }

        // GET api/<ReactController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                Response.StatusCode = 404;
            }

            //this will prevent the JSOn converter to get stuck in a infinit loop. (foreach)

            return person;
        }

        // POST api/<ReactController>
        [HttpPost]
        public IActionResult Post(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                Person person = _peopleService.Add(createPersonViewModel);
                return Created("URI to person omitted", person);
            }

            return BadRequest(createPersonViewModel);
        }

        // PUT api/<ReactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                Person personToEdit = new Person();

                personToEdit.Name = createPersonViewModel.Name;
                personToEdit.PhoneNumber = createPersonViewModel.PhoneNumber;

                Person person = _peopleService.Edit(id, personToEdit);

                if (person == null)
                {
                    return Problem("Unable to save changes.", null, 500);
                }
                return Ok(person);
            }

            return BadRequest(createPersonViewModel);
        }

        // DELETE api/<ReactController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
