using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Contract.Data
{
    public interface ITestConnectionService
    {
        Task<bool> TestConnection(string connectionString);
    }
}
