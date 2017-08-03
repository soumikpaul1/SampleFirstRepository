using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Contract.Model
{
    public enum DatabaseProviders
    {
        None,
        Oracle,
        [Description("SQL Server")]
        SqlServer,
        Sybase
    }

    public enum DatabasePlatForms
    {
        Facets,
        Smm
    }

    public enum DatabaseAuthenticationMode
    {
        Integrated,
        Database
    }

    public enum DatabaseParameterDirection
    {
        Input,
        Output,
        InputOutput,
        ReturnValue
    }

}
