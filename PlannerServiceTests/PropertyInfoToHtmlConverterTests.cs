namespace PlannerServiceTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using NUnit.Framework;
    using PlannerService.Formatters.Conversion;

    [TestFixture]
    public class PropertyInfoToHtmlConverterTests
    {
        PropertyInfoToHtmlConverter underTest;

        class IntHolder
        {
            public int I { get; set; }
            public string MyString { get; set; }
            public double DoubleValue { get; set; }
            public DateTime Datetime { get; set; }
            public object NotConvertible { get; set; }
        }

        
        [SetUp]
        public void Setup()
        {
            underTest = new PropertyInfoToHtmlConverter();
        }

        [Test]
        public void TestPropertyConversionName()
        {
            var obj = new IntHolder();
            PropertyInfo property = obj.GetType().GetProperties().Where(pi => pi.Name == "I").First();

            HtmlPropertyInfo htmlProperty = underTest.GetHtmlInfo(property);

            Assert.That(htmlProperty.Name , Is.EqualTo(property.Name), "Wrong name for property");
        }

        [Test]
        public void TestIntPropertyConversion()
        {
            var obj = new IntHolder();
            PropertyInfo property = obj.GetType().GetProperties().Where(pi => pi.Name == "I").First();

            HtmlPropertyInfo htmlProperty = underTest.GetHtmlInfo(property);

            Assert.That(htmlProperty.Data, Is.EqualTo(HtmlPropertyInfo.DataType.Number), "Wrong datatype for property");
        }

        [Test]
        public void TestStringPropertyConversion()
        {
            var obj = new IntHolder();
            PropertyInfo property = obj.GetType().GetProperties().Where(pi => pi.Name == "MyString").First();

            HtmlPropertyInfo htmlProperty = underTest.GetHtmlInfo(property);

            Assert.That(htmlProperty.Data, Is.EqualTo(HtmlPropertyInfo.DataType.Text), "Wrong datatype for property");
        }

        [Test]
        public void TestDatetimePropertyConversion()
        {
            var obj = new IntHolder();
            PropertyInfo property = obj.GetType().GetProperties().Where(pi => pi.Name == "Datetime").First();

            HtmlPropertyInfo htmlProperty = underTest.GetHtmlInfo(property);

            Assert.That(htmlProperty.Data, Is.EqualTo(HtmlPropertyInfo.DataType.Date), "Wrong datatype for property");
        }
        
        [Test]
        public void TestDoublePropertyConversion()
        {
            var obj = new IntHolder();
            PropertyInfo property = obj.GetType().GetProperties().Where(pi => pi.Name == "DoubleValue").First();

            HtmlPropertyInfo htmlProperty = underTest.GetHtmlInfo(property);

            Assert.That(htmlProperty.Data, Is.EqualTo(HtmlPropertyInfo.DataType.Number), "Wrong datatype for property");
        }
        
        [Test]
        public void TestExceptionOnInvalidProperty()
        {
            var obj = new IntHolder();
            PropertyInfo property = obj.GetType().GetProperties().Where(pi => pi.Name == "NotConvertible").First();

            Assert.That(() => underTest.GetHtmlInfo(property)
                , Throws.InstanceOf<ArgumentException>());
        }
    }
}
