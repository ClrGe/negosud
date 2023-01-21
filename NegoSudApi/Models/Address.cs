namespace NegoSudApi.Models
{
    public class Address : IModelBase
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? FirstLine { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public string? Created_By { get; set; }
        public string? Updated_By { get; set; }

        public virtual City? City { get; set; }
        public int? UserId { get; set; } // TODO: Add User model
    }
}
