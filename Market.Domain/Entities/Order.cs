using Market.Domain.Common.Models;
using Market.Domain.Enums;

namespace Market.Domain.Entities
{
    public class Order : EntityBase
    {
        public Guid ProductId { get; set; }
        public long Code { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public PaymentType PaymentType { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public Guid UserId { get; set; }
    }
}
