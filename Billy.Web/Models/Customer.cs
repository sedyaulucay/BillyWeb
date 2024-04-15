namespace Billy.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<BillDetails> BillDetails { get; set; }
    }
}
