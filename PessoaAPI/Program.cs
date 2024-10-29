using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PessoaAPI.Repositories;

namespace PessoaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddControllers();

                        // Swagger
                        services.AddSwaggerGen();

                        // Injeção de Dependência
                        services.AddScoped<IPessoaRepository, PessoaRepository>();

                        // Configuração de CORS
                        services.AddCors(options =>
                        {
                            options.AddPolicy("AllowAll",
                                builder => builder.AllowAnyOrigin()
                                                  .AllowAnyMethod()
                                                  .AllowAnyHeader());
                        });
                    });

                    webBuilder.Configure(app =>
                    {
                        var env = app.ApplicationServices.GetService<IHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }

                        // Swagger
                        app.UseSwagger();
                        app.UseSwaggerUI(c =>
                        {
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pessoa API V1");
                        });

                        app.UseRouting();

                        // Middleware para CORS
                        app.UseCors("AllowAll");

                        app.UseAuthorization();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}
