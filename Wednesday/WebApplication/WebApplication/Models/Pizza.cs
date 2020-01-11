using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models.DAL;

namespace WebApplication4.Models
{
    public class Pizza
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public List<Pizza> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.getAllPizzas();

        }

    }
}

