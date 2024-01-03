using DZ_240103_Films_RazorPages.Models;
using DZ_240103_Films_RazorPages.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Получаем строку подключения из файла конфигурации
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<FilmContext>(options => options.UseSqlServer(connection));
// Dependency injection of Film repository
builder.Services.AddScoped<IFilmRepository,FilmRepository>();
// Добавляем сервисы MVC
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot

app.Run();
