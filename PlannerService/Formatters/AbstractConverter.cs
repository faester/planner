namespace PlannerService.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public abstract class AbstractConverter<T> : HtmlFormatter.HtmlConverter
    {
        public Type ObjectType
        {
            get { return typeof(T); }
        }

        public void Encode(object obj, Stream s)
        {
            if (obj == null) { throw new ArgumentNullException(); }

            using (var writer = new HtmlTextWriter(new StreamWriter(s)))
            {
                writer.WriteLine("<!DOCTYPE html>");

                writer.RenderBeginTag(HtmlTextWriterTag.Html);
                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                WriteHeadContent(writer);
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Body);
                WriteToStream((T)obj, writer);
                writer.RenderEndTag();
                writer.RenderEndTag();
                writer.Flush();
            }
        }

        protected virtual void WriteHeadContent(HtmlTextWriter writer)
        {
            writer.WriteLine(string.Format("<!-- Formatter for {1}, implemented in {0} -->", GetType().Name, typeof(T).Name));
        }

        protected abstract void WriteToStream(T t, HtmlTextWriter writer);

        protected abstract T DoDecode(System.IO.Stream s);

        public object Decode(System.IO.Stream s)
        {
            return DoDecode(s);
        }
    }
}