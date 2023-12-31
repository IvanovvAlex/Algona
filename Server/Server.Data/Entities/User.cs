﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Type = Server.Core.Enums.Type;

namespace Server.Data.Entites
{
    public class User : IdentityUser
    {

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public override string Email { get; set; } = null!;

        [Required]
        public Type Type { get; set; }

        public ICollection<Cargo> Cargos { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}
