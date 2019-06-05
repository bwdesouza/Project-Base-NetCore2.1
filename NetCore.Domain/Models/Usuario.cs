using System;
using System.Collections.Generic;

namespace NetCore.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsEnabled { get; set; }
    }
}
