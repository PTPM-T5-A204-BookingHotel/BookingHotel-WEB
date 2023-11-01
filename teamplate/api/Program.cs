using api.Models;
using api.Repositories;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);
AddDI(builder.Services);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QlkhachSanContext>();

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
    //Repository
    services.AddScoped<LoaiPhongRepository>();
    services.AddScoped<HoaDonRepository>();
    services.AddScoped<PhongRepository>();
    services.AddScoped<DatPhongRepository>();

    //iservice
    services.AddScoped<ILoaiPhongService, LoaiPhongService>();
    services.AddScoped<IHoaDonService,HoaDonService>();
    services.AddScoped<IPhongService, PhongService>();
    services.AddScoped<IDatPhongService, DatPhongService>();

}
