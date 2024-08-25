﻿//using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    SELECT DISTINCT
                        FK.TABLE_NAME AS ForeignTable
                    FROM
                        INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC
                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK
                            ON RC.CONSTRAINT_NAME = FK.CONSTRAINT_NAME
                        INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK
                            ON RC.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME
                    WHERE
                        PK.TABLE_NAME = @TableName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string foreignTableName = reader["ForeignTable"].ToString();
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
