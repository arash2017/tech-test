using Microsoft.EntityFrameworkCore;
using WebAPI.Repositories;
using WebAPI.Services;
using WebAPI.Strategies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow all origins (or specify specific ones)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IImageRepository>(provider =>
    new JsonImageRepository("db.json"));


// Register services and dependencies
builder.Services.AddScoped<IImageRepository, DbImageRepository>();
builder.Services.AddHttpClient<IExternalImageService, ExternalImageService>();
builder.Services.AddScoped<IImageSelectionStrategy, RuleBasedOnLastDigitStrategy>();
builder.Services.AddScoped<IImageSelectionStrategy, RuleBasedOnNonAlphanumericStrategy>();
builder.Services.AddScoped<IImageSelectionStrategy, RuleBasedOnVowelStrategy>();
builder.Services.AddScoped<StrategyEvaluator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
