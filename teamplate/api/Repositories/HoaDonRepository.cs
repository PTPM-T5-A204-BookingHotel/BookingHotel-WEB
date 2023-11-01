using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class HoaDonRepository : BaseRepository<HoaDon>
    {
        private readonly QlkhachSanContext _dataContext;
        public HoaDonRepository(QlkhachSanContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Task UpdateHD(HoaDon updatedHoaDon)
        {
            var existingHoaDon = _dataContext.HoaDons.FirstOrDefault(h => h.MaHd == updatedHoaDon.MaHd);

            if (existingHoaDon != null)
            {
                _dataContext.Entry(existingHoaDon).CurrentValues.SetValues(updatedHoaDon);
                _dataContext.SaveChanges();
            }
            return Task.CompletedTask;
        }
        public async Task<HoaDon> GetIdHoaDon(string? id)
        {
            try
            {
                var allid = await _dataContext.Set<HoaDon>().FindAsync(id);
                return allid;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public async Task DeleteHoaDon(string id)
        {
            try
            {
                var allid = await _dataContext.Set<HoaDon>().FindAsync(id);
                if (allid != null)
                {
                    _dataContext.Set<HoaDon>().Remove(allid);
                    await _dataContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
    }
}
