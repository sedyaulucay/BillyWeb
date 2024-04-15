using Billy.Web.Models;
using Billy.Web.Services;
using Billy.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Billy.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<ActionResult> Index()
        {
            List<ItemViewModel> list = new List<ItemViewModel>();
            var items = await _itemService.GetAll();
            list.AddRange(items.Select(items =>
            new ItemViewModel() { Id = items.Id, Name = items.Name, Price = items.Price }));
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            var model = new Item()
            {
                Name = viewModel.Name,
                Price = viewModel.Price
            };

            await _itemService.SaveItem(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _itemService.GetById(id);

            var model = new ItemViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemViewModel viewModel)
        {
            var model = new Item()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Price = viewModel.Price
            };

            await _itemService.UpdateItem(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemService.DeleteItem(id);
            return RedirectToAction("Index");
        }
    }
}
