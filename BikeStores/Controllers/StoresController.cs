using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeStores.Models;
using Dapper;

namespace BikeStores.Controllers
{
    public class StoresController : Controller
    {
        // GET: Stores
        public ActionResult GetStores()
        {
            List<StoresListModel> StoresList = new List<StoresListModel>();
            using (IDbConnection db = new SqlConnection("Server=localhost;" + "Database=DemoDB;" + "Integrated Security=True;"))
            {
                StoresList = db.Query<StoresListModel>("dbo.StoresList", commandType: CommandType.Text).ToList();
            }
            return View(StoresList);
        }

        public ActionResult GetProducts()
        {
            List<ProductsModel> ProductsList = new List<ProductsModel>();
            using (IDbConnection db = new SqlConnection("Server=localhost;" + "Database=DemoDB;" + "Integrated Security=True;"))
            {
                /*string queryStr = "SELECT product_name as Product, model_year as Year, list_price as Price, " +
                    "case when product_id in (select DISTINCT product_id from production.stocks) then 'In Stock' else 'Out of Stock' end as Availability " +
                    "from production.products order by Product";
                */
                ProductsList = db.Query<ProductsModel>("dbo.GetProducts", commandType: CommandType.Text).ToList();
            }
            return View(ProductsList);
        }
    }
}