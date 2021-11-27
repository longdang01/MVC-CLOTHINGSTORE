using project_clothes_dao;
using project_clothes_object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_clothes_bus
{
    public class CategoryBUS : ICategoryBUS
    {
        public ICategoryDAO categoryDAO = new CategoryDAO(); 
        public List<Category> GetCategoryList()
        {
            return categoryDAO.GetCategoryList();
        }
        //public string getCategoryName(Guid category_id)
        //{
        //    return categoryDAO.getCategoryName(category_id);
        //}
    }
}
