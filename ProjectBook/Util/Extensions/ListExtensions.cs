using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectBook.Util.Extensions
{
    public static class ListExtensions
    {
        public static async Task<DataTable> ToDataTableAsync<T>(this List<T> list)
        {
            DataTable finalTable = await CreateTable(list);
            
            await Task.Run(() =>
            {
                foreach (T properties in list)
                {
                    DataRow row = finalTable.NewRow();
                    int c = 0;
                    foreach (PropertyInfo propertyInfo in properties.GetType().GetProperties())
                    {
                        row[c] = propertyInfo.GetValue(properties) ?? throw new("Don't fit schema");
                        c++;
                    }
                    finalTable.Rows.Add(row);
                } 
            });
            
            return finalTable;
        }
        
        private static async Task<DataTable> CreateTable<T>(List<T> baseList)
        {
            DataTable dataTable = new();
            
            await Task.Run(() =>
            {
                foreach (ColumnAttribute columnAttribute in from propertie in
                    baseList from propertyInfo in
                    propertie.GetType().GetProperties() from
                    Attribute atributes in
                    propertyInfo.GetCustomAttributes(true) where
                    atributes.GetType() == typeof(ColumnAttribute) select
                    atributes as ColumnAttribute) dataTable.Columns.Add(columnAttribute.Name); 
            });

            return dataTable;
        }
    }
}