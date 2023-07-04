﻿namespace E_Commerce.BL;

public interface ICategoriesManager
{


    bool AddCategory(CategoryAddDto addCategoryDto);
    bool UpdateCategory(CategoryUpdateDto updateCategoryDto);
    CategoryUpdateDto? CategoryToUpdate(Guid CategoryId);
    bool DeleteCategory(Guid CategoryId);
    List<CategoryReadDto> GetAllCategories();
    List<CategoryReadDto> GetAllCategoriesUnique();
    CategoryReadDto? GetCategoryById(Guid CategoryId);

    List<SubCategoryReadDto>? GetSubCategories(Guid parentCategoryId);
    List<CategoryReadDto> GetParentCategory ();








}
