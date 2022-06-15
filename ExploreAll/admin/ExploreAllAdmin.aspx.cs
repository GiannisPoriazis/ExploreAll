using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreAll
{
    public partial class ExploreAllAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string UpdateGrid(string gridData, List<int> newRecords, List<int> oldRecords, List<string> columns, string dataSource)
        {
            JArray data = JsonConvert.DeserializeObject<JArray>(gridData);

            using(SqlConnection sql = new SqlConnection(ConfigurationManager.AppSettings["sql"]))
            {
                sql.Open();

                string query;
                SqlCommand cmd;

                if (oldRecords.Count > 0)
                {
                    query = $"delete from {dataSource} where";
                    for (int i = 0; i < oldRecords.Count; i++)
                    {
                        if (i == 0)
                            query += $" Id = @{i}";
                        else
                            query += $" OR Id = @{i}";
                    }

                    cmd = new SqlCommand(query, sql);
                    for (int i = 0; i < oldRecords.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@{i}", oldRecords[i]);
                    }

                    cmd.ExecuteNonQuery();
                }

                if (newRecords.Count > 0)
                {
                    query = $"INSERT INTO {dataSource} (";
                    foreach (string col in columns)
                    {
                        query += $"{col},";
                    }

                    query = query.Remove(query.Length - 1);
                    query += ") VALUES";

                    for (int i = 0; i < newRecords.Count; i++)
                    {
                        query += "(";
                        for (int l = 0; l < columns.Count; l++)
                        {
                            query += $"@{i}{l},";
                        }
                        query = query.Remove(query.Length - 1);
                        query += "),";                        
                    }

                    query = query.Remove(query.Length - 1);
                    cmd = new SqlCommand(query, sql);

                    for (int i = 0; i < newRecords.Count; i++)
                    {
                        var rowData = data.FirstOrDefault(x => (int)x["Id"] == newRecords[i]);
                        for (int l = 0; l < columns.Count; l++)
                        {
                            cmd.Parameters.AddWithValue($"@{i}{l}", rowData[columns[l]].ToString());
                        }
                        data.Remove(rowData);
                    }

                    cmd.ExecuteNonQuery();
                }

                query = $"update {dataSource} set";
                for (int l = 0; l < columns.Count; l++)
                {
                    if (columns[l] == "Id")
                        continue;

                    query += $" {columns[l]} = case Id";
                    for (int i = 0; i < data.Count; i++)
                    {
                        query += $" when @{l}{i}id then @{l}{i}value";
                    }
                    query += $" else {columns[l]} end,";
                }

                query = query.Remove(query.Length - 1);
                cmd = new SqlCommand(query, sql);

                for(int l=0; l<columns.Count; l++)
                {
                    if (columns[l] == "Id")
                        continue;

                    for(int i=0; i<data.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@{l}{i}id", (int)data[i]["Id"]);
                        cmd.Parameters.AddWithValue($"@{l}{i}value", data[i][columns[l]].ToString());
                    }
                }

                cmd.ExecuteNonQuery();
            }

            return "ok";
        }
    }
}