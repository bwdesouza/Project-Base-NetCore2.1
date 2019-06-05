using System;
using System.Collections.Generic;

namespace NetCore.AppServices.ViewModel
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsEnabled { get; set; }

        public string Token { get; set; }
    }
}
