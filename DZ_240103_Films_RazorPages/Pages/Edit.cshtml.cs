using DZ_240103_Films_RazorPages.Models;
using DZ_240103_Films_RazorPages.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DZ_240103_Films_RazorPages.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Film? Film { get; set; }
        [BindProperty(SupportsGet = true)]
        public IFormFile? PosterFile { get; set; }
        private readonly IFilmRepository _repo;
        // IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
        IWebHostEnvironment _appEnvironment;
        public EditModel(IFilmRepository repo, IWebHostEnvironment appEnvironment)
        {
            _repo = repo;
            _appEnvironment = appEnvironment;
        }
        public async Task OnGetInfo(int? id)
        {
            //if (id == null || await _repo.GetFilms() == null)
            //{
            //    NotFound();
            //}
            Film = await _repo.FindFilm((int)id);

            //if (Film == null)
            //{
            //    NotFound();
            //}
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Film.Description.Length < 20)
                {
                    ModelState.AddModelError("", "Довжина опису фільму - мінімум 20 символів");
                }
                if (PosterFile != null && ModelState.IsValid)
                {
                    // Путь к папке Files
                    string path = "/Files/" + PosterFile.FileName; // имя файла
                    string vpath = "~" + path;
                    // Сохраняем файл в папку Files в каталоге wwwroot
                    // Для получения полного пути к каталогу wwwroot
                    // применяется свойство WebRootPath объекта IWebHostEnvironment
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await PosterFile.CopyToAsync(fileStream); // копируем файл в поток
                    }

                    Film.PosterPath = vpath;
                    await _repo.UpdateFilm(Film);
                    return RedirectToPage("./Index");
                }
                return Page();
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", ex.Message);
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}
