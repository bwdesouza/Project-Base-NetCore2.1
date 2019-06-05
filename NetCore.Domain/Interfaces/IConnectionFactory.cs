using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace NetCore.Domain.Interfaces
{
    public interface IConnectionFactory 
    {
        DbConnection GetOpenBDConnection();
    }
}
