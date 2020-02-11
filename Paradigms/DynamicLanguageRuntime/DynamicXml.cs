namespace Paradigms.DynamicLanguageRuntime
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Xml.Linq;

    internal class DynamicXml : DynamicObject, IEnumerable<DynamicXml>
    {
        private readonly XContainer container;

        public DynamicXml(string path)
        {
            this.container = XDocument.Load(path);
        }

        public DynamicXml(XElement element)
        {
            this.container = element;
        }

        public static implicit operator string(DynamicXml dynamicXml)
        {
            return ((XElement)dynamicXml.container).Value;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            XElement element = this.container.Element(binder.Name);

            if (element != null)
            {
                result = new DynamicXml(element);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public IEnumerator<DynamicXml> GetEnumerator()
        {
            foreach (XElement child in this.container.Elements())
            {
                yield return new DynamicXml(child);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
