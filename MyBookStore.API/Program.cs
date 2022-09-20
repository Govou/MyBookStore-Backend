using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyBookStore.Application.Author;
using MyBookStore.Application.Book;
using MyBookStore.Application.Publisher;
using MyBookStore.Domain.Interfaces.Repositories;
using MyBookStore.Domain.Repositories;
using MyBookStore.Infrastructure.Context;
using MyBookStore.Infrastructure.Models;
using MyBookStore.Infrastructure.Repositories;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var host = builder.Configuration["DBHOST"] ?? "ms-sql-server";
var port = builder.Configuration["DBPORT"] ?? "1433";
var user = builder.Configuration["DBUSER"] ?? "SA";
var pwd = builder.Configuration["DBPASSWORD"] ?? "Pa55w0rd2022";
var db = builder.Configuration["DBNAME"] ?? "MyBookStore";

var conStr = $"Server=tcp:{host},{port};Database={db};UID={user};PWD={pwd};";

builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(conStr));

//builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}"));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
});

var app = builder.Build();

PrepDB.PrepPopulation(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    var context = services.GetRequiredService<BookStoreContext>();
//    context.Database.Migrate();
//}

app.UseHttpsRedirection();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

app.Run();

