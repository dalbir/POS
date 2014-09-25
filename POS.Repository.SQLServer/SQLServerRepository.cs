﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using POS.Domain.Common;

namespace POS.Repository.SQLServer
{
    public class SQLServerRepository
    {
         String dbConnection;
        SqlConnection con;

        /// <summary>
        ///     Default Constructor for SQLiteDatabase Class.
        /// </summary>
        public SQLServerRepository()
        {
            try
            {
                 dbConnection = ConfigurationManager.AppSettings["DatabasePath"].ToString();
                //string conPath = ConfigurationManager.AppSettings["DatabasePath"].ToString();
                //conPath = conPath.Replace("\\", "/");
                //dbConnection = "Data Source=" + conPath + "database.db;Version=3;New=True;Compress=True;";

                //dbConnection = "Data Source=C:\\TCSM\\TCSRTMI\\Database\\database.sqlite;Version=3;New=True;Compress=True;" ;
            }
            catch (Exception ex)
            {
                //CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        /// <summary>
        ///     Single Param Constructor for specifying the DB file.
        /// </summary>
        /// <param name="inputFile">The File containing the DB</param>
        public SQLServerRepository(String inputFile)
        {
            dbConnection = String.Format("Data Source={0}", inputFile);
        }

        /// <summary>
        ///     Single Param Constructor for specifying advanced connection options.
        /// </summary>
        /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
        public SQLServerRepository(Dictionary<String, String> connectionOpts)
        {
            try
            {
                String str = "";
                foreach (KeyValuePair<String, String> row in connectionOpts)
                {
                    str += String.Format("{0}={1}; ", row.Key, row.Value);
                }
                str = str.Trim().Substring(0, str.Length - 1);
                dbConnection = str;
            }
            catch (Exception ex)
            {
               // CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
            }
        }

        /// <summary>
        ///     Allows the programmer to run a query against the Database.
        /// </summary>
        /// <param name="sql">The SQL to run</param>
        /// <returns>A DataTable containing the result set.</returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection cnn = new SqlConnection(dbConnection);
            try
            {
                
                cnn.Open();
                SqlCommand mycommand = new SqlCommand(sql, cnn);
                mycommand.CommandText = sql;
                SqlDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
               // CustomLogging.Log("[SQLiteRepository:(GetTableData)]", ex.Message);
                //throw new Exception(ex.Message);

            }
            return dt;
        }

        public string CreateTable(string query)
        {
            string strMessage = "";
            int rowsUpdated = 0;
            try
            {
                con = new SqlConnection(dbConnection);
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                rowsUpdated = command.ExecuteNonQuery();
                command.Dispose();
                con.Close();

                strMessage = "T";
               // CustomLogging.Log("[SQLiteRepository:(CreateTable)]", query);
            }
            catch (Exception e)
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                strMessage = e.Message;
               // CustomLogging.Log("[SQLiteRepository:(CreateTable)]", e.Message);
            }
            return strMessage;
        }

        /// <summary>
        ///     Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQuery(string sql)
        {
            int rowsUpdated = 0;
            try
            {
                SqlTransaction trans;
                SqlConnection cnn = new SqlConnection(dbConnection);
                cnn.Open();
                SqlCommand mycommand = new SqlCommand(sql, cnn);
                mycommand.CommandText = sql;
                rowsUpdated = mycommand.ExecuteNonQuery();

                trans = cnn.BeginTransaction();
                trans.Commit();

                mycommand.Dispose();
                cnn.Close();

                return rowsUpdated;
            }
            catch (Exception ex)
            {
                CustomLogging.Log("[SQLiteRepository:(ExecuteNonQuery)]", ex.Message);
                return rowsUpdated;
            }
        }

