using TestTaskPrasBLL;
using TestTaskPrasBLL.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.AddSupportedCultures(new string[] { "en-US", "ru-RU" }).AddSupportedUICultures(new string[] { "en-US", "ru-RU" });
});

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});
builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
}).AddViewLocalization()
.AddDataAnnotationsLocalization();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "TestTaskPrasAuth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});
builder.Services.RegisterDependencies();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name:"admin",pattern: "{area:exists}/{controller=Post}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name:"default",pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
