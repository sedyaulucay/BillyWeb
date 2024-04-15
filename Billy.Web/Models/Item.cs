namespace Billy.Web.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
