using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using PlannerService.Models;

namespace PlannerService.Formatters
{
    [Export(typeof(PlannerService.Formatters.HtmlFormatter.HtmlConverter))]
    public class PersonConverter : AbstractConverter<Person>
    {
        protected override Person DoDecode(System.IO.Stream s)
        {
            Person p = new Person();
            using (StreamReader reader = new StreamReader(s))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (line.StartsWith("name=")) { p.Name = line.Substring("name=".Length); };
                }
            }

            return p;
        }

        protected override void WriteToStream(Person t, HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "Name");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, "Name");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, t.Name);
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();

            writer.AddAttribute(HtmlTextWriterAttribute.Id, "ID");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, "ID");
            writer.AddAttribute(HtmlTextWriterAttribute.Value, t.ID);
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
        }
    }
}