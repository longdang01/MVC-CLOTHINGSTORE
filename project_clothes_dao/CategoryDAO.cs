using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_dao
{
    public class CategoryDAO : ICategoryDAO
    {
        DataHelper dh = new DataHelper();
        public List<Category> GetCategoryList()
        {
            string query = "select * from TBL_category";
            DataTable dt = dh.getDataTable(query);

            return ToList(dt);
        }
        public List<Category> ToList(DataTable dt)
        {
            List<Category> l = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                Category p = new Category(Guid.Parse(dr[0].ToString()), dr[1].ToString());
                l.Add(p);
            }
            return l;
        }

    }
}
