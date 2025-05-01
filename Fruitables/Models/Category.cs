using Fruitables.Models.Base;

namespace Fruitables.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Product> Products { get; set; }
    }
}
