using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Domain.QualGroups;

namespace SMM.UI.ViewModels.QualGroups
{
    public interface IQualifierGroupDataProvider
    {
        QualifierGroup GetQualifierGroup(string qualifierGroupId);
        void UpdateQualifierGroup(QualifierGroup qualifierGroup);
        void UpdateMultipleQualifierGroups(IList<QualifierGroup> qualifierGroups);
        void DeleteQualifierGroup(string qualifierGroupId);
        void DeleteMultipleQualifierGroups(IList<QualifierGroup> qualifierGroups);
    }
}
