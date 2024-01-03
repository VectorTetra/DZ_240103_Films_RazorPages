using DZ_240103_Films_RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace DZ_240103_Films_RazorPages.Repositories
{
    public class FilmRepository: IFilmRepository
    {
        private readonly FilmContext _context;
        public FilmRepository(FilmContext context)
        {
            _context = context;
        }
        public async Task<List<Film>> GetFilms()
        {
            return await  _context.Films.ToListAsync();
        }
        public async Task<Film?> FindFilm(int id)
        {
            return await _context.Films.FindAsync(id);
        }
        public async Task AddFilm(Film film)
        {
           _context.Films.Add(film);
           await _context.SaveChangesAsync();
        }
        public async Task UpdateFilm(Film film)
        {
            _context.Update(film);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteFilm(int filmId)
        {
            var film = await FindFilm(filmId);
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }
    }
}
