using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthDomain.Queries.Object
{
    public class RegistrationDTO : IQuery
    {
        [MaxLength(20, ErrorMessage = "Логин максимум 20 символов")]
        [MinLength(3, ErrorMessage = "Логин минимум 3 символов")]
        [Required]
        [Display(Name ="Логин")]
        public string Name { get; set; } = null!;

        [MaxLength(20, ErrorMessage ="Пароль максимум 20 символов")]
        [MinLength(3, ErrorMessage = "Пароль минимум 3 символов")]
        [Required]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;

        [Compare("Password")]
        [Display(Name = "Пароль еще раз")]
        public string PasswordAgain { get; set; } = null!;
    }
}
