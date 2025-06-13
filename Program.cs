using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TatilSeyahatProjesiCore.Models.Siniflar;

var builder = WebApplication.CreateBuilder(args);

// ? Baðlantý cümlesini okuyup DbContext'i servis olarak ekle
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ? Authentication & Authorization servisi ekle
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login"; // ? Giriþ sayfasý yolu
        options.AccessDeniedPath = "/GirisYap/ErisimEngellendi"; // ? Yetkisiz giriþ yönlendirmesi (opsiyonel)
    });

builder.Services.AddAuthorization();

// ? Session servisini ekle
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30 dk oturum süresi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ? Controller + View servisi ekle
builder.Services.AddControllersWithViews();

// ? Artýk uygulama inþa edilebilir
var app = builder.Build();

// ? HTTP pipeline yapýlandýrmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // production için güvenlik önlemi
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ? Authentication ve Authorization middleware aktif edilir
app.UseAuthentication();
app.UseAuthorization();

// ? Session middleware aktif edilir (önemli!)
app.UseSession();

// ? Default route: DefaultController > Index action
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
