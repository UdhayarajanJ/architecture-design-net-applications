using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Contracts
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
