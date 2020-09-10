namespace MstTableClassGenerator
{
    using System;
    using System.Collections;
    using System.Xml;

    public class Setting
    {

        public static readonly string xmlFile = "conf.xml";

        public readonly string[] ConnTypes =
        {
        "SqlExpress","SqlServer","EnterpriseDB","DB2",
        "Oracle","MySQL","OleDb",
        "SQL-Lite","FireBird"
        };

        private Hashtable _hash;
        public Setting()
        {
            try
            {
                _hash = GetConnTables();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }



        public object this[string key]
        {
            get
            {
                if (_hash.ContainsKey(key))
                    return _hash[key];
                else
                    throw new InvalidOperationException("Invalid key.");
            }
        }


        private Hashtable GetConnTables()
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFile);
                XmlNodeList nodeList = xmldoc.SelectNodes("app/app-conn-settings/connectiontypes/connectiontype");
                Hashtable tmpTable = new Hashtable();
                foreach (XmlNode node in nodeList)
                {
                    tmpTable.Add(
                        node.SelectSingleNode("name").InnerText,
                        node.SelectSingleNode("connectionstring").InnerText);
                }
                return tmpTable;
            }
            catch
            {
                GenerateXmlDocument();
                return GetConnTables();
            }
        }



        private void GenerateXmlDocument()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode appNode = xmlDoc.CreateElement("app");
                xmlDoc.AppendChild(appNode);
                XmlNode appConnNode = xmlDoc.CreateElement("app-conn-settings");
                appNode.AppendChild(appConnNode);
                XmlNode mainNode = xmlDoc.CreateElement("connectiontypes");
                appConnNode.AppendChild(mainNode);
                foreach (var item in ConnTypes)
                {
                    XmlNode ConnTypeNode = GenerateXmlNode(xmlDoc, item);
                    mainNode.AppendChild(ConnTypeNode);
                }

                XmlNode langNode = xmlDoc.CreateElement("app-lang");
                langNode.InnerText = "tr-TR";

                appNode.AppendChild(langNode);

                xmlDoc.Save(xmlFile);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private XmlNode GenerateXmlNode(XmlDocument xmlDoc, string connTypeName)
        {
            try
            {
                XmlNode ConnTypeNode = xmlDoc.CreateElement("connectiontype");
                XmlNode ConnTypeNameNode = xmlDoc.CreateElement("name");
                XmlNode ConnStringNode = xmlDoc.CreateElement("connectionstring");

                ConnTypeNameNode.InnerText = connTypeName;
                ConnStringNode.InnerText = string.Format("Connection string Of {0} Connection Type", connTypeName);
                ConnTypeNode.AppendChild(ConnTypeNameNode);
                ConnTypeNode.AppendChild(ConnStringNode);

                return ConnTypeNode;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }


        public void SaveSetting(string key, string value)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlFile);
                XmlNodeList nodeList = xmldoc.SelectNodes("app/app-conn-settings/connectiontypes/connectiontype");


                Hashtable tmpTable = new Hashtable();
                foreach (XmlNode node in nodeList)
                {
                    if (node.SelectSingleNode("name").InnerText.Equals(key))
                    {
                        node.SelectSingleNode("connectionstring").InnerText =
                            value;
                    }
                }
                xmldoc.Save(xmlFile);
            }
            catch
            {
                GenerateXmlDocument();
                SaveSetting(key, value);
            }
        }
    }
}
