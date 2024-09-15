using Market.Domain.Common.Models;

namespace Market.Domain.Entities
{
    public class ReturnedProduct : EntityBase
    {
        public string Title { get; set; }
        public long Code { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
    }
}
