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
builder.Services.AddControllers().AddJsonOptions(option =>{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();






//Build the web application
var app = builder.Build();

//Handling Exception
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();
app.Run();
