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

        public string TryParce(string str)
        {
            try
            {
                XElement xElem = XElement.Parse(str);

                foreach (string findedName in Params.findedNames)
                {
                    List<XElement> elements = xElem.Elements(findedName).ToList();
                    foreach (XElement xElement in elements)
                    {
                        xElement.Value = Params.ChangeName(xElement.Value);
                    }
                }

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
