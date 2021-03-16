using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace test1_1.Parcers.XmlParcer
{
    class XmlParcer : IParcer
    {
        private void RecourceParce(XNode xNode)
        {
            XElement currElement = (XElement)xNode;
            foreach (string findedName in Params.findedNames)
            {
                List<XElement> elements = currElement.Elements(findedName).ToList();
                foreach (XElement xElem in elements)
                {
                    xElem.Value = Params.ChangeName(xElem.Value);
                }
            }

            List<XNode> nodes = currElement.Nodes().ToList();
            foreach (XNode currXNode in nodes)
            {
                //В случае, если не удалось распарсить строку currXNode в XElement - выходим из рекурсии. Значит добрались до глубины.
                try
                {
                    XElement xElement = (XElement)currXNode;
                    if (xElement.Nodes().Count() != 0)
                        RecourceParce(currXNode);
                }
                catch 
                { 
                }
            }
        }
        public string TryParce(string str)
        {
            try
            {
                XElement xElem = XElement.Parse(str);

                RecourceParce(xElem);

                //foreach (string findedName in Params.findedNames)
                //{
                //    List<XElement> elements = xElem.Elements(findedName).ToList();
                //    foreach (XElement xElement in elements)
                //    {
                //        xElement.Value = Params.ChangeName(xElement.Value);
                //    }
                //}

                return xElem.ToString();

            }
            catch (XmlException e)
            {
                return str;
            }
            //System.IO.TextWriter textReader = System.IO.TextReader
            //XmlReader xmlReader = XmlReader.Create(str);
            //System.Xml.Serialization.XmlSerializer reader =
            //    new System.Xml.Serialization.XmlSerializer(typeof(XmlNode));

            //XmlNode xmlNode = (XmlNode)reader.Deserialize(xmlReader);
            //xmlReader.Close();

            //XmlWriter xmlWriter = XmlWriter.Create()
        }
    }
}
