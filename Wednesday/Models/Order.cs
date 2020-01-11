using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Order
    {
        private int id;
        private string phonenumber;
        private bool selfPickup;
        private string address;
        private string name;
        private int pizzaId;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public bool SelfPickup { get => selfPickup; set => selfPickup = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public int PizzaId { get => pizzaId; set => pizzaId = value; }


        public Order(string _name, string _address, bool _selfPickup, string _phonenumber, int _pizzaId)
        {
            Name = _name;
            Address = _address;
            SelfPickup = _selfPickup;
            Phonenumber = _phonenumber;
            PizzaId = _pizzaId;
        }

        public Order()
        {
        }

        public int insert()
        {
            //insert your code here
            return -1;
        }

        public List<Order> Read()
        {

            //insert your code here
            return null;

        }

    }
}