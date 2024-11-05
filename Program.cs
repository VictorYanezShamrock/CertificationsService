using CertsService.Models.Shamrock;
using CertsService.Models.SIF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext for SIF database
builder.Services.AddDbContext<SifContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SIFConnection")));

// Register the DbContext for ShamrockINT database
builder.Services.AddDbContext<ShamrockIntContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShamrockConnection")));

// Configure CORS to allow any origin, method, and header
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Enable CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
