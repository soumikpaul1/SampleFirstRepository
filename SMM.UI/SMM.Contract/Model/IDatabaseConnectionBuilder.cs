using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Contract.Model
{
    public interface IDatabaseConnectionBuilder : IDisposable
    {
        string CreateConnectionString();
    }
}
