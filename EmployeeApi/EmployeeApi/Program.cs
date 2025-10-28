using Microsoft.EntityFrameworkCore;
using TallerCodeChallengeApi.Data;
using TallerCodeChallengeApi.Middleware;
using TallerCodeChallengeApi.Models.Interfaces.Repositories;
using TallerCodeChallengeApi.Models.Interfaces.Services;
using TallerCodeChallengeApi.Repository;
using TallerCodeChallengeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext InMemory
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("EmployeesDb"));

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(p =>
        p.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// DI (Repositories e Services)
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware (Azure AD)
app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

app.Run();