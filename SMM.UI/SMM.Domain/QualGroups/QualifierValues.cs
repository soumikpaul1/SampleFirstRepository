using System;

namespace SMM.Domain.QualGroups
{
    public sealed class QualifierValues
    {
       public string QualifierGroupId { get; set; }
       public string ValueFrom { get; set; }
        public string ValueTo { get; set; }
        public QualifierTypes QualifierType { get; set; }
        public Operands Operand { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime TerminationDate { get; set; }
    }
}
