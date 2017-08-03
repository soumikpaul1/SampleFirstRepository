using System;
using System.Collections.ObjectModel;


namespace SMM.Domain.QualGroups
{
    public sealed class QualifierGroup
    {
        public string QualifierGroupId { get; set; }
        public string QualifierGroupDescription { get; set; }
        public string QualifierGroupType { get; set; }
        public bool SameLineCheckIndicator { get; set; }
        public int SameDiffQualifier { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public ObservableCollection<QualifierValues> QualifierValues { get; set; }
    }
}
