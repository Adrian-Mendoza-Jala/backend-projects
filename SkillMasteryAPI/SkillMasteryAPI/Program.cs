using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using SkillMasteryAPI.Application.Services.Interfaces;
using SkillMasteryAPI.Application.Services;
using SkillMasteryAPI.Infrastructure.Data;
using SkillMasteryAPI.Infrastructure.Repositories.Implementations;
using SkillMasteryAPI.Infrastructure.Repositories.Interfaces;
using SkillMasteryAPI.Infrastructure.Middleware;
using SkillMasteryAPI.Application.Validators;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;

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
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    services.AddScoped<ISkillRepository, SkillRepository>();
    services.AddScoped<ISkillService, SkillService>();
    services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SkillValidator>());
    builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SkillValidator>());

    services.AddEndpointsApiExplorer();

    services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    });

    services.AddSwaggerGen();

    services.AddResponseCompression(options =>
    {
        options.Providers.Add<GzipCompressionProvider>();
        options.EnableForHttps = true;
    });
    services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = CompressionLevel.Fastest;
    });

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
    app.UseMiddleware<ExceptionMiddleware>();
    app.UseResponseCompression();

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}
