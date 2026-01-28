using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Year_14_CA_SSD
{
    public static class SQL_Operation
    {
        public static bool DeleteEntry(int id, string idName, string table)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    conn.Open();
                    string cmdText = $"DELETE FROM {table} WHERE {idName} = @ID";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CreateEntry(string[] variables, string table)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    conn.Open();
                    string values = "(";
                    foreach (string entry in variables)
                    {
                        if (entry == "" || entry == "NULL")
                        {
                            values += "NULL,";
                        }
                        else
                        {
                            values += "'" + entry.Replace('\'', ' ') + "',";
                        }
                    }
                    values = values.Remove(values.Length - 1, 1); //removing the last ,
                    values += ")";
                    string cmdText = "INSERT INTO " + table + " VALUES" + values;
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
        }
        public static int? CreateEntryReturnId(string[] variables, string table, string IdName)
        {
            int id;
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    conn.Open();
                    string values = "(";
                    foreach (string entry in variables)
                    {
                        if (entry == "" || entry == "NULL")
                        {
                            values += "NULL,";
                        }
                        else
                        {
                            values += "'" + entry.Replace('\'',' ') + "',";
                        }
                    }
                    values = values.Remove(values.Length - 1, 1); //removing the last ,
                    values += ")";
                    string cmdText = "INSERT INTO " + table + " VALUES" + values;
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.ExecuteNonQuery();

                    //reading back the id
                    string readCmdText = $"SELECT * FROM {table} WHERE {IdName} = SCOPE_IDENTITY()";
                    SqlCommand readCmd = new SqlCommand(readCmdText, conn);

                    SqlDataReader reader = readCmd.ExecuteReader();
                    reader.Read();
                    id = Convert.ToInt32(reader.GetValue(0).ToString());
                    conn.Close();
                    return id;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static bool UpdateEntryVariable(int id, string idName, string columnToUpdate, string columnValue, string table)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    conn.Open();
                    string cmdText = $"UPDATE {table} SET {columnToUpdate} = '{columnValue}' WHERE {idName} = @ID";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool UpdateEntryVariables(int id, string idName, string[] columnsToUpdate, string[] columnValues, string table)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    string setStatements = "";
                    for (int i = 0; i < columnsToUpdate.Length; i++)
                    {
                        string column = columnsToUpdate[i];
                        string value = columnValues[i];
                        if (i != columnsToUpdate.Length - 1)
                        {
                            setStatements += $"{column} = '{value}',";
                        }
                        else
                        {
                            setStatements += $"{column} = '{value}'";
                        }
                    }
                    conn.Open();
                    string cmdText = $"UPDATE {table} SET {setStatements} WHERE {idName} = @ID";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static string[] ReadEntry(int id, string idName, string table)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM {table} WHERE {idName} = {id}";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string[] row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader.GetValue(i).ToString().Trim();
                    }
                    conn.Close();
                    return row;
                }
            }
            catch
            {
                return null;
            }
        }
        public static string ReadColumn(int id, string idName,string columnToRead, string table)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    conn.Open();
                    string query = $"SELECT {columnToRead} FROM {table} WHERE {idName} = {id}";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string value = reader[columnToRead].ToString().Trim();
                    conn.Close();
                    return value;
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
