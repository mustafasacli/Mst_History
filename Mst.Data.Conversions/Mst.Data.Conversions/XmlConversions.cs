namespace Mst.Data.Conversions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;
    using System.Xml;

    public class XmlConversions
    {

        #region [ Convert A List to XmlDocument ]

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public XmlDocument CreateXmlDocumentFromList<T>(IList<T> list)
        {
            try
            {
                XmlDocument XmlDoc = new XmlDocument();
                XmlNode DocNode = XmlDoc.CreateXmlDeclaration("1.0", "ISO-8859-9", null);
                XmlDoc.AppendChild(DocNode);
                string listname = list[0].GetType().Name;

                XmlNode RootNode = XmlDoc.CreateElement(
                    String.Concat(listname, "s"));
                XmlDoc.AppendChild(RootNode);
                PropertyInfo[] propInfos = typeof(T).GetProperties();

                foreach (var item in list)
                {
                    XmlNode RowNode = XmlDoc.CreateElement(listname);

                    foreach (PropertyInfo prop in propInfos)
                    {
                        XmlNode ColNode = XmlDoc.CreateElement(prop.Name);
                        object obj = prop.GetValue(item, null);
                        ColNode.InnerText = obj != null ? obj.ToString() : "";
                        RowNode.AppendChild(RowNode);
                    }

                    RootNode.AppendChild(RowNode);
                }
                return XmlDoc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert DataTable to XmlNode ]

        public XmlNode ConvertDatataTableToXmlNode(DataTable datatable)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode =
                    xmlDoc.CreateElement(
                    String.Concat(datatable.TableName, "s"));
                foreach (DataRow row in datatable.Rows)
                {
                    XmlNode rowNode = xmlDoc.CreateElement(datatable.TableName);
                    foreach (DataColumn col in datatable.Columns)
                    {
                        XmlNode colNode = xmlDoc.CreateElement(col.ColumnName);
                        Object obj = row[col];
                        String str =
                            obj != null && obj != DBNull.Value ? obj.ToString() : "";
                        colNode.InnerText = str;
                        rowNode.AppendChild(colNode);
                    }
                    rootNode.AppendChild(rowNode);
                }
                return rootNode;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert A DataTable to XmlDocument]

        public XmlDocument ConvertDataTableToXmlDocument(DataTable datatable)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(docNode);
                XmlNode rootNode = ConvertDatataTableToXmlNode(datatable);
                xmlDoc.AppendChild(rootNode);
                return xmlDoc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert A DataSet to XmlDocument ]

        public XmlDocument ConvertDataSetToXmlDocument(DataSet dataset)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(docNode);

                foreach (DataTable table in dataset.Tables)
                {
                    XmlNode rootNode = ConvertDatataTableToXmlNode(table);
                    xmlDoc.AppendChild(rootNode);
                }

                return xmlDoc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion

        /*
        #region [Convert A Xml File to TreeView]

        public void LoadXmlFileToTreeView(ref TreeView treeView, string xmlFilePath, bool willClearAndLoad)
        {
            try
            {
                FileStream fileStream = new FileStream(xmlFilePath, FileMode.Open);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileStream);

                LoadXmlDocumentToTreeView(ref treeView, xmlDoc, willClearAndLoad);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion

        
        #region [ Load A XmlDocument to TreeView ]

        public void LoadXmlDocumentToTreeView(
            ref TreeView treeView, XmlDocument XmlDoc, bool willClearAndLoad)
        {
            try
            {
                if (willClearAndLoad)
                    treeView.Nodes.Clear();

                TreeNode RootNode = new TreeNode(XmlDoc.Name);
                if (XmlDoc.HasChildNodes)
                {
                    foreach (XmlNode childNode in XmlDoc.ChildNodes)
                    {
                        RootNode.Nodes.Add(
                            ConvertXmlNodeToTreeNode(childNode));
                    }
                }
                treeView.Nodes.Add(RootNode);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


        #region [ Convert XmlNode to TreeNode ]

        public TreeNode ConvertXmlNodeToTreeNode(XmlNode xmlNode)
        {
            try
            {
                TreeNode treeNode = new TreeNode(xmlNode.Name);
                treeNode.Tag = xmlNode.InnerText;

                if (xmlNode.HasChildNodes)
                {
                    foreach (XmlNode childNode in xmlNode.ChildNodes)
                    {
                        treeNode.Nodes.Add(
                            ConvertXmlNodeToTreeNode(childNode));
                    }
                }

                return treeNode;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion
        */

        #region [ Convert DataReader To XmlDocument ]

        public XmlDocument ConvertDataReaderToXmlDocument(IDataReader reader)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(docNode);

                string tablename = reader.GetSchemaTable().TableName;
                XmlNode rootNode = xmlDoc.CreateElement(
                    String.Concat(tablename, "s"));
                xmlDoc.AppendChild(rootNode);

                while (reader.Read())
                {
                    XmlNode rowNode = xmlDoc.CreateElement(tablename);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        XmlNode colNode = xmlDoc.CreateElement(reader.GetName(i));
                        colNode.InnerText = reader.GetString(i);

                        rowNode.AppendChild(colNode);
                    }
                    rootNode.AppendChild(rowNode);
                }
                reader.Close();

                return xmlDoc;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion


    }
}
