using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Pizza
    {
        private int id;
        private string name;
        private bool kosher;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool Kosher { get => kosher; set => kosher = value; }


        public List<Pizza> Read()
        {
            //insert your code here
            return null;

        }

    }
}

