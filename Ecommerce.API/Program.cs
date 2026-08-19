using Ecommerce.Infrastructure;
using Ecommerce.Core;
using Ecommerce.API.Middleware;
var builder = WebApplication.CreateBuilder(args);

//we need to call all the dependecies before we build the app

builder.Services.AddInfrastructure();
builder.Services.AddCore();

//adding controllers 

builder.Services.AddControllers();

var app = builder.Build();

//later will understand minial api

//app.MapGet("/", () => "Hello World!");

app.UseExceptionHandlingMiddleware();

app.UseRouting();



//for authentication and authorization
app.UseAuthentication();
app.UseAuthorization();


//route
app.MapControllers();


app.Run();
