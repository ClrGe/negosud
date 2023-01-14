﻿using NegoSudApi.Models.Interfaces;

namespace NegoSudApi.Models;

public class Location : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public virtual ICollection<BottleLocation>? BottleLocations { get; set; }

}