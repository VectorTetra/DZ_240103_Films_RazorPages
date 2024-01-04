using DZ_240103_Films_RazorPages.Models;
using DZ_240103_Films_RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DZ_240103_Films_RazorPages.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Film Film { get; set; }
        private readonly IFilmRepository _repo;
        // IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
        public DetailsModel(IFilmRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _repo.GetFilms() == null)
            {
                return NotFound();
            }
            var film = await _repo.FindFilm((int)id);

            if (film == null)
            {
                return NotFound();
            }
            else
            {
                Film = film;
            }
            return Page();
        }
    }
}
