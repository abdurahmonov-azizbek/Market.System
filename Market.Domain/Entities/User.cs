﻿using Market.Domain.Common.Models;
using Market.Domain.Enums;

namespace Market.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public Role Role { get; set; }
        public bool IsPaid { get; set; }
    }
}
