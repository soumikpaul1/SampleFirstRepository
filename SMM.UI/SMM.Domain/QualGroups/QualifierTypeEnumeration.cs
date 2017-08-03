using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Domain.QualGroups
{
    public enum QualifierTypes
    {
        LineProcedureCode,
        LineServiceCode,
        LineProcedureCode5Digits,
        ProviderSpecialty,
        MemberAge,
        MemberSex
    }

    public enum Operands
    {
        BetweenInclsive,
        BetweenExclusive,
        NotPopulated,
        Equals,
        NotEquals
    }
}
