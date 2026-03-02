using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace MeterMaintenanceApp
{
  

    public static class EnumerableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var table = new DataTable();
            if (data == null) return table;

            // استخدم PropertyDescriptor للحصول على أسماء و types
            var properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in properties)
            {
                // nullable types handled automatically
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }

}
