using Media_API_project.Entities.ApplicationDBContext;
using Media_API_project.Repository.Implementation;
using Media_API_project.Repository.Interface;
using Media_API_project.Service.Implementation;
using Media_API_project.Service.Interface;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MediaConnection")));

builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IMediaService, MediaService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

app.Run();
