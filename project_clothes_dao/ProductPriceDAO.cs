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
        public ProductPrice getProductPrice(Guid product_id)
        {
            string query = $"select * from TBL_product_price where product_id = '{product_id}'";
            DataTable dt = dh.getDataTable(query);
            ProductPrice pro = new ProductPrice();
            foreach (DataRow row in dt.Rows)
            {
                pro.product_price_id = Guid.Parse(row[0].ToString());
                pro.product_id = Guid.Parse(row[1].ToString());
                pro.price_current = decimal.Parse(row[2].ToString());
                pro.date_effect = DateTime.Parse(row[3].ToString());
                if (row[4].ToString() != "") pro.date_expired = DateTime.Parse(row[4].ToString());
                pro.date_expired = null;
            }
            return pro;
        }

    }
}
