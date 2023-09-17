using LinkClip.Infrastructure.Data.Context;
using LinkClip.Infrastructure.IoC;
using LinkClip.Web.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region IoC
RegisterService(builder.Services);
#endregion
#region db context
builder.Services.AddDbContext<LinkClipDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LinkClipConnection"));
});
#endregion
#region auth
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/login";
    options.LogoutPath = "/log-Out";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
});
#endregion

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[]
{
    UnicodeRanges.BasicLatin,
    UnicodeRanges.Arabic
}));

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<LinkClipDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseShortLinkRedirect();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/admin") || context.Request.Path.StartsWithSegments("/user-manage"))
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/login");
        }
        else if(!bool.Parse(context.User.FindFirstValue("IsAdmin")))
        {
            context.Response.Redirect("/");
        }
    }


    await next.Invoke();

});





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapFallbackToController("Index","Home");
});



#region IoC
static void RegisterService(IServiceCollection services)
{
    DependencyContainer.RegisterService(services);
}
#endregion


app.Run();


