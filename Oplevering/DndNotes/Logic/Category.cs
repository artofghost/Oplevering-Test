using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;


namespace Logic
{
    public class Category
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Icon { get; set; }
        public string Colour { get; set; }
        public Category(CategoryDto categoryDto)
        {
            Name = categoryDto.Name;
            Id = categoryDto.Id;
            Icon = categoryDto.Icon;
            Colour = categoryDto.Colour;
        }
        public Category() { }
        public void UpdateCategory()
        {
            CategoryDto categoryDto = new CategoryDto();
            categoryDto.Name = Name;
            categoryDto.Id = Id;
            categoryDto.Icon = Icon;
            categoryDto.Colour = Colour;

            ICategory category = CategoryFactory.GetUpdateNoteDal();
            category.UpdateCategory(categoryDto);
        }
    }
}
