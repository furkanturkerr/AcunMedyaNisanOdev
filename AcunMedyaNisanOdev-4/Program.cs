using Microsoft.EntityFrameworkCore;
using Repositories.Concretes.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BaseDb")));

var app = builder.Build();

app.Run();
