using E_Commerce.BL.Dto.Category;
using E_Commerce.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public class CategoriesManager : ICategoriesManager
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriesManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    #region Add Category

    public void AddCategory(CategoryAddDto addCategoryDto)
    {

        Category? newCategory = new Category
        {
            Id = Guid.NewGuid(),
            Name = addCategoryDto.Name,
            Description = addCategoryDto.Description,
            ParentCategoryId = addCategoryDto.ParentCategoryId,

        };

        _unitOfWork.CategoriesRepo.Add(newCategory);
        _unitOfWork.SaveChange();

    }

    #endregion

    #region Delete Category

    public bool DeleteCategory(CategoryDeleteDto deleteCategoryDto)
    {
        Category? categoryFromDb = _unitOfWork.CategoriesRepo.GetById(deleteCategoryDto.CategoryId);

        if (categoryFromDb != null)
        {
            _unitOfWork.CategoriesRepo.Delete(categoryFromDb);
        }
        int numberOfAffectedRows = _unitOfWork.SaveChange();
        return numberOfAffectedRows > 0;

    }
    #endregion

    #region Edit Category


    public void EditCategory(CategoryEditDto updateCategoryDto)
    {
        Category? category = _unitOfWork.CategoriesRepo.GetById(updateCategoryDto.CategoryId);
        if (category != null)
        {

            category.Name = updateCategoryDto.Name;
            category.Description = updateCategoryDto.Description;
            category.ParentCategoryId = updateCategoryDto.ParentCategoryId;

        }
        _unitOfWork.CategoriesRepo.Update(category);
        _unitOfWork.SaveChange();

    }
    #endregion

    #region Get Category By Id

    public CategoryReadDto? GetCategoryById(Guid CategoryId)
    {

        Category? categoryFromDb = _unitOfWork.CategoriesRepo.GetById(CategoryId);

        if (categoryFromDb is null)
        {
            return null;
        }
        return new CategoryReadDto
        {
            Id = categoryFromDb.Id,
            Name = categoryFromDb.Name,
            Description = categoryFromDb.Description,
            ParentCategoryId = categoryFromDb.ParentCategoryId,

        };

    }


    #endregion

    #region Get Products for one Category

    public CategoryReadDto? GetProductsForCategory(Guid categorytId)
    {

        Category? categoryFromDb = _unitOfWork.CategoriesRepo.GetProductsForCategory(categorytId);


        if (categoryFromDb is null)
        {
            return null;
        }
        return new CategoryReadDto
        {

            products =categoryFromDb.Products.ToList(),

        };
    }

    #endregion





}
