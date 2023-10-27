﻿using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entites
{
    public class User
    {

        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]

        public Type Type { get; set; }
    }
}
