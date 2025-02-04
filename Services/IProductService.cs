using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services;

public interface IProductService {
    public Task<ActionResult<IEnumerable<Product>>> GetAllProducts();
    public Task<Product?> GetProductById(int productId);

    public Task<Product> AddProduct(ProductDTO product);

    public Task<Product> UpdateProduct(Product product);
}