using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Contract.Model
{
    public interface ISmmConfiguration
    {
        IDatabaseSection FacetsDatabaseSection { get; set; }
        IDatabaseSection SmmDatabaseSection { get; set; }
        IDictionary<string,string> ApplicationSetting { get; set; }
    }
}
