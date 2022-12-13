using System.ComponentModel.DataAnnotations.Schema;

namespace NegoSudSql.Models;

public class Wine
{
    public int Id { get; set; }
    public string Full_Name { get; set; }
    public string Label { get; set; }
    public decimal Volume { get; set; }
    public string Picture { get; set; }
    public int Year_Produced { get; set; }
    public decimal Alcohol_Percentage { get; set; }
    public decimal Current_Price { get; set; }
    public int Category_Id { get; set; }
}