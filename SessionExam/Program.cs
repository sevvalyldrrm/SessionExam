using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//options -> datacontex'Teki alaný kullanýyoruz alan açýyoruz dedðiimiz için options yazýldý. abc de olabilirdi.
builder.Services.AddDbContext<SessionExam.Context.DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConStr"));
});


//1.adým Session kullanmak için bu kodu ekliyoruz
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

//2.adým Uygulama genelinde Session kullanýmýný açýyoruz
app.UseSession();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
