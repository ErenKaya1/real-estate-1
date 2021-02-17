using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace src.RealEstate.Admin.Models.User
{
    [Bind(nameof(Email))]
    public class UserForgotPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
    }
}