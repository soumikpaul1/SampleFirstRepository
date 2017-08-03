using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMM.Domain.QualGroups;

namespace SMM.Services.QualGroups
{
    public class QualifierGroupDataServiceInMemory : IQualifierGroupDataService
    {
        //For Testing data seeding
        private static IEnumerable<QualifierGroup> ReadFromMemory()
        {
            return new List<QualifierGroup>()
            {
                new QualifierGroup()
                {
                    QualifierValues = new ObservableCollection<QualifierValues>()
                    {
                       new QualifierValues()
                       {
                           EffectiveDate = DateTime.Now,
                           Operand = Operands.BetweenInclsive,
                           QualifierGroupId = "QualGroupId1",
                           QualifierType = QualifierTypes.LineProcedureCode,
                           TerminationDate = DateTime.Now.AddYears(10),
                           ValueFrom = "99200",
                           ValueTo = "99201"
                       },
                        new QualifierValues()
                        {
                            EffectiveDate = DateTime.Now,
                            Operand = Operands.BetweenInclsive,
                            QualifierGroupId = "QualGroupId1",
                            QualifierType = QualifierTypes.LineProcedureCode,
                            TerminationDate = DateTime.Now.AddYears(10),
                            ValueFrom = "99202",
                            ValueTo = "99203"
                        }
                    },
                    QualifierGroupId = "QualGroupId1",
                    TerminationDate = DateTime.Now.AddYears(10),
                    EffectiveDate = DateTime.Now,
                    QualifierGroupDescription = "Qualifier Group Id 1",
                    QualifierGroupType = "SPCR",
                    SameDiffQualifier = 3,
                    SameLineCheckIndicator = false
                },
                new QualifierGroup()
                {
                    QualifierValues = new ObservableCollection<QualifierValues>()
                    {
                        new QualifierValues()
                        {
                            EffectiveDate = DateTime.Now,
                            Operand = Operands.BetweenInclsive,
                            QualifierGroupId = "QualGroupId2",
                            QualifierType = QualifierTypes.LineProcedureCode,
                            TerminationDate = DateTime.Now.AddYears(10),
                            ValueFrom = "99300",
                            ValueTo = "99301"
                        },
                        new QualifierValues()
                        {
                            EffectiveDate = DateTime.Now,
                            Operand = Operands.BetweenInclsive,
                            QualifierGroupId = "QualGroupId2",
                            QualifierType = QualifierTypes.LineProcedureCode,
                            TerminationDate = DateTime.Now.AddYears(10),
                            ValueFrom = "99302",
                            ValueTo = "99303"
                        }
                    },
                    QualifierGroupId = "QualGroupId2",
                    TerminationDate = DateTime.Now.AddYears(10),
                    EffectiveDate = DateTime.Now,
                    QualifierGroupDescription = "Qualifier Group Id 2",
                    QualifierGroupType = "SRCR",
                    SameDiffQualifier = 3,
                    SameLineCheckIndicator = false
                }
            };
        }

        public IEnumerable<QualifierGroup> LoadAllQualifierGroups()
        {
            var qualifierGroups = ReadFromMemory();
            return qualifierGroups;
        }

        public QualifierGroup GetQualifierGroup(string qualifierGroupId)
        {  
            var getQualGrupTask = new TaskFactory<QualifierGroup>().StartNew((arg) =>
            {
                var qualifierGroups = ReadFromMemory();
                var qualifierGroup = qualifierGroups
                    .Where(qualGroup => string.Compare(qualGroup.QualifierGroupId, qualifierGroupId,
                                            StringComparison.CurrentCultureIgnoreCase) == 0)
                    .Select(selectedQualGroup => selectedQualGroup).FirstOrDefault();
                return qualifierGroup;
            },qualifierGroupId);
            return getQualGrupTask.Result;
        }

        public void UpdateQualifierGroup(QualifierGroup qualifierGroup)
        {
            throw new NotImplementedException();
        }

        public void UpdateMultipleQualifierGroups(IList<QualifierGroup> qualifierGroups)
        {
            throw new NotImplementedException();
        }

        public void DeleteQualifierGroup(string qualifierGroupId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMultipleQualifierGroups(IList<QualifierGroup> qualifierGroups)
        {
            throw new NotImplementedException();
        }

        public List<QualifierGroup> FindUnUsedQualifierGroups()
        {
            throw new NotImplementedException();
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~QualifierGroupDataServiceInMemory()
        {
            ReleaseUnmanagedResources();
        }
    }
}
