using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//options -> datacontex'Teki alan� kullan�yoruz alan a��yoruz ded�iimiz i�in options yaz�ld�. abc de olabilirdi.
builder.Services.AddDbContext<SessionExam.Context.DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr"));
});


//1.ad�m Session kullanmak i�in bu kodu ekliyoruz
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); 


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

//2.ad�m Uygulama genelinde Session kullan�m�n� a��yoruz
app.UseSession();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
