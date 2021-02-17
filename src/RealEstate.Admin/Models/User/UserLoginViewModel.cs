using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.User
{
    [Bind(nameof(Username), nameof(Password))]
    public class UserLoginViewModel
    {
        [Required]
        [Display(Name = "Kullanıcı Adı veya E-Posta")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Beni Hatırla")]
        public bool IsPersistent { get; set; }
    }
}