using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Contract.Model
{
    public interface IDatabaseSection : INotifyPropertyChanged
    {
        DatabaseAuthenticationMode Mode { get; set; }
        DatabaseProviders Provider { get; set; }
        string Server { get; set; }
        string Port { get; set; }
        string Database { get; set; }
        string UserId { get; set; }
        string Password { get; set; }
        string ConnectionTimeOut { get; set; }
        string CommandTimeOut { get; set; }
        string ServiceName { get; set; }
    }

}
