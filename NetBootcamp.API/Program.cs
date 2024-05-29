using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NetBootcamp.Repository;
using NetBootcamp.Service;
using NetBootcamp.Service.Products.Configuration;
using NetBootcamp.Service.Roles.Configuration;
using NetBootcamp.Service.Users.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), x =>
    {
        x.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.GetName().Name);
    }));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(ServiceAssembly).Assembly);
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddUserService();
builder.Services.AddRoleService();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddProductService();





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
