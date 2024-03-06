using System;
using System.Collections.Generic;
using System.Data;

namespace school_management_system_model.Core.Extensions
{
    internal static class DataSetExtensions
    {
        public static DataSet ToDataSet<T>(this IReadOnlyList<T> list)
        {
            DataSet dataSet = new DataSet();

            // Create a new DataTable
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties of the type T
            var properties = typeof(T).GetProperties();

            // Add columns to the DataTable based on the properties of T
            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Add rows to the DataTable based on the items in the list
            foreach (var item in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (var property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            // Add the DataTable to the DataSet
            dataSet.Tables.Add(dataTable);

            return dataSet;
        }
    }
}
