﻿using System.ComponentModel.DataAnnotations;

namespace VetClinic.Models.Authorization
{
    public class AuthorizationViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; }
    }
}
