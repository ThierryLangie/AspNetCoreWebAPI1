
using AspNetCoreWebAPI1.Models;
using AspNetCoreWebAPI1.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPI1
{
    public class Program
    {
		static readonly string MaStrategieCORS = "StrategieGlobale";

		public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<RepositoryService>();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TestDB")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MaStrategieCORS,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:7181");
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            using (var scope = app.Services.CreateScope()) 
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!dbContext.Users.Any())
                {
					dbContext.Users.AddRange(
					new User { Nom = "Doe", Prenom = "John", Email = "john.doe@test.com" },
					new User { Nom = "Carey", Prenom = "Mariah", Email = "mariah.carey@test.com" }
				    );
				}
                dbContext.SaveChanges();
            }

            app.UseHttpsRedirection();
            app.UseCors(MaStrategieCORS);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
