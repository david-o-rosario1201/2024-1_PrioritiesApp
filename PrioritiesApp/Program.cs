using Microsoft.EntityFrameworkCore;
using PrioritiesApp.Components;
using PrioritiesApp.DAL;
using PrioritiesApp.Services;

namespace PrioritiesApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();

			var ConStr = builder.Configuration.GetConnectionString("ConStr");
			builder.Services.AddDbContext<Context>(Options => Options.UseSqlite(ConStr));
			builder.Services.AddScoped<PrioritiesService>();
			builder.Services.AddScoped<ClientesService>();
			builder.Services.AddScoped<SistemasService>();
			builder.Services.AddScoped<TicketsService>();

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
			app.UseAntiforgery();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
	}
}