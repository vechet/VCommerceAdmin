using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using VCommerceAdmin.Data;
using VCommerceAdmin.Repository;
using VCommerceAdmin.Repository.Interface;
using VCommerceAdmin.Services;
using VCommerceAdmin.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    option.OperationFilter<SecurityRequirementsOperationFilter>();
});

//DbContext factory in dependency injection
builder.Services.AddDbContextFactory<VcommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VCommerce")));

//repository in dependency injection
builder.Services.AddSingleton<IBrandRepository, BrandRepository>();
builder.Services.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();

//service in dependency injection
builder.Services.AddSingleton<IBrandService, BrandService>();
builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brand}/{action=Index}/{id?}");

app.Run();