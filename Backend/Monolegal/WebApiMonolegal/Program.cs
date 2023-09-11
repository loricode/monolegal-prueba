using ApplicationMonolegal.Bill;
using FluentValidation;
using Microsoft.OpenApi.Models;
using PersistenceMonolegal.Conexion;
using PersistenceMonolegal.Mongo.Bill;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
                        "v1",
                        new OpenApiInfo
                        {
                            Title = "Web Api Monolegal",
                            Version = "v1"
                        }
                 );
    c.CustomSchemaIds(s => s.FullName?.Replace("+", ".")); // asi se agrega el full name de los endpint para evitar conflictos de nombre 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//con el paquete FluentValidation.DependencyInjectionExtensions agrega todas las validaciones solo con pasarle una validacion
builder.Services.AddValidatorsFromAssemblyContaining<Bill_BL.ListBill>();


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(),
    typeof(Bill_BL.Handler).Assembly
));

builder.Services.Configure<ConnectionConfiguration>(builder.Configuration.GetSection("ConnectionConfiguration"));

builder.Services.AddScoped<IFactoryConnection, FactoryConnection>();
builder.Services.AddScoped<IBill_PER, Bill_PER>();

var app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
