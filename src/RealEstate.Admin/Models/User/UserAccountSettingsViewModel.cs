using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.User
{
    [Bind(nameof(UserName), nameof(Email), nameof(CurrentPassword), nameof(NewPassword), nameof(NewPasswordConfirm))]
    public class UserAccountSettingsViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Güncel Parola")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [StringLength(50)]
        [Display(Name = "Yeni Parola")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Yeni Parola Tekrar")]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }
    }
}