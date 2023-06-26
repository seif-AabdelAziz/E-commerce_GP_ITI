﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BL;

public class CategoryAddDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Parent Category is required")]
    public Guid? ParentCategoryId { get; set; }

}
