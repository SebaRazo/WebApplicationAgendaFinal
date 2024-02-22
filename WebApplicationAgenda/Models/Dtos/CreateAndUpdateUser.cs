﻿using System.ComponentModel.DataAnnotations;
using WebApplicationAgenda.Entities;

namespace WebApplicationAgenda.Models.Dtos
{
    public class CreateAndUpdateUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public ERole Role { get; set; }
    }
}
