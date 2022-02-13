using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Models
{
    public class ProductsModel
    {
        public string Product { get; set; }
        public Int16 Year { get; set; }
        public decimal Price { get; set; }

        public string Availability { get; set; }
    }
}