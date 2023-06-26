using E_Commerce.DAL;
using System.Linq;

namespace E_Commerce.BL;

public class ProductManager : IProductManager
{
    private readonly IUnitOfWork unitOfWork;

    public ProductManager(IUnitOfWork _unitOfWork)
    {
        unitOfWork = _unitOfWork;
    }



    public List<ProductReadDto> AllProducts()
    {
        List<Product> productsFromDB = unitOfWork.ProductsRepo.GetAll();
        return productsFromDB.Select(p => new ProductReadDto
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Discount = p.Discount,
            Rate = p.Rate,
        }).ToList();
    }

    public bool Add(ProductAddDto productAdd)
    {
        if (productAdd is null)
        {
            return false;
        }

        Product newProduct = new Product()
        {
            Id = Guid.NewGuid(),
            Name = productAdd.Name,
            Description = productAdd.Description,
            Price = productAdd.Price,
            Discount = productAdd.Discount,
            Rate = productAdd.Rate,


        };

        //Add Images
        newProduct.ProductImages = productAdd.ProductImages.Select(pi => new Product_IMG
        {
            ProductID = newProduct.Id,
            ImageURL = pi.ImageURL,
        }).ToList();

        for (int i = 0; i < newProduct.ProductImages.Count; i++)
        {
            for (int j = 1; j < newProduct.ProductImages.Count ; j++)
            {
                if (newProduct.ProductImages[i].ImageURL == newProduct.ProductImages[j].ImageURL
                    && i != j)
                {
                    return false;
                }
            }
        }

        //Add Info
        newProduct.Product_Color_Size_Quantity = productAdd.ProductInfo.Select(pi => new ProductColorSizeQuantity
        {
            ProductID = newProduct.Id,
            Color = pi.Color,
            Size = pi.Size,
            Quantity = pi.Quantity,
        }).ToList();

        for (int i = 0; i < newProduct.Product_Color_Size_Quantity.Count; i++)
        {
            for (int y = 1; y < newProduct.Product_Color_Size_Quantity.Count; y++)
            {
                if (newProduct.Product_Color_Size_Quantity[i].Color == newProduct.Product_Color_Size_Quantity[y].Color
                    && newProduct.Product_Color_Size_Quantity[i].Size == newProduct.Product_Color_Size_Quantity[y].Size
                    && i != y)
                {
                    return false;
                }
            }
        }
        //Add Category

        unitOfWork.ProductsRepo.Add(newProduct);

        return unitOfWork.SaveChange() > 0;
    }
}
