using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _service;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories(){
        return await _service.GetAllCategories();
    }


    [HttpGet("{categoryId}")]
    public async Task<ActionResult<Category>> GetCategory(int categoryId){
        var category = await _service.GetCategoryById(categoryId);
        if (category == null){
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> AddCategory(CategoryDTO categoryInput){

        Category category = await _service.AddCategory(categoryInput);

        return new ObjectResult(category) {StatusCode=200};
    }

    [HttpPut]
    public async Task<ActionResult<Category>> UpdateCategory(Category category){
        Category updatedCategory = await _service.UpdateCategory(category);

        return new ObjectResult(updatedCategory) {StatusCode=200};
    }

    

}