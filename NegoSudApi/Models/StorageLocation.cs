﻿using NegoSudApi.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudApi.Models;

public class StorageLocation : IModelBase
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime? CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
   
    public virtual ICollection<BottleStorageLocation>? BottleStorageLocations { get; set; }

}