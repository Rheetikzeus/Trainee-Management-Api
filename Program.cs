using TraineeManagement.Services;
using Microsoft.EntityFrameworkCore;
using TraineeManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITraineeService, TraineeService>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<TraineeContext>(opt =>
    opt.UseInMemoryDatabase("TraineeManagementDb"));




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
