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
        //Gets the products
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

        public ActionResult ProductsByBrand()
        {
            List<BrandModel> ProductsList = new List<BrandModel>();
            using (IDbConnection db = new SqlConnection("Server=localhost;" + "Database=DemoDB;" + "Integrated Security=True;"))
            {
                string query = @"select brand_name as Brand, product_name as Product, store_name as Store, quantity as Quantity
                                    from production.stocks stocks_tbl

                                        join (select product_id, product_name, brand_name from production.products p join(select brand_id, brand_name from production.brands where brand_name in ('Electra', 'Haro', 'Heller')) b on p.brand_id = b.brand_id)  products_tbl
                                            on stocks_tbl.product_id = products_tbl.product_id

                                        join sales.stores stores_tbl on stocks_tbl.store_id = stores_tbl.store_id
                                    where quantity > 0
                                    order by brand_name; ";
                ProductsList = db.Query<BrandModel>(query, commandType: CommandType.Text).ToList();

            }
            return View(ProductsList);
        }
    }
}