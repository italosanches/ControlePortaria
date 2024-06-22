using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ControlePortaria.Models.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value) 
        {
            if(value != null && (int)Convert.ToInt32(value) != 0)
            { 
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
            }
			else
			{
                return "vazio";
            }
            
        }

		public static Dictionary<int, string> ToDictionary<TEnum>() where TEnum : Enum
		{
			var type = typeof(TEnum);
			if (!type.IsEnum)
			{
				throw new ArgumentException("TEnum must be an enumerated type");
			}

			var enumValues = Enum.GetValues(type).Cast<TEnum>();
			var enumDictionary = new Dictionary<int, string>();

			foreach (var value in enumValues)
			{
				var field = type.GetField(value.ToString());
				var descriptionAttribute = field.GetCustomAttribute<DescriptionAttribute>();
				var description = descriptionAttribute != null ? descriptionAttribute.Description : value.ToString();
				enumDictionary.Add(Convert.ToInt32(value), description);
			}

			return enumDictionary;
		}


	}
}
