﻿using System.ComponentModel.DataAnnotations;

namespace Wallet.Entities.Dto.PostDto
{
    public class RoleDto
    {
        [Required(ErrorMessage = "Role Name cannot be empty"), MinLength(2), MaxLength(30)]
        public string Name { get; set; }
    }
}
