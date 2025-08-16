using Microsoft.EntityFrameworkCore;
using Postify.API.Data;
using Postify.API.Repositories.Implementation;
using Postify.API.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PostifyConnectionString")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Add a named CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Enable CORS for all origins, methods, and headers; making it publicly accessible
//always use CORS before UseRouting and UseAuthorization
app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
