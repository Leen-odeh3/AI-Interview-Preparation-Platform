using InterviewPrep.API.DependancyInjection;
using InterviewPrep.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrep.API;
public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.addDependancy(builder.Configuration);

        var app = builder.Build();

		#region Update Database
		using var scope = app.Services.CreateScope();

		var services = scope.ServiceProvider;
		var _context = services.GetRequiredService<AppDbContext>();

		var loggerFactory = services.GetRequiredService<ILoggerFactory>();

		try
		{
			await _context.Database.MigrateAsync();
		}
		catch (Exception ex)
		{
			var logger = loggerFactory.CreateLogger<Program>();
			logger.LogError(ex, "Error while updating the database");
		}
		#endregion


		if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
