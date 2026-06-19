using LibrarySystem.DataAccess;
using LibrarySystem.DataAccess.Repositories;
using LibrarySystem.DataAccess.Repositories.Interfaces;
using LibrarySystem.Domain.Services;
using LibrarySystem.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<LibraryDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
               o =>
               {
                   o.CommandTimeout(60);
                   o.GetType();
                   o.EnableRetryOnFailure();

               });

    });



// Add services to the container.
builder.Services.AddScoped<ICounterRepository>(x => new CounterRepository(5, 3));
builder.Services.AddSingleton<ICounterRepository>(x => new CounterRepository(5, 3));
builder.Services.AddTransient<ICounterRepository>(x => new CounterRepository(5, 3));



builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICopyService, CopyService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBorrowingService, BorrowingService>();


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICopyRepository, CopyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();
builder.Services.AddScoped<ICounterRepository>(x => new CounterRepository(5,3));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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
