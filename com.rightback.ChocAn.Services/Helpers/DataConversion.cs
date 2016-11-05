using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rightback.ChocAn.Services.Helpers
{
    public static class DataConversion
    {
        /// <summary>
        /// Convert Data Table To HTML
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>string</returns>
        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
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

        //another variation doing the same
        //    public static DataTable ListToDataTable<T>(IList<T> data)
        //    {
        //        DataTable table = new DataTable();

        //        //special handling for value types and string
        //        if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
        //        {

        //            DataColumn dc = new DataColumn("Value");
        //            table.Columns.Add(dc);
        //            foreach (T item in data)
        //            {
        //                DataRow dr = table.NewRow();
        //                dr[0] = item;
        //                table.Rows.Add(dr);
        //            }
        //        }
        //        else
        //        {
        //            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
        //            foreach (PropertyDescriptor prop in properties)
        //            {
        //                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        //            }
        //            foreach (T item in data)
        //            {
        //                DataRow row = table.NewRow();
        //                foreach (PropertyDescriptor prop in properties)
        //                {
        //                    try
        //                    {
        //                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        row[prop.Name] = DBNull.Value;
        //                    }
        //                }
        //                table.Rows.Add(row);
        //            }
        //        }
        //        return table;
        //    }
    }
}

