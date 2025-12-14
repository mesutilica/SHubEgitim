using NetCoreMVCEgitimi.Models;

namespace NetCoreMVCEgitimi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();// Uygulamada MVC controller view yapýsýný kullanacaðýz
            builder.Services.AddDbContext<UyeContext>(); // UyeContext ile crud iþlemleri yapmak için

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // http den https ye otomatik yönlendire yap
            app.UseRouting();// Uygulamada Routing mekanizmasýný aktif et

            app.UseAuthorization();// Uygulamada yetkilendirme kullanýmýný aktif et

            app.MapStaticAssets();// Uygulamada statik doyalar(wwwroot içerisindekiler) kullanýlabilsin
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
