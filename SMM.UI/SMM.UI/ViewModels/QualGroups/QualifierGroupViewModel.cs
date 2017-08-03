using SMM.Domain.QualGroups;
using System.Collections.ObjectModel;
using System;

namespace SMM.UI.ViewModels.QualGroups
{
    public class QualifierGroupViewModel : ViewModelBase, IQualifierGroupViewModel
    {
        private ObservableCollection<QualifierGroup> _qualifierGroups;
        private IQualGroupNavigationDataProvider _qualGroupNavigationDataProvider;

        public QualifierGroupViewModel(IQualGroupNavigationDataProvider qualGroupNavigationDataProvider)
        {
            _qualGroupNavigationDataProvider = qualGroupNavigationDataProvider;
            
        }

        public ObservableCollection<QualifierGroup> QualifierGroups {
            get { return _qualifierGroups; }
            private set
            {
                _qualifierGroups = value;
                RaisePropertyChangedEvent();
            }
        }

        public void Load()
        {
            _qualifierGroups = new ObservableCollection<QualifierGroup>(_qualGroupNavigationDataProvider.GetAllQualifierGroups());
        }
    }
}
