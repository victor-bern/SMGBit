using MediatR;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using SMGbit.Api.Endpoints;
using SMGBit.Application.Extensions;
using SMGBit.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "cors",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices();
builder.Services.AddDbContext<ApplicationContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<GzipCompressionProviderOptions>(opt =>
{
    opt.Level = System.IO.Compression.CompressionLevel.Optimal;
});
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
});
var app = builder.Build();

app.UseResponseCompression();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.UseCors("cors");

app.RegisterTravelEndpoints();
app.MigrateDatabase();
app.Run();
public partial class Program { }