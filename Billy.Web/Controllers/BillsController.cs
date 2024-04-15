using Billy.Web.Models;
using Billy.Web.Services;
using Billy.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Billy.Web.Controllers
{
    public class BillsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICustomerService _customerService;
        private readonly IBillService _billService;

        public BillsController(IItemService itemService, ICustomerService customerService, IBillService billService)
        {
            _itemService = itemService;
            _customerService = customerService;
            _billService = billService;
        }

        public IActionResult SaveItems(BillViewModel vm)
        {
            Customer customer = new()
            {
                Name = vm.CustomerName
            };
            _customerService.AddCustomer(customer);

            List<BillDetails> billDetails = [];
            foreach (var item in vm.items)
            {
                billDetails.Add(new BillDetails()
                {
                    ItemId = item.itemId,
                    ItemName = item.itemName,
                    CustomerId = customer.Id,
                    Price = item.itemPrice,
                    Discount = item.itemDiscount,
                    Quantity = item.itemQuantity,
                    Total = item.itemTotal
                });
            }
            _billService.AddBillDetails(billDetails);

            Bill bill = new()
            {
                CustomerId = customer.Id,
                BillDate = DateTime.UtcNow,
                TotalAmount = vm.GrandTotal
            };
            _billService.AddBill(bill);

            BillReceiptViewModel Billvm = new()
            {
                BillDetails = billDetails,
                BillNumber = bill.Id,
                FromAddress = "My Restaurant",
                CustomerName = vm.CustomerName,
                TotalAmount = vm.GrandTotal
            };
            return PartialView("_bill", Billvm);
        }

        public async Task<IActionResult> Create()
        {
            var items = await _itemService.GetAll();
            ViewBag.ItemsList = new SelectList(items, "Id", "Name");
            return View();
        }

        public async Task<IActionResult> GetPrice(int id)
        {
            var item = await _itemService.GetById(id);
            var price = item.Price;

            return Json(price);
        }
    }
}
