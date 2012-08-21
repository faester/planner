namespace PlannerService.Formatters.Conversion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PropertyInfoToHtmlConverter
    {
        public HtmlPropertyInfo GetHtmlInfo(System.Reflection.PropertyInfo property)
        {
            HtmlPropertyInfo result = new HtmlPropertyInfo();
            result.Name = property.Name;
            result.Data = GetDataType(property);

            return result;
        }

        private HtmlPropertyInfo.DataType GetDataType(System.Reflection.PropertyInfo property)
        {
            if (property.PropertyType == typeof(int))
            {
                return HtmlPropertyInfo.DataType.Number;
            }
            else if (property.PropertyType == typeof(string))
            {
                return HtmlPropertyInfo.DataType.Text;
            }
            else if (property.PropertyType == typeof(double))
            {
                return HtmlPropertyInfo.DataType.Number;
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                return HtmlPropertyInfo.DataType.Date;
            }
            else
            {
                throw new ArgumentException("Could not determine the html input type for property with type " + property.PropertyType);
            }
        }
    }
}