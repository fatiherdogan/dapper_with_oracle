
using Example.Project.Repository.Context;
using Example.Project.Repository.Repository;
using Example.Project.Service.ExampleServices;
using Example.Project.ToolKit.Settings;

namespace Example.Project.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IexampleContext, exampleContext>();
            builder.Services.AddTransient<IexampleRepository, exampleRepository>();
            builder.Services.AddTransient<ISettingService, WebConfigSettingService>();
            builder.Services.AddTransient<IexampleService, exampleService>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
               
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}