using DZ_240103_Films_RazorPages.Models;
using DZ_240103_Films_RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DZ_240103_Films_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public ICollection<Film> Films { get; set; }

        private readonly IFilmRepository _repo;
        public IndexModel(IFilmRepository repo)
        {
            _repo = repo;
        }

        public async Task OnGetAsync()
        {
           Films = await _repo.GetFilms();
        }
    }
}
