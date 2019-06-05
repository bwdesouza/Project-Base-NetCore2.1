using NetCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.AppServices.Interfaces
{
    public interface IJwtService
    {
        Task<string> CreateJsonWebToken(Usuario user);
    }
}
