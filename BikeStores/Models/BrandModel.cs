using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Models
{
    public class BrandModel
    {
        public string Product { get; set; }
        //public int  Quantity { get; set; }
    }

    public class BrandsViewModel
    {
        public string BrandName { get; set; }
        public List<BrandModel> BrandList { get; set; }
        public List<string> AllBrandsList { get; set; }
    }

}