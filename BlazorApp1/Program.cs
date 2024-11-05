using BlazorApp1.Components;
using BlazorApp1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using BlazorApp1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var cstring = builder.Configuration.GetConnectionString("ConString");

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(cstring));
builder.Services.AddDbContext<DbProject1Context>(options => options.UseSqlServer(cstring));
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddTransient<IProduseService, ProduseService>();
builder.Services.AddTransient<IGestiuniService, GestiuniService>();
builder.Services.AddTransient<IParteneriService, ParteneriService>();
builder.Services.AddTransient<IIntrariService, IntrariService>();
builder.Services.AddTransient<IIntrariDetaliuService, IntrariDetaliuService>();
builder.Services.AddTransient<IIesiriService, IesiriService>();
builder.Services.AddTransient<IIesiriDetaliuService, IesiriDetaliuService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access_denied";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
