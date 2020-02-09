namespace Paradigms.Dlr
{
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Xml.Linq;

    internal static class ExpandoXml
    {
        public static ExpandoObject ToExpando(this XDocument document)
        {
            var expando = new ExpandoObject();
            var dictionary = expando as IDictionary<string, object>;
            dictionary.Add(document.Root.Name.ToString(), document.Root.ToExpando());
            return expando;
        }

        public static object ToExpando(this XElement element)
        {
            // Leaf element.
            if (!element.HasElements)
            {
                return element.Value;
            }

            // Array.
            if (element.Elements().Count() > 1 && element.Elements().Select(e => e.Name.ToString()).Distinct().Count() == 1)
            {
                return element.Elements().Select(e => e.ToExpando());
            }

            // Dictionary.
            var dictionary = new ExpandoObject() as IDictionary<string, object>;

            foreach (XElement childElement in element.Elements())
            {
                dictionary.Add(childElement.Name.ToString(), childElement.ToExpando());
            }

            return dictionary;
        }
    }
}
