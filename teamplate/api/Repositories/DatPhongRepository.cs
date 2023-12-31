﻿using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DatPhongRepository:BaseRepository<DatPhong>
    {
        private readonly QlkhachSanContext _dataContext;
        public DatPhongRepository(QlkhachSanContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Task UpdateDatPhong(DatPhong updateddatPhong)
        {
            var existingdatPhong = _dataContext.DatPhongs.FirstOrDefault(h => h.MaDp == updateddatPhong.MaDp);

            if (existingdatPhong != null)
            {
                _dataContext.Entry(existingdatPhong).CurrentValues.SetValues(updateddatPhong);
                _dataContext.SaveChanges();
            }
            return Task.CompletedTask;
        }
        public DatPhong? GetBySodienthoai(string sodienthoai)
        {
            return _dataContext.DatPhongs.SingleOrDefault(dp => dp.Sdt == sodienthoai);
        }
		public async Task<DatPhong> GetDatPhongByPhoneNumberAsync(string sdt)
		{
			return await _dataContext.DatPhongs.SingleOrDefaultAsync(dp => dp.Sdt == sdt);
		}
	}
}
