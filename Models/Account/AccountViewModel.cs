using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace VetClinic.Models.Account
{
    public class AccountViewModel
    {
        [Required(ErrorMessage="Введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите фамилию")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Введите адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public int PhoneNumber { get; set; }
    }
}
