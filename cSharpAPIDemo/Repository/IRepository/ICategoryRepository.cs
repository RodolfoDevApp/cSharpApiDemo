using cSharpAPIDemo.Models;
using System.Collections.Generic;

namespace cSharpAPIDemo.Repository.IRepository
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int CategoryId);
        bool CategoryExists(string CategoryName);
        bool CategoryExists(int CategoryId);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool save();
    }
}
