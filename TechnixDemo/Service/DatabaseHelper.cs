using System.Data;
using System.Data.SqlClient;

namespace TechnixDemo.Service
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = Program.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
        public List<string> GetTableNames()
        {
            var tableNames = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
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

        public Dictionary<string, string> GetColumnNamesAndDataTypes(string tableName)
        {
            var columnData = new Dictionary<string, string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Query to get column names and their data types for a specific table
                    string query = @"SELECT COLUMN_NAME, DATA_TYPE 
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
                                string dataType = reader["DATA_TYPE"].ToString();
                                columnData.Add(columnName, dataType);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return columnData;
        }

        public List<string> GetForeignTables(string tableName)
        {
            var foreignTables = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Query to find foreign tables that reference the given table
                    string query = @"
                    SELECT 
                        tr.name AS ReferencedTable
                    FROM 
                        sys.foreign_keys AS fk
                    INNER JOIN 
                        sys.foreign_key_columns AS fkc ON fk.object_id = fkc.constraint_object_id
                    INNER JOIN 
                        sys.tables AS tp ON fkc.parent_object_id = tp.object_id
                    INNER JOIN 
                        sys.columns AS cp ON fkc.parent_object_id = cp.object_id AND fkc.parent_column_id = cp.column_id
                    INNER JOIN 
                        sys.tables AS tr ON fkc.referenced_object_id = tr.object_id
                    INNER JOIN 
                        sys.columns AS cr ON fkc.referenced_object_id = cr.object_id AND fkc.referenced_column_id = cr.column_id
	                    Where tp.name = @TableName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string foreignTableName = reader["ReferencedTable"].ToString();
                                foreignTables.Add(foreignTableName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return foreignTables;
        }

    }
}
