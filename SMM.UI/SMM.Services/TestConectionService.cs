using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Contract.Data;
using System.Data.Common;

namespace SMM.Services
{
    public class TestConectionService : ITestConnectionService
    {
        private readonly string _provider;
        public TestConectionService(string provider)
        {
            _provider = provider;
        }
        public async Task<bool> TestConnection(string connectionString)
        {
            
            var provider = DbProviderFactories.GetFactory(_provider);
            using (var con = provider.CreateConnection())
            {
                if (con == null) return false;
                con.ConnectionString = connectionString;
                await con.OpenAsync();
                con.Close();
                return true;
            }
        }
    }
}
