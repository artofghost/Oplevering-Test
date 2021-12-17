using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Interface;

namespace Factory
{
    public class CategoryFactory
    {
        public static ICategoryCollection GetCategoryDal()
        {
            return new CategoryDal();
        }
        public static ICategory GetUpdateNoteDal()
        {
            return new CategoryDal();
        }
    }
}
