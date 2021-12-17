using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;
using Factory;

namespace Logic
{
    public class CategoryCollection
    {
        public List<Category> categories = new List<Category>();
        private ICategoryCollection iCategory;
           


        public CategoryCollection()
        {
            iCategory = CategoryFactory.GetCategoryDal();
            foreach (var categoryDto in iCategory.GetAllCategorys())
            {
                categories.Add(new Category(categoryDto));
            }
        }
      

    }
}
