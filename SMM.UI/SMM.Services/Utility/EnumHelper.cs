using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMM.Services.Utility
{
    public sealed class ValueDescription
    {
        public object Value { get; set; }
        public object Description { get; set; }
    }

    public static class EnumHelper
    {
        private static string Description(this Enum eValue)
        {
            var nAttributes = eValue.GetType().GetField(eValue.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (!nAttributes.Any()) return eValue.ToString();
            var descriptionAttribute = nAttributes.First() as DescriptionAttribute;
            return descriptionAttribute != null ? descriptionAttribute.Description : eValue.ToString();
        }

        public static IEnumerable<ValueDescription> GetAllValueDescriptions(Type t)
        {
            if (!t.IsEnum)
            {
                throw new ArgumentException("Type [t] must be of type enum");
            }
            return Enum.GetValues(t).Cast<Enum>()
                .Select((e) => new ValueDescription() {Value = e, Description = e.Description()}).ToList();
        }
    }
}
