using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnixDemo.Service
{
    public class DatabaseHelper
    {
        public List<string> GetTableNames(string connectionString)
        {
            var tableNames = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get schema information about tables
                    DataTable schemaTable = connection.GetSchema("Tables");

                    // Filter the schemaTable to only include tables (not views, system tables, etc.)
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        string tableType = row["TABLE_TYPE"].ToString();
                        if (tableType == "BASE TABLE")
                        {
                            string tableName = row["TABLE_NAME"].ToString();
                            tableNames.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return tableNames;
        }

        public List<string> GetColumnNames(string connectionString, string tableName)
        {
            var columnNames = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get column names for a specific table
                    string query = @"
                    SELECT COLUMN_NAME 
                    FROM INFORMATION_SCHEMA.COLUMNS 
                    WHERE TABLE_NAME = @TableName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string columnName = reader["COLUMN_NAME"].ToString();
                                columnNames.Add(columnName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return columnNames;
        }
    }
}
