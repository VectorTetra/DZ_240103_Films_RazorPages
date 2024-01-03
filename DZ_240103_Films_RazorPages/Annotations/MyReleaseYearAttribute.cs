using System.ComponentModel.DataAnnotations;

namespace DZ_240103_Films_RazorPages.Annotations
{
    // Перевіряє рік випуску на коректність
    public class MyReleaseYearAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                int intval = Convert.ToInt32(value);
                if (intval >= 1895 && intval <= DateTime.Now.Year) return true;
            }
            return false;
        }
    }
}
