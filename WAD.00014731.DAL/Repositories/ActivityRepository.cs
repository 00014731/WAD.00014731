using Microsoft.EntityFrameworkCore;
using WAD._00014731.Data;
using WAD._00014731.Interfaces;
using WAD._00014731.Models;

namespace WAD._00014731.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDBContext _context;

        public ActivityRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity> GetByIdAsync(int id)
        {
            return await _context.Activities
                                 .Where(a => a.Id == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Activity entity)
        {
            _context.Activities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Activity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
