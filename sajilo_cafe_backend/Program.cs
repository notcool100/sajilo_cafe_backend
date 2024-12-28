var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3001", "http://anjaljoshii-001-site1.ktempurl.com", "https://soulsync-ashen.vercel.app")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetIsOriginAllowed(origin => true)
                                .AllowCredentials(); 
                      });
});

var jwtSettings = builder.Configuration.GetSection("Jwt");
string secretKey = jwtSettings["Key"];
string issuer = jwtSettings["Issuer"];
string audience = jwtSettings["Audience"];

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
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
