using Market.Domain.Common.Models;

namespace Market.Domain.Entities
{
    public class Expense : EntityBase
    {
        public Guid UserId { get; set; }
        public int Sum { get; set; }
    }
}
