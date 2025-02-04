using System.Collections;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class CategoryService : ICategoryService {

    private readonly ILogger<CategoryService> _logger;

    private readonly ProductContext _context;

    public CategoryService(ILogger<CategoryService> logger, ProductContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories(){
        var categories = await _context.Categories.ToListAsync();
        return categories;   
    }

    public async Task<Category?> GetCategoryById(int categoryId){
        var category = await _context.Categories.FindAsync(categoryId);
        return category;
    }

    public async Task<Category> AddCategory(CategoryDTO categoryDTO){
        Category category = new Category();
        category.Title = categoryDTO.Title;
        category.ParentId = null;
        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();

        return category;
    }

    private async Task<bool> CategoryExists(int categoryId){
        return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId);
    }

    public  async Task<Category> UpdateCategory(Category updatedCategory)
    {
        var category = await _context.Categories.SingleAsync(c => c.CategoryId == updatedCategory.CategoryId);
        category.ParentId = updatedCategory.ParentId;
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
        return category;
    }
}