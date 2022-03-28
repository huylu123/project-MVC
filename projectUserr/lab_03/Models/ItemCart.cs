using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab_03.Models
{
    public class ItemCart
    {
        public movie movie { get; set; }
        public int Quantity { get; set; }
        public float LineTotal { get; set; }
        public float OrderTotal { get; set; }
    }
    public class Cart
    {
        List<ItemCart> items = new List<ItemCart>();
        public IEnumerable<ItemCart> Items
        {
            get { return items; }
        }
    }
}