using ApiPersonajesJavierPantoja.Data;
using ApiPersonajesJavierPantoja.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString =
 builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryPersonajes>();
builder.Services.AddDbContext<PersonajesContext>
 (options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api PERSONAJES CRUD",
        Version = "v1",
        Description = "Examen  CRUD API "
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json",
        name: "Api PERSONAJES CRUD v1");
    options.RoutePrefix = "";
});

// Configure the HTTP request pipeline.





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
