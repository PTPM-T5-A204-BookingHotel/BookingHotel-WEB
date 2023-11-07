using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using api.Models;
using api.Repositories;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);
AddDI(builder.Services);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QlkhachSanContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDI(IServiceCollection services)
{
    // Repository
    services.AddScoped<LoaiPhongRepository>();
    services.AddScoped<HoaDonRepository>();
    services.AddScoped<PhongRepository>();
    services.AddScoped<DatPhongRepository>();

    // IService
    services.AddScoped<ILoaiPhongService, LoaiPhongService>();
    services.AddScoped<IHoaDonService, HoaDonService>();
    services.AddScoped<IPhongService, PhongService>();
    services.AddScoped<IDatPhongService, DatPhongService>();
}
