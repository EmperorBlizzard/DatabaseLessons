﻿namespace FM_EntityFramework.Models.Entites;

internal class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int CategoryId {  get; set; }
    public CategoryEntity Category { get; set; } = null!;
}

