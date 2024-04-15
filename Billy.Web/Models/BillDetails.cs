namespace Billy.Web.Models
{
    public class BillDetails
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ItemId { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
