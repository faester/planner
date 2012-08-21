using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace PlannerService.Formatters
{
    public class HtmlFormatter : MediaTypeFormatter
    {
        public interface HtmlConverter
        {
            Type ObjectType { get; }
            void Encode(object obj, Stream s);
            object Decode(Stream s);
        }

        private static Dictionary<Type, Func<HtmlConverter>> _converters = new Dictionary<Type, Func<HtmlConverter>>();

        public static void AddHtmlConverter<T, U>()
            where T : AbstractConverter<U>, new()
        {
            _converters[typeof(U)] = () => new T();
        }

        public HtmlFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/x-www-form-urlencoded"));
        }

        public override bool CanReadType(Type type)
        {
            var canRead = _converters.ContainsKey(type);
            return canRead;
        }

        public override bool CanWriteType(Type type)
        {
            var canWrite = _converters.ContainsKey(type);
            return canWrite;
        }

        public override System.Threading.Tasks.Task WriteToStreamAsync(Type type,
            object value,
            Stream writeStream,
            System.Net.Http.HttpContent content,
            System.Net.TransportContext transportContext)
        {
            var task = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                var converter = _converters[type]();
                converter.Encode(value, writeStream);
                writeStream.Flush();
            });

            return task;
        }
    }
}