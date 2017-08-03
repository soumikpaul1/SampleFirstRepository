using SMM.Contract.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Contract.View
{
    public interface IView
    {
        IViewModel ViewModel { get;}
    }
}
