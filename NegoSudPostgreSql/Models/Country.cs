﻿namespace NegoSudPostgreSql.Models;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual Region Region { get; set;  }
}