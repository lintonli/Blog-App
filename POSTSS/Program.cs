using Microsoft.EntityFrameworkCore;
using POSTSS.Data;
using POSTSS.Extensions;
using POSTSS.Services;
using POSTSS.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconnection"));
});
builder.Services.AddScoped<Ipost, PostServices>();
builder.Services.AddScoped<IPostImage, PostImageServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.AddAuth();
builder.AddSwaggenGenExtension();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMigrations();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
