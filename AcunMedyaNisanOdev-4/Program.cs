using Business.Abstaracts;
using Business.Abstracts;
using Business.Concretes;
using Business.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;
using Repositories.Concretes;
using Repositories.Concretes.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));

// MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IBootcampService, BootcampManager>();
builder.Services.AddScoped<IApplicationService, ApplicationManager>();
builder.Services.AddScoped<IBlacklistService, BlacklistManager>();

// Repositories
builder.Services.AddScoped<IBootcampRepository, BootcampRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IBlacklistRepository, BlacklistRepository>();


builder.Services.AddAutoMapper(typeof(BootcampProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ApplicationProfile).Assembly);
builder.Services.AddAutoMapper(typeof(BlacklistProfile).Assembly);



var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware ve Routing
app.UseRouting();

app.UseAuthorization(); // Eğer auth yoksa yine de bırakılabilir
app.MapControllers();   // << BU ÖNEMLİ, CONTROLLER'LARI AKTİF EDER

app.Run();
