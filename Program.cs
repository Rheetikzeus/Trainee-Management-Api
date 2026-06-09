using TraineeManagement.Services;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Models;
using MySql.EntityFrameworkCore.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITraineeService, TraineeService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<TraineeContext>(options =>
    options.UseMySQL(connectionString)
);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
