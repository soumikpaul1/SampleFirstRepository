using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Domain.QualGroups;

namespace SMM.Services.QualGroups
{
    public interface IQualifierGroupDataService : IDisposable
    {
        IEnumerable<QualifierGroup> LoadAllQualifierGroups();
        QualifierGroup GetQualifierGroup(string qualifierGroupId);
        void UpdateQualifierGroup(QualifierGroup qualifierGroup);
        void UpdateMultipleQualifierGroups(IList<QualifierGroup> qualifierGroups);
        void DeleteQualifierGroup(string qualifierGroupId);
        void DeleteMultipleQualifierGroups(IList<QualifierGroup> qualifierGroups);
        List<QualifierGroup> FindUnUsedQualifierGroups();
    }
}
