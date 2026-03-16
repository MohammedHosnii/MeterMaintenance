using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterMaintenanceApp
{
    public static class InfoClass
    {
        public static DataTable ToDataTable<T>(IEnumerable<T> items)
        {
            var dataTable = new DataTable(typeof(T).Name);

            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
