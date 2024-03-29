using DZ_240103_Films_RazorPages.Models;
using DZ_240103_Films_RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DZ_240103_Films_RazorPages.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Film Film { get; set; }
        [BindProperty(SupportsGet = true)]
        public IFormFile PosterFile { get; set; }
        private readonly IFilmRepository _repo;
        // IWebHostEnvironment ������������� ���������� �� ���������, � ������� �������� ����������
        IWebHostEnvironment _appEnvironment;
        public CreateModel(IFilmRepository repo, IWebHostEnvironment appEnvironment)
        {
            _repo = repo;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Film.Description.Length < 20)
                {
                    ModelState.AddModelError("", "������� ����� ������ - ������ 20 �������");
                }
                if (PosterFile != null && ModelState.IsValid)
                {
                    // ���� � ����� Files
                    string path = "/Files/" + PosterFile.FileName; // ��� �����
                    string vpath = "~" + path;
                    // ��������� ���� � ����� Files � �������� wwwroot
                    // ��� ��������� ������� ���� � �������� wwwroot
                    // ����������� �������� WebRootPath ������� IWebHostEnvironment
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await PosterFile.CopyToAsync(fileStream); // �������� ���� � �����
                    }
                    //Film film = new Film { Name = Name, ReleaseYear = ReleaseYear, Genre = Genre, Director = Director, Description = Description };
                    Film.PosterPath = vpath;
                    await _repo.AddFilm(Film);
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
