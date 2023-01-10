﻿namespace NegoSudApi.Models;

public class Location : IModelBase
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Created_at { get; set; }
    public DateTime Updated_at { get; set; }
    public string Created_By { get; set; }
    public string Updated_By { get; set; }
    public virtual ICollection<Storage> Bottles { get; set; }

}