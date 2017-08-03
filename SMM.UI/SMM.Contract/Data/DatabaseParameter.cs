using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Contract.Model;

namespace SMM.Contract.Data
{
    public sealed class DatabaseParameter
    {
        public string ParameterName { get; set; }

        public DatabaseParameterDirection ParameterDirection { get; set; }

        public int? Size { get; set; }

        public DbType DbType { get; set; }
    }
}
