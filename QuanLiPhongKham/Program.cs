using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLiPhongKham.Data;
using QuanLiPhongKham.Services.IRepository;
using QuanLiPhongKham.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Thêm tạo kết nối tới SQL server
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLPK"));
});
//add Interface
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IDoctorRepsitory, DoctorRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBHYTRepository, BHYTRepository>();
builder.Services.AddScoped<IProvideNumberRepository, ProvideNumberRepository>();

//Add automapper
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
