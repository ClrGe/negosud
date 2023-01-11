﻿namespace NegoSudApi.Models;

public class Country : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }
    public string? Created_By { get; set; }
    public string? Updated_By { get; set; }
    
    public virtual ICollection<Region> Regions { get; set; }
}