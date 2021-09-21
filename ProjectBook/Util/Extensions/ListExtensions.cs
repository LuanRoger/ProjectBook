using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;

namespace ProjectBook.Util.Extensions
{
    public static class ListExtensions
    {
        public static async Task<DataTable> ToDataTableAsync<T>(this List<T> list)
        {
            DataTable finalTable = await CreateTable<T>();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            
            await Task.Run(() =>
            {
                foreach (T item in list)
                {
                    DataRow dataRow = finalTable.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        dataRow[prop.Name] = prop.GetValue(item) ?? "-";
                    }
                    finalTable.Rows.Add(dataRow);
                }
            });
            
            return finalTable;
        }
        
        private static async Task<DataTable> CreateTable<T>()
        {
            DataTable dataTable = new();
            
            await Task.Run(() =>
            {
                Type objectType = typeof(T);
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(objectType);
                foreach (PropertyDescriptor prop in properties)
                    dataTable.Columns.Add(char.ToUpper(prop.Name[0]) + prop.Name[1..]);
            });

            return dataTable;
        }
    }
}