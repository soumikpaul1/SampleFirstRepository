using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Domain.QualGroups;

namespace SMM.UI.ViewModels.QualGroups
{
    public interface IQualGroupNavigationDataProvider
    {
        IEnumerable<QualifierGroup> GetAllQualifierGroups();
    }
}
