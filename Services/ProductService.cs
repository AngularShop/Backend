using System.Collections;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ProductService : IProductService {

    private readonly ILogger<ProductService> _logger;

    private readonly ProductContext _context;

    public ProductService(ILogger<ProductService> logger, ProductContext context)
{
    _logger = logger;
    _context = context;
    _logger.LogInformation("ProductService instantiated.");
}

    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts(){
        var products = await _context.Products.ToListAsync();
        return products;   
    }

    public async Task<Product?> GetProductById(int productId){
        var product = await _context.Products.FindAsync(productId);
        return product;
    }

    public async Task<Product> AddProduct(ProductDTO productDTO){
        Product product = new Product();
        product.Name = productDTO.Name;
        product.CategoryId = productDTO.CategoryId;
        product.Description = productDTO.Description;
        product.ImgUrl = productDTO.ImgUrl;
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();

        return product;
    }

    private async Task<bool> ProductExists(int productId){
        return await _context.Products.AnyAsync(p => p.Id == productId);
    }

    public  async Task<Product> UpdateProduct(Product updatedProduct)
    {
        var product = await _context.Products.SingleAsync(p => p.Id == updatedProduct.Id);
        product.Name = updatedProduct.Name;
        product.Description = updatedProduct.Description;
        product.ImgUrl = updatedProduct.ImgUrl;
        product.CategoryId = updatedProduct.CategoryId;
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}