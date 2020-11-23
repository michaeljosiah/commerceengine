using CommerceEngine.Core.Interfaces;

namespace CommerceEngine.Core.Entities
{
    public class Product : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal Price { get; set; }

    }
}
