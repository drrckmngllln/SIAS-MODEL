using System.Collections.Generic;
using System.Data;

namespace school_management_system_model.Infrastructure.Data.Repositories
{
    internal static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this IReadOnlyList<T> list)
        {
            var dt = new DataTable();

            if (list == null || list.Count == 0)
            {
                return dt;
            }

            foreach (var prop in typeof(T).GetProperties())
            {
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
