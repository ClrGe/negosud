namespace NegoSudApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Full_Name { get; set; }
        
        public virtual ICollection<CustomerOrder>? CustomerOrders { get; set; }
    }
}
