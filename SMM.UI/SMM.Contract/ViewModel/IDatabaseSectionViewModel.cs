using SMM.Contract.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SMM.Contract.ViewModel
{
    public interface IDatabaseSectionViewModel
    {
        IDatabaseSection DbSection { get; }
    }
}
