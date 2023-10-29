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
    }
}
