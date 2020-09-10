using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MstTableClassGenerator
{
    public class ClassPrinter
    {
        static string using_namespace_QB = "Guru.Framework.QueryBuilding";
        static string using_namespace_MN = "Guru.Framework.Management";

        static string iBOname = "IBaseBO";
        static string iDLname = "IBaseDL";

        private string _baseBOName = "BaseBO";
        private string _baseDLName = "BaseDL";

        static string get_id_column_method = "GetIdColumn";
        static string get_table_name_method = "GetTable";

        string nameSpaceSource = "Source";
        string nameSpaceBase = "Base";

        string classCrud = "Crud";
        string nameSpaceQO = "QO";

        private string _savingPath = "";
        public string SavingPath
        {
            get { return _savingPath; }
            set { _savingPath = value; }
        }

        private string _classNameSpace = "";
        public string ClassNameSpace
        {
            get { return _classNameSpace; }
            set { _classNameSpace = value; }
        }

        private string QOToString()
        {
            StringBuilder classBuilder = new StringBuilder();
            classBuilder.AppendFormat("namespace {0}.{1}.{2}\n", _classNameSpace, nameSpaceSource, nameSpaceQO);
            classBuilder.AppendLine("{");
            classBuilder.AppendLine("\t/* Query Object Class */");
            classBuilder.AppendFormat("\tpublic class {0}\n", classCrud);
            classBuilder.AppendLine("\t{");
            classBuilder.AppendLine("\t}");
            classBuilder.AppendLine("}");
            return classBuilder.ToString();
        }

        private string BaseDLToString()
        {
            StringBuilder classBuilder = new StringBuilder();
            classBuilder.AppendFormat("namespace {0}.{1}.{2}\n", _classNameSpace, nameSpaceSource, nameSpaceBase);
            classBuilder.AppendLine("{");
            classBuilder.AppendFormat("\tusing {0};\n", using_namespace_MN);
            classBuilder.AppendFormat("\tusing {0};\n\n", using_namespace_QB);
            classBuilder.AppendLine("\t/* Main Data Layer Class */");
            classBuilder.AppendFormat("\tpublic class {0} : {1}\n", _baseDLName, iDLname);
            classBuilder.AppendLine("\t{");
            //classBuilder.AppendFormat("\t\tprotected {0} _{1};\n", iBOname, _baseBOName.ToLower());
            classBuilder.AppendFormat("\t\tpublic {0}()\n", _baseDLName);
            classBuilder.AppendLine("\t\t{");
            classBuilder.AppendLine("\t\t}");

            classBuilder.AppendFormat("\t\tpublic {0}({1} {2})\n", _baseDLName, iBOname, _baseBOName.ToLower());
            classBuilder.AppendLine("\t\t{");
            classBuilder.AppendFormat("\t\t\t_{0} = {1};\n", _baseBOName.ToLower(), _baseBOName.ToLower());
            classBuilder.AppendLine("\t\t}");

            classBuilder.AppendLine("\t\tpublic IDbManager Manager");
            classBuilder.AppendLine("\t\t{");
            classBuilder.AppendLine("\t\t\tget");
            classBuilder.AppendLine("\t\t\t{");
            classBuilder.AppendFormat("\t\t\t\treturn new {0}(@\"{1}\");\n\n",
                TableClassGenerator.GetDbManager(TableClassGenerator.Index).GetType().Name,
                TableClassGenerator.ConnStr);
            classBuilder.AppendLine("\t\t\t}\n\t\t}\n");

            classBuilder.AppendLine("\t\tpublic int Insert()\n\t\t{");
            classBuilder.AppendFormat("\t\t\treturn Manager.Insert(_{0});\n", _baseBOName.ToLower());
            classBuilder.AppendLine("\t\t}\n");

            classBuilder.AppendLine("\t\tpublic int InsertAndGetId()\n\t\t{");
            classBuilder.AppendFormat("\t\t\treturn Manager.InsertAndGetId(_{0});\n", _baseBOName.ToLower());
            classBuilder.AppendLine("\t\t}\n");

            classBuilder.AppendLine("\t\tpublic int Update()\n\t\t{");
            classBuilder.AppendFormat("\t\t\treturn Manager.Update(_{0});\n", _baseBOName.ToLower());
            classBuilder.AppendLine("\t\t}\n");

            classBuilder.AppendLine("\t\tpublic int Delete()\n\t\t{");
            classBuilder.AppendFormat("\t\t\treturn Manager.Delete(_{0});\n", _baseBOName.ToLower());
            classBuilder.AppendLine("\t\t}\n");


            classBuilder.AppendLine("\t}\n}");
            return classBuilder.ToString();
        }



        public void PrintClassTable(List<ClassTable> lstClazz)
        {
            try
            {
                if (lstClazz == null || lstClazz.Count == 0)
                    return;

                DirectoryInfo dirInfoSavePath = new DirectoryInfo(_savingPath);

                if (!dirInfoSavePath.Exists)
                    dirInfoSavePath.Create();

                DirectoryInfo dirInfoSourcePath = dirInfoSavePath.CreateSubdirectory("Source");

                /* Writing BaseDL Class Part */
                /*
                DirectoryInfo dirInFoBase = dirInfoSourcePath.CreateSubdirectory("Base");

                string baseDlToString = BaseDLToString();

                FileInfo fBaseDLInfo = new FileInfo(string.Format("{0}/{1}.cs", dirInFoBase.FullName, _baseDLName));

                using (StreamWriter outfile = new StreamWriter(fBaseDLInfo.FullName, false))
                {
                    outfile.Write(baseDlToString);
                }
                */

                /* Writing Business Object(BO) CLasses Part */

                DirectoryInfo dirInfoBO = dirInfoSourcePath.CreateSubdirectory("BO");
                foreach (var clazz in lstClazz)
                {
                    FileInfo fInfo = new FileInfo(string.Format(@"{0}\{1}.cs", dirInfoBO.FullName, clazz.TableName));
                    string tableToClassAll = ClassToBOString(String.Concat(_classNameSpace, ".Source.BO"), clazz);

                    using (StreamWriter outfile = new StreamWriter(fInfo.FullName, false))
                    {
                        outfile.Write(tableToClassAll);
                    }
                }

                /* Writing Data Layer(DL) Classes Part */

                DirectoryInfo dirInfoDL = dirInfoSourcePath.CreateSubdirectory("DL");
                foreach (var clazz in lstClazz)
                {
                    FileInfo fInfo2 = new FileInfo(string.Format(@"{0}\{1}DL.cs", dirInfoDL.FullName, clazz.TableName));
                    string tableToDLClass = ClassToDLString(String.Concat(_classNameSpace, ".Source.DL"), clazz);

                    using (StreamWriter outfile = new StreamWriter(fInfo2.FullName, false))
                    {
                        outfile.Write(tableToDLClass);
                    }
                }

                /* Writing QO.Crud Class Part */
                DirectoryInfo dirInfQO = dirInfoSourcePath.CreateSubdirectory("QO");
                FileInfo fQOInfo = new FileInfo(string.Format(@"{0}\{1}.cs", dirInfQO.FullName, classCrud));
                string strQO = QOToString();

                using (StreamWriter outfile = new StreamWriter(fQOInfo.FullName, false))
                {
                    outfile.Write(strQO);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private string ClassToDLString(string clazzNameSpace, ClassTable clazz)
        {
            try
            {
                StringBuilder classBuilder = new StringBuilder();
                classBuilder.AppendFormat("namespace {0}\n", clazzNameSpace);
                classBuilder.AppendLine("{");
                classBuilder.AppendLine("\tusing System;");
                classBuilder.AppendLine("\tusing Guru.Framework.BaseDal;\n");
                //classBuilder.AppendFormat("\tusing {0}.{1}.{2};\n", _classNameSpace, nameSpaceSource, nameSpaceBase);
                //classBuilder.AppendFormat("\tusing {0}.{1}.{2};\n\n", _classNameSpace, nameSpaceSource, "BO");
                classBuilder.AppendFormat("\tpublic class {0}DL : {1}\n", clazz.TableName.Trim(), _baseDLName);
                classBuilder.AppendLine("\t{\n");
                classBuilder.AppendFormat("\t\tpublic {0}DL()\n", clazz.TableName.Trim());
                classBuilder.AppendLine("\t\t{\n\t\t}");
                classBuilder.AppendLine();
                /* classBuilder.AppendFormat("\t\tpublic {0}DL ({0} m{0})\n", clazz.TableName.Trim());
                 classBuilder.AppendLine("\t\t{");
                 classBuilder.AppendFormat("\t\t\t_{0} = m{1};\n", _baseBOName.ToLower(), clazz.TableName.Trim());
                 classBuilder.AppendLine("\t\t}");
                 */
                classBuilder.AppendLine("\t}\n}\n");
                return classBuilder.ToString();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private string ClassToBOString(string clazzNamespace, ClassTable clazz)
        {
            try
            {
                StringBuilder classBuilder = new StringBuilder();
                classBuilder.AppendFormat("namespace {0}\n", clazzNamespace);
                classBuilder.AppendLine("{");
                classBuilder.AppendLine("\tusing System;");
                classBuilder.AppendLine("\tusing System.Collections.Generic;");
                classBuilder.AppendFormat("\tusing {0}.{1}.{2};\n", _classNameSpace, nameSpaceSource, nameSpaceBase);
                classBuilder.AppendFormat("\tusing {0}.{1}.{2};\n", _classNameSpace, nameSpaceSource, "DL");
                classBuilder.AppendFormat("\tusing {0};\n\n", using_namespace_QB);
                classBuilder.Append(tableToBOString(clazz));
                classBuilder.AppendLine("}");
                return classBuilder.ToString();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private string tableToBOString(ClassTable clazztable)
        {
            try
            {
                StringBuilder tableBuilder = new StringBuilder();
                tableBuilder.AppendFormat("\tpublic class {0} : {1}\n",
                    clazztable.TableName.Trim(), iBOname);
                tableBuilder.Append("\t{\n");
                foreach (ClassColumn col in clazztable.TableColumns)
                {
                    string str = columnToString(col);
                    tableBuilder.Append(str);
                }

                tableBuilder.AppendFormat("\t\tpublic string {0}()\n", get_table_name_method);
                tableBuilder.Append("\t\t{\n\t\t\t");
                tableBuilder.AppendFormat("return \"{0}\";\n", clazztable.TableName);
                tableBuilder.AppendLine("\t\t}");

                tableBuilder.AppendFormat("\t\tpublic string {0}()\n", get_id_column_method);
                tableBuilder.Append("\t\t{\n\t\t\t");
                tableBuilder.AppendFormat("return \"{0}\";\n", clazztable.IdColumn);
                tableBuilder.AppendLine("\t\t}");

                tableBuilder.AppendLine("\t\tpublic int Insert()\n\t\t{");
                tableBuilder.AppendFormat("\t\t\treturn (new {0}DL()).Insert(this);\n", clazztable.TableName.Trim());
                tableBuilder.AppendLine("\t\t}\n");

                tableBuilder.AppendLine("\t\tpublic int InsertAndGetId()\n\t\t{");
                tableBuilder.AppendFormat("\t\t\treturn (new {0}DL()).InsertAndGetId(this);\n", clazztable.TableName.Trim());
                tableBuilder.AppendLine("\t\t}\n");

                tableBuilder.AppendLine("\t\tpublic int Update()\n\t\t{");
                tableBuilder.AppendFormat("\t\t\treturn (new {0}DL()).Update(this);\n", clazztable.TableName.Trim());
                tableBuilder.AppendLine("\t\t}\n");

                tableBuilder.AppendLine("\t\tpublic int Delete()\n\t\t{");
                tableBuilder.AppendFormat("\t\t\treturn (new {0}DL()).Delete(this);\n", clazztable.TableName.Trim());
                tableBuilder.AppendLine("\t\t}\n");

                tableBuilder.AppendLine("\t\tprotected List<string> columnList = new List<string>();\n");

                tableBuilder.AppendLine("\t\tpublic List<string> GetColumnChangeList()\n\t\t{\n\t\t\treturn columnList;\n\t\t}\n");

                tableBuilder.AppendLine(
                                "\t\tpublic void AddChangeList(string column)\n\t\t{\n\t\t\tif (!columnList.Contains(column))\n\t\t\t\tcolumnList.Add(column);\n\t\t}\n");

                tableBuilder.AppendLine("\t}");
                return tableBuilder.ToString();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private string columnToString(ClassColumn column)
        {
            try
            {
                string col_name = column.ColumnName;
                string col_type = column.ColumnTypeName;

                StringBuilder colBuilder = new StringBuilder();
                colBuilder.AppendFormat("\t\tprivate {0} _{1};\n", col_type, col_name);
                colBuilder.AppendFormat("\t\tpublic {0} {1}\n", col_type, col_name);
                colBuilder.Append("\t\t{\n\t\t\tset {");
                colBuilder.AppendFormat(" _{0} = value; AddChangeList(\"{1}\");",
                    col_name, col_name);
                colBuilder.AppendLine(" }");
                colBuilder.Append("\t\t\tget {");
                colBuilder.AppendFormat(" return _{0}; ", col_name);
                colBuilder.AppendLine("}");
                colBuilder.AppendLine("\t\t}");
                return colBuilder.ToString();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
