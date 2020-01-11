using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication.Controllers
{
    public class PizzasController : ApiController
    {
        //GET api/<controller>
        public IEnumerable<Pizza> Get()
        {
            //Pizza pizza = new Pizza();
            //return pizza.Read();
            return null;
        }

        //GET api/<controller>/5
        public IEnumerable<Pizza> Get(int kosher)
        {
            return null;
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

        [HttpGet]
        [Route("api/pizzas/{kosher}")]
        public IEnumerable<Pizza> Get(string kosher)
        {
            Pizza pizza = new Pizza();
            return pizza.Read(kosher);
        }

    }
}