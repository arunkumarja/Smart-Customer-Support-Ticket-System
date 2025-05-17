﻿using System.ComponentModel.DataAnnotations;

namespace Support_Ticket_System.ViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }
    }
}
