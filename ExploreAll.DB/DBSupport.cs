using CommandAsSql;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ExploreAll
{
    public class DBSupport : IDisposable
    {
        public int DEFAULT_COMMAND_TIMEOUT = 120;
        private string FConnectionString;
        private SqlConnection FConn;
        private SqlTransaction FTran;

        public DBSupport(string con)
        {
            FConnectionString = con;
        }

        public static DataTable GetData(string sqlTable)
        {
            DBSupport db = new DBSupport(ConfigurationManager.AppSettings["sql"]);
            var dt = db.QueryTable($"select * from {sqlTable}");
            return dt;
        }

        public DataTable QueryTable(string sqlQuery, params object[] args)
        {
            var sqlCmd = buildCommand(sqlQuery, args) as SqlCommand;
            using (var adapter = GetAdapter(sqlCmd))
            {
                var dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public SqlDataAdapter GetAdapter(string CmdText, params object[] args)
        {
            var cmd = buildCommand(CmdText, args);
            return new SqlDataAdapter(cmd as SqlCommand);
        }

        public SqlDataAdapter GetAdapter(SqlCommand dbCmd)
        {
            return new SqlDataAdapter(dbCmd);
        }

        private static readonly Regex _paramExtractExpression = new Regex(@"\@[\dA-Za-z\.\$]+", RegexOptions.Compiled);

        public static IEnumerable<string> extractSqlParams(string text)
        {
            List<string> cmdParams = new List<string>();
            var matches = _paramExtractExpression.Match(text);
            while (matches.Success)
            {
                cmdParams.Add(matches.Value);
                matches = matches.NextMatch();
            }
            cmdParams.Sort((x, y) => {
                var p1 = int.Parse(x.Substring(1));
                var p2 = int.Parse(y.Substring(1));
                return (p1 - p2);
            });
            return cmdParams.Distinct();
        }

        public interface IDBValue
        {
            object value { get; }
            DbType dbType { get; }
        }

        private static object toDBValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }

        private static object toDBValue(DateTime value)
        {
            if (value.Subtract(DateTime.MinValue).TotalMilliseconds > 0)
            {
                return value;
            }
            else
            {
                return DBNull.Value;
            }
        }

        private static object toDBNullFromTypeDefault(object value)
        {
            if (value is string)
            {
                return toDBValue(value as string);
            }
            else if (value is DateTime)
            {
                return toDBValue((DateTime)value);
            }
            else
            {
                if (value == null)
                {
                    return DBNull.Value;
                }
                else
                {
                    return value;
                }
            }
        }

        private IDbCommand buildCommand(string sqlCmd, params object[] sqlValues)
        {
            string optionRecompile = " OPTION (RECOMPILE)";
            var cmd = createCommand();
            var sqlParams = extractSqlParams(sqlCmd).ToArray();

            for (var ix = sqlValues.Length - 1; ix > -1; ix--)
            {
                var sqlValue = sqlValues[ix];
                if (sqlValue is IDBValue)
                {
                    var dbValue = sqlValue as IDBValue;
                    var cmdParam = cmd.Parameters.AddWithValue(sqlParams[ix], dbValue.value);
                    cmdParam.DbType = dbValue.dbType;
                }
                else
                {
                    var dbValue = toDBNullFromTypeDefault(sqlValue);
                    var cmdParam = cmd.Parameters.AddWithValue(sqlParams[ix], sqlValue);
                    if (sqlValue == null)
                    {
                        cmdParam.Value = dbValue;
                    }
                }
            }


            cmd.CommandTimeout = DEFAULT_COMMAND_TIMEOUT;
            cmd.CommandText = sqlCmd.Replace("@##", "@");


            string cmdSQL = cmd.CommandAsSql().Replace(@"|@|", "@");
            cmd.Parameters.Clear();
            cmd.CommandText = cmdSQL;

            return cmd;

        }

        private SqlCommand createCommand()
        {
            SqlCommand cmd = null;
            if (FTran == null)
            {
                cmd = GetConnection().CreateCommand();
            }
            else
            {
                cmd = GetConnection().CreateCommand();
                cmd.Transaction = FTran;
            }
            return cmd;
        }

        public SqlConnection GetConnection(bool AutoOpen = true)
        {

            string RequestedCatalog = string.Empty;

            if (FConn == null)
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.ConnectionString = FConnectionString;
                RequestedCatalog = sb.InitialCatalog;
                sb.InitialCatalog = "master";
                FConn = new SqlConnection(FConnectionString);

            }
            if ((AutoOpen == true) && (FConn.State == ConnectionState.Closed))
            {
                FConn.Open();
                FConn.ChangeDatabase(RequestedCatalog);
            }
            return FConn;

        }

        public void Dispose()
        {
            if (FConn != null)
            {
                FConn.Close();
            }
        }
    }
}
