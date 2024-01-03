using System.ComponentModel.DataAnnotations;
using DZ_240103_Films_RazorPages.Annotations;
namespace DZ_240103_Films_RazorPages.Models
{
    public class Film
    {
        // Ідентифікатор фільму
        public int Id { get; set; }

        // Назва фільму
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        [Display(Name = "Назва фільму")]
        public string? Name { get; set; }

        // Ім'я режисера
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        [Display(Name = "Режисер")]
        public string? Director { get; set; }

        // Рік випуску фільму
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        [Display(Name = "Рік випуску")]
        [MyReleaseYear(ErrorMessage = "Неправильно вказаний рік випуску")]
        public int ReleaseYear { get; set; }

        // Жанр фільму
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        [MyGenres(new string[] {"Комедія","Історичний", "Мелодрама",
                                "Драма", "Документальний", "Пригодницький",
                                "Бойовик", "Фантастика", "Трилер", "Жахи", "Містика" },
                  ErrorMessage = "Неправильно вказаний жанр фільму")]
        [Display(Name = "Жанр фільму")]
        public string? Genre { get; set; }

        // Постер фільму
        //[Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        [Display(Name = "Постер")]
        public string? PosterPath { get; set; }

        // Опис фільму
        [Required(ErrorMessage = "Поле обов'язкове для заповнення")]
        [Display(Name = "Опис фільму")]
        public string? Description { get; set; }
    }
}
