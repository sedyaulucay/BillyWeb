using Billy.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Billy.Web.ViewModel
{
    public class BillViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public PaymentType PaymentType { get; set; }
        [Display(Name = "Items List")]
        public int ItemId { get; set; }
        //public List<SelectListItem> ItemList { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal Total { get; set; }
        public decimal GrandTotal { get; set; }
        public List<ItemList> items { get; set; } = [];
    }
}
