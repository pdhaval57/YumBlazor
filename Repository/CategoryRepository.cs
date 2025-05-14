using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Data.Models;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.Category.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await GetAsync(id);
            if (obj == null) return false;
            _db.Category.Remove(obj);            
            return (await _db.SaveChangesAsync() > 0);
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj =  await _db.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (obj == null) return new Category();
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var category = await GetAsync(obj.Id);
            if (category == null) return new Category();
            category.Name = obj.Name;
            await _db.SaveChangesAsync();
            return obj;
        }
    } 
}
