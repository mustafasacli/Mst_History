using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Mst.Data
{
    public class DataConversions
    {

        #region [ List To DataTable ]

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            try
            {
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        #region [ DataTable To Generic List ]

        public static IList<T> DataTableToList<T>(DataTable datatable) where T : new()
        {
            try
            {
                List<T> liste = new List<T>();
                foreach (DataRow row in datatable.Rows)
                {
                    T item = new T();
                    PropertyDescriptorCollection properties =
                       TypeDescriptor.GetProperties(typeof(T));
                    foreach (DataColumn col in datatable.Columns)
                    {
                        object obj = row[col.ColumnName];
                        if (null != obj && obj != DBNull.Value)
                        {
                            PropertyDescriptor prop = properties.Find(col.ColumnName, true);
                            prop.SetValue(item, obj);
                        }

                    }
                    liste.Add(item);
                }
                return liste;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion


        #region [ Create DataSet From Generic List ]

        public DataSet CreateDataSet<T>(List<T> list)
        {
            try
            {
                var properties = list[0].GetType().GetProperties();
                var dataSet = new DataSet();
                var dataTable = new DataTable();

                DataColumn[] columns = new DataColumn[properties.Length];

                for (int i = 0; i < properties.Length; i++)
                {
                    columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
                }

                dataTable.Columns.AddRange(columns);

                foreach (var item in list)
                {
                    var dataRow = dataTable.NewRow();

                    var itemProperties = item.GetType().GetProperties();

                    for (int i = 0; i < itemProperties.Length; i++)
                    {
                        dataRow[i] = itemProperties[i].GetValue(item, null) ?? DBNull.Value;
                    }

                    dataTable.Rows.Add(dataRow);
                }

                dataSet.Tables.Add(dataTable);

                return dataSet;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion
    }
}
