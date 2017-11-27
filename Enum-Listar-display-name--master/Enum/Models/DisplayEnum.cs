using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace EnumDispalyName.Enum.Models
{
    public static class DisplayEnum
    {
        public static string GetDisplayName(System.Enum enumValue)
        {
            return enumValue.GetType().GetMember(enumValue.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}
