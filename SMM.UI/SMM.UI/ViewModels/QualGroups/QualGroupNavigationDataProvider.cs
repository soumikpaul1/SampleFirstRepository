using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Domain.QualGroups;
using SMM.Services.QualGroups;

namespace SMM.UI.ViewModels.QualGroups
{
    public class QualGroupNavigationDataProvider : IQualGroupNavigationDataProvider
    {
        private Func<IQualifierGroupDataService> _qualGroupDataServiceProviderCreator;

        public QualGroupNavigationDataProvider(Func<IQualifierGroupDataService> qualGroupDataServiceCreator)
        {
            _qualGroupDataServiceProviderCreator = qualGroupDataServiceCreator;
        }
        public IEnumerable<QualifierGroup> GetAllQualifierGroups()
        {
            using (var qualGroupDataService = _qualGroupDataServiceProviderCreator())
            {
                return qualGroupDataService.LoadAllQualifierGroups();
            }
        }
    }
}
