using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface ICategoryCollection
    {
        public List<CategoryDto> GetAllCategorys();
        public CategoryDto GetCategory(int Id);
        public void CreateCategory(CategoryDto category, int UserId);
        public void DeleteCategory(CategoryDto categoryDto);


    }
}
