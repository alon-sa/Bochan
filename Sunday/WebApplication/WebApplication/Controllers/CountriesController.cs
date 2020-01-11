using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace ServerAssignment3.Controllers
{
    public class CountriesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Country> Get()
        {
            Country country = new Country();
            return country.getAll();
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/countries/{name}")]
        public Country Get(string name)
        {
            Country country = new Country();
            return country.getCountryByName(name);
        }

        [HttpGet]
        [Route("api/countries/continent/{name}")]
        public List<Country> getByContinent(string name)
        {
            Country country = new Country();
            return country.getByContinent(name);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


        [HttpPut]
        [Route("api/countries/update")]
        public void update([FromBody]Country country)
        {
            country.update(country);
        }
    }
}