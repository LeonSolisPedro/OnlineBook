using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using Asp.Versioning;
using Core.Repositories;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy", builder =>
  builder.AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader()
  );
});
builder.Services.AddRateLimiter(_ => _
.AddFixedWindowLimiter(policyName: "fixed", options =>
{
  options.PermitLimit = 120;
  options.Window = TimeSpan.FromMinutes(1);
  options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
  options.QueueLimit = 50;
}));
var mvcBuilder = builder.Services.AddControllersWithViews(options =>
{
  options.RespectBrowserAcceptHeader = true;
  options.ReturnHttpNotAcceptable = true;
}).AddJsonOptions(options =>
{
  options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
if (builder.Environment.IsDevelopment()) mvcBuilder.AddRazorRuntimeCompilation();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<AgencyService>();
builder.Services.AddScoped<HomeService>();

//Endpoints
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  mvcBuilder.AddRazorRuntimeCompilation();
  app.UseDeveloperExceptionPage();
  app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
  var services = scope.ServiceProvider;
  var context = services.GetRequiredService<AppDbContext>();
  await AppDbSeeder.SeedAsync(context);
}
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseRateLimiter();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}").RequireRateLimiting("fixed");
app.Run();
