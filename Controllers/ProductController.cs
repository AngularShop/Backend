using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _service;

    public ProductController(ILogger<ProductController> logger, IProductService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(){
        return await _service.GetAllProducts();
    }


    [HttpGet("{ProductId}")]
    public async Task<ActionResult<Product>> GetProduct(int ProductId){
        var Product = await _service.GetProductById(ProductId);
        if (Product == null){
            return NotFound();
        }
        return Ok(Product);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(ProductDTO ProductInput){

        Product Product = await _service.AddProduct(ProductInput);

        return new ObjectResult(Product) {StatusCode=200};
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(Product Product){
        Product updatedProduct = await _service.UpdateProduct(Product);

        return new ObjectResult(updatedProduct) {StatusCode=200};
    }

    

}