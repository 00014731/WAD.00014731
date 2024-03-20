using WAD._00014731.Models;

namespace WAD._00014731.Interfaces
{
    public interface IActivityRepository
    { 
        Task<IEnumerable<Activity>> GetAllAsync();
        Task<Activity> GetByIdAsync(int id);
        Task CreateAsync(Activity entity);
        Task UpdateAsync(Activity entity);
        Task DeleteAsync(int id);
    }
}
