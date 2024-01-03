using DZ_240103_Films_RazorPages.Models;

namespace DZ_240103_Films_RazorPages.Repositories
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetFilms();
        Task<Film?> FindFilm(int id);
        Task AddFilm(Film film);
        Task UpdateFilm(Film film);
        Task DeleteFilm(int filmId);
    }
}
