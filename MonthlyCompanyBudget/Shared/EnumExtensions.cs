using System.ComponentModel;
using System.Reflection;

namespace MonthlyCompanyBudget.Shared
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }
            // If no DescriptionAttribute is found, return the default ToString() representation
            return value.ToString();
        }
    }
}
