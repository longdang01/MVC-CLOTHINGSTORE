using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class ProductPriceDAO : IProductPriceDAO
    {
        public DataHelper dh = new DataHelper();
        public ProductPrice GetProductPrice(string product_id)
        {
            string query = $"select * from TBL_product_price where product_id = '{product_id}'";
            DataTable dt = dh.getDataTable(query);
            ProductPrice pro = new ProductPrice();
            foreach (DataRow row in dt.Rows)
            {
                pro.product_price_id = row[0].ToString();
                pro.product_id = row[1].ToString();
                pro.price_current = decimal.Parse(row[2].ToString());
                pro.date_effect = row[3].ToString();
                pro.date_expired = row[4].ToString();
            }
            return pro;
        }

    }
}
