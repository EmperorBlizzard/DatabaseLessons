﻿using System.ComponentModel.DataAnnotations;

namespace _01_G_EntityFrameworkCore.Models.Entities;

internal class RoleEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string RoleName { get; set; } = null!;
}
