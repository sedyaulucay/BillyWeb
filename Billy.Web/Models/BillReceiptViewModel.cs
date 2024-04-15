namespace Billy.Web.Models
{
    public class BillReceiptViewModel
    {
        public int BillNumber { get; set; }
        public string CustomerName { get; set; }
        public List<BillDetails> BillDetails { get; set; }
        public decimal TotalAmount { get; set; }
        public string FromAddress { get; set; }
    }
}
