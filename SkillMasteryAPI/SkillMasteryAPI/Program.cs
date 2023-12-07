using Microsoft.EntityFrameworkCore;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Application.Services;
using SkillMasteryAPI.Infrastructure.Data;
using SkillMasteryAPI.Infrastructure.Repositories.Implementations;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configure services.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMiddleware(app, app.Environment);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddControllers();
    services.AddScoped<ISkillRepository, SkillRepository>();
    services.AddScoped<ISkillService, SkillService>();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    });
}

void ConfigureMiddleware(WebApplication app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}
