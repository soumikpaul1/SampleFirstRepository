using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Contract.Model;

namespace SMM.Contract.Data
{
    public interface IDataService
    {
        Task<DataTable> GetDataTable(string procedureName, 
                                     DatabasePlatForms dbPlatForms, 
                                     params DatabaseParameter[] parameters);

        Task<DataTable> GetDataTable(string query,
                                    DatabasePlatForms dbPlatform);
    }
}
