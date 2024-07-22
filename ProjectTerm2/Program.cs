using DAL;
using B.E;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ProjectTerm2;

var builder = WebApplication.CreateBuilder(args);


//این هم برای کانکشن جدیده که تو اپ ستینگ هست
var connectionString = builder.Configuration.GetConnectionString("CON1");
builder.Services.AddDbContext<DB>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<UploadFile>();
//از خط 16 تا 28 برای ساین آپ نوشتیمش
builder.Services.AddIdentity<UserApp, IdentityRole>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 4;
    option.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddUserManager<UserManager<UserApp>>()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<DB>();
//برای سیو سبد خرید
builder.Services.AddHttpContextAccessor();
//برای نگه داشتن اطلاعات از کوکی ها استفاده میکنیم
builder.Services.ConfigureExternalCookie(option =>
{
    option.AccessDeniedPath = "/Account/AccessDenied";
    option.Cookie.Name = "WebAppIdentityCookie";
    option.Cookie.HttpOnly = true;
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    option.LoginPath = "/Account/Login";
    option.SlidingExpiration=true;
    //این ترو یا فالسش یعنی این که وقتی کارت تموم شد بمونی تو صفحه از اول شروع شه ولی اگه فالس باشه میندازتت بیرون
});
//این سه خط پایینی برای سشن سبد خریده
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
//این پایینی همون سشن برای سبد خریده
app.UseSession();
app.UseRouting();

//پایینی رو خودم نوشتم         برای حفظ وضعیت و داشتن لاگین و نوشتن اسم و فامیل اون بالا
app.UseAuthentication();
app.UseAuthorization();
//جای دوتا بالایی رو جا ب جا نوشته بودم کاربر وقتی لاگین کرده بود هم حتی میگقت بیا برو لاگین کن تا بخوای پرداخت رو انجام بدی
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
