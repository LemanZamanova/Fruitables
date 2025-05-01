using Fruitables.Models.Base;

namespace Fruitables.Models
{
    public class Slider : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }
        public int Order { get; set; }
    }
}
