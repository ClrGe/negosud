﻿namespace NegoSudApi.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual Storage Inventory { get; set; }
}