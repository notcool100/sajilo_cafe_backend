using Cafe.Infrastructure;
using Scalar.AspNetCore;
using Security.Infrastructure;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSharedServices();
        builder.Services.AddCafeInfraServices();
        builder.Services.AddSecurityInfraServices();
        builder.Services.Configure<RouteOptions>(RouteOptions =>
        {
            RouteOptions.LowercaseUrls = true;
            RouteOptions.LowercaseQueryStrings = true;
        });

        var app = builder.Build();
        app.Use(async (context, next) =>
        {
            if (context.Request.Path == "/")
            {
                context.Response.Redirect("/swagger");
                return;
            }

            await next();
        });


        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
       
        app.Run();
    }
}