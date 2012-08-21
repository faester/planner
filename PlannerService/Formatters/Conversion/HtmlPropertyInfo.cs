using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerService.Formatters.Conversion
{
    public class HtmlPropertyInfo
    {
        public enum DataType { Text, Number, Date }

        public string Name { get; set; }

        public DataType Data { get; set; }
    }
}