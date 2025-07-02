
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

            app.UseHttpsRedirection();
            app.UseCors(MaStrategieCORS);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
