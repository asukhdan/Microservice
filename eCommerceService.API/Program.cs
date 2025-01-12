using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerceService.API.Middlewares;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);



// Add infrastructure services
builder.Services.AddInfrastructureService();
builder.Services.AddCoreService();

//Add controller to the service collection
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

//cors








//Build the web application
var app = builder.Build();

//Handling Exception
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Cors
app.UseCors();

//Controller routes
app.MapControllers();
app.Run();
