using cSharpAPIDemo.Data;
using cSharpAPIDemo.Models;
using cSharpAPIDemo.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace cSharpAPIDemo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CategoryExists(string CategoryName)
        {
            bool flag = _db.Categories.Any(c => c.Name.ToLower().Trim() == CategoryName.ToLower().Trim());
            return flag;
        }

        public bool CategoryExists(int CategoryId)
        {
            return _db.Categories.Any(c => c.id == CategoryId);
        }

        public bool CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            return save();
        }

        public bool DeleteCategory(Category category)
        {
            _db.Categories.Remove(category);
            return save();
        }

        public ICollection<Category> GetCategories()
        {
            return _db.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _db.Categories.FirstOrDefault(c => c.id == CategoryId);
        }

        public bool save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _db.Update(category);
            return save();
        }
    }
}