        /// <summary>
        ///     Allows the programmer to interact with the database for purposes other than a query.
        /// </summary>
        /// <param name="sql">The SQL to be run.</param>
        /// <returns>An Integer containing the number of rows updated.</returns>
        public int ExecuteNonQueryBulk(string sql, dynamic grd, string tableName)
        {
            int rowsUpdated = 0;
            try
            {
                SqlConnection cnn = new SqlConnection(dbConnection);
                cnn.Open();
                using (var cmd = new SqlCommand(sql, cnn))
                {
                    using (var transaction = cnn.BeginTransaction())
                    {

                        //objGetTableDataResponse.Result = grd;
                        if (grd.Total > 0)
                        {
                            /// 
                            /// Parse a data
                            /// 

                            foreach (var pair in grd.Results)
                            {
                                string data = "";
                                string columns = "";

                                foreach (var p in pair)
                                {
                                    if (p.Key == "R")
                                    {
                                        // do nothing
                                    }
                                    else
                                    {
                                        string strKey = p.Key.ToString();
                                        columns = columns + strKey + ",";
                                        string strValue = "";
                                        if (p.Value != null)
                                        {
                                            if (p.Value.Contains("\""))
                                            {
                                                string rep = p.Value.Replace("\"", "\"\"");
                                                data = data + "\"" + rep + "\"" + ",";
                                            }
                                            else if (p.Value.Contains("'"))
                                            {
                                                //string rep = p.Value.Replace("\"", "\"\"");
                                                strValue = p.Value.ToString();
                                                data = data + "\"" + strValue + "\"" + ",";
                                            }
                                            else
                                            {
                                                strValue = "'" + p.Value.ToString() + "'";
                                                data = data + strValue + ",";
                                            }
                                        }
                                        else
                                        {
                                            strValue = "'" + "" + "'";
                                            data = data + strValue + ",";
                                        }
                                    }
                                }

                                columns = columns.Substring(0, columns.Length - 1);
                                data = data.Substring(0, data.Length - 1);

                                /// 
                                /// Post each row in database
                                /// 
                                string query = "INSERT INTO " + tableName + " ( " + columns + ") VALUES(" + data + ")";
                                //objSQLiteRepository = new SQLiteRepository();
                                //int a = objSQLiteRepository.ExecuteNonQuery(query);
                                cmd.CommandText = query;
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                           // CustomLogging.Log("[GetTableDataResponse:]", tableName + " : Completed");
                            //objGetTableDataResponse.Is_Successful = true;
                            //objGetTableDataResponse.Message = "Data Posted Successfully.";
                        }

                    }
                }

                SqlCommand mycommand = new SqlCommand(sql, cnn);
                mycommand.CommandText = sql;
                rowsUpdated = mycommand.ExecuteNonQuery();
                cnn.Close();
                return rowsUpdated;
            }
            catch (Exception ex)
            {
               // CustomLogging.Log("[SQLiteRepository:(ExecuteNonQueryBulk)]", ex.Message);
                return rowsUpdated;
            }
        }

        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public string ExecuteScalar(string sql)
        {
            SqlConnection cnn = new SqlConnection(dbConnection);
            try
            {
                
                cnn.Open();
                SqlCommand mycommand = new SqlCommand(sql, cnn);
                mycommand.CommandText = sql;
                object value = mycommand.ExecuteScalar();
                cnn.Close();
                if (value != null)
                {
                    return value.ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                if(cnn.State==ConnectionState.Open)
                    cnn.Close();
               CustomLogging.Log("[SQLiteRepository:(ExecuteScalar)]", ex.Message);
                return "";
            }
        }

        /// <summary>
        ///     Allows the programmer to easily update rows in the DB.
        /// </summary>
        /// <param name="tableName">The table to update.</param>
        /// <param name="data">A dictionary containing Column names and their new values.</param>
        /// <param name="where">The where clause for the update statement.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Update(String tableName, Dictionary<String, String> data, String where)
        {
            String vals = "";
            Boolean returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily delete rows from the DB.
        /// </summary>
        /// <param name="tableName">The table from which to delete.</param>
        /// <param name="where">The where clause for the delete.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Delete(String tableName, String where)
        {
            Boolean returnCode = true;
            try
            {
                this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
            }
            catch (Exception ex)
            {
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily insert into the DB
        /// </summary>
        /// <param name="tableName">The table into which we insert the data.</param>
        /// <param name="data">A dictionary containing the column names and data for the insert.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool Insert(String tableName, Dictionary<String, String> data)
        {
            String columns = "";
            String values = "";
            Boolean returnCode = true;
            foreach (KeyValuePair<String, String> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                returnCode = false;
            }
            return returnCode;
        }

        /// <summary>
        ///     Allows the programmer to easily delete all data from the DB.
        /// </summary>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearDB()
        {
            DataTable tables;
            try
            {
                tables = this.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
                foreach (DataRow table in tables.Rows)
                {
                    this.ClearTable(table["NAME"].ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Allows the user to easily clear all data from a specific table.
        /// </summary>
        /// <param name="table">The name of the table to clear.</param>
        /// <returns>A boolean true or false to signify success or failure.</returns>
        public bool ClearTable(String table)
        {
            try
            {
                this.ExecuteNonQuery(String.Format("delete from {0};", table));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool isServerConnected()
        {
            string dbtion = ConfigurationManager.AppSettings["DatabasePath"].ToString();
            using (con = new SqlConnection(dbtion))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception ex)
                {
                     CustomLogging.Log("[SQLiteRepository:(Initialization)]", ex.Message);
                     return false;
                }
            }
        }
    }
}
