using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services;

public interface ICategoryService {
    public Task<ActionResult<IEnumerable<Category>>> GetAllCategories();
    public Task<Category?> GetCategoryById(int categoryId);

    public Task<Category> AddCategory(CategoryDTO categoryDTO);

    public Task<Category> UpdateCategory(Category category);
}