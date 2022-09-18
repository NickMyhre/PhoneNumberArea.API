using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using PhoneNumberArea.API.Configurations;
using PhoneNumberArea.API.Contracts;
using PhoneNumberArea.API.Data;
using PhoneNumberArea.API.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PhoneNumberAreaDbConnectionString");

builder.Services.AddDbContext<PhoneNumberAreaDbContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", c =>
    c.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());
});

//Add Serilog
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStatesRepository, StatesRepository>();
builder.Services.AddScoped<IAreaCodesRepository, AreaCodesRepository>();
builder.Services.AddScoped<ICountiesRepository, CountiesRepository>();

//add OData
builder.Services.AddControllers().AddOData(options =>
{
    options.Select().Filter().OrderBy();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//use "AllowAll" Cors Policy
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
