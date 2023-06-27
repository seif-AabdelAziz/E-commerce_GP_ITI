using E_Commerce.BL.Dto.Category;
using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public interface ICategoriesManager
{


    void AddCategory(CategoryAddDto addCategoryDto);
    void EditCategory(CategoryEditDto updateCategoryDto);
    bool DeleteCategory(CategoryDeleteDto deleteCategoryDto);
    CategoryReadDto? GetCategoryById(Guid CategoryId);
    CategoryReadDto? GetProductsForCategory(Guid categorytId);











    //CategoryReadDto? GetParentCategory(Guid subCategoryId);
    //List<Category>? GetSubCategories(Guid parentCategoryId);
    //Category? GetProductsForCategory(Guid productId);

}
