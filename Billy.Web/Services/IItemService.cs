using Billy.Web.Models;

namespace Billy.Web.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAll();
        Task<Item> GetById(int id);
        Task SaveItem(Item ıtem);
        Task DeleteItem(int id);
        Task UpdateItem(Item ıtem);
    }
}
