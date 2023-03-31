using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using TodoList_auth.Areas.Identity.Data;
using TodoList_auth.Models;
using TodoList_auth.Services;
using Microsoft.AspNetCore.Identity;
using TodoList_auth.DataAccess;
using TodoList_auth.Repo;

namespace TodoList_auth
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<TodoListContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddTransient<IEmailSender, EmailSender>();

            builder.Services.AddScoped<ITodoListRepository, EFTodoListRepository>();

            builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));

            builder.Services.AddControllersWithViews();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(name: "default", pattern: "{controller=Todo}/{action=Index}/{id?}");

            app.Run();
        }
    }
}