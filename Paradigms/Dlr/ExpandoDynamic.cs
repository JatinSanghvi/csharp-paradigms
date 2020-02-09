namespace Paradigms.Dlr
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class ExpandoDynamic
    {
        public static void Main(string[] args)
        {
            ReadXml();
            ReadXmlAsExpando();
            ReadXmlAsDynamic();
        }

        private static void ReadXml()
        {
            var document = XDocument.Load("Dlr\\Employees.xml");

            IEnumerable<string> employeeNames =
                document.Element("Employees").Elements("Employee").Select(e => e.Element("FirstName").Value);

            Console.WriteLine("XML (LINQ): " + string.Join(", ", employeeNames));
        }

        private static void ReadXmlAsExpando()
        {
            dynamic document = XDocument.Load("Dlr\\Employees.xml").ToExpando();
            dynamic employeeNames = Enumerable.Select(document.Employees, (Func<dynamic, string>)(e => e.FirstName));
            Console.WriteLine("XML (ExpandoObject): " + string.Join(", ", employeeNames));
        }

        private static void ReadXmlAsDynamic()
        {
            dynamic document = new DynamicXml("Dlr\\Employees.xml");
            dynamic employeeNames = Enumerable.Select(document.Employees, (Func<dynamic, string>)(e => e.FirstName));
            Console.WriteLine("XML (DynamicObject): " + string.Join(", ", employeeNames));
        }
    }
}
