using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStores.Models
{
    public class StoresListModel
    {
        public int store_id { get; set; }

        public string store_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string street { get; set; }

        public string state { get; set; }
        public string zip_code { get; set; }

    }


}