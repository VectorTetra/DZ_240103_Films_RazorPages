using DZ_240103_Films_RazorPages.Models;
using DZ_240103_Films_RazorPages.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<FilmContext>(options => options.UseSqlServer(connection));
// Dependency injection of Film repository
builder.Services.AddScoped<IFilmRepository,FilmRepository>();
// ��������� ������� MVC
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot

app.Run();
