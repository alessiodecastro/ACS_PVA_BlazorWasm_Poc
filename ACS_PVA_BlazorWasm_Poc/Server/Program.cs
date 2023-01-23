using ACS_PVA_BlazorWasm_Poc.Server.Data;
using ACS_PVA_BlazorWasm_Poc.Server.Services.ACS_Service;
using ACS_PVA_BlazorWasm_Poc.Server.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IACS_Service, ACS_Service>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
