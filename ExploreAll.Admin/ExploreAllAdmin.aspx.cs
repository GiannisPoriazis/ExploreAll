using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExploreAll;
using System.IO;
using System.Text.RegularExpressions;

namespace ExploreAll_Admin
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

            using (SqlConnection sql = new SqlConnection(ConfigurationManager.AppSettings["sql"]))
            {
                sql.Open();

                string query;
                SqlCommand cmd;

                if (newRecords.Count > 0)
                {
                    bool valid = false;
                    for(int i=0; i<newRecords.Count; i++)
                    {
                        if (!oldRecords.Contains(newRecords[i]))
                            valid = true;
                    }

                    if (valid)
                    {
                        query = $"INSERT INTO {dataSource} (";
                        foreach (string col in columns)
                        {
                            var columnProperties = TableEntities.TableColumns[dataSource].FirstOrDefault(x => x.field == col);
                            if (columnProperties.hide)
                                continue;
                            query += $"{col},";
                        }

                        query = query.Remove(query.Length - 1);
                        query += ") VALUES";

                        for (int i = 0; i < newRecords.Count; i++)
                        {
                            if (oldRecords.Contains(newRecords[i]))
                            {
                                oldRecords.Remove(newRecords[i]);
                                continue;
                            }

                            query += "(";
                            for (int l = 1; l < columns.Count; l++)
                            {
                                var columnProperties = TableEntities.TableColumns[dataSource].FirstOrDefault(x => x.field == columns[l]);
                                if (columnProperties.hide)
                                    continue;
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
                            for (int l = 1; l < columns.Count; l++)
                            {
                                var columnProperties = TableEntities.TableColumns[dataSource].FirstOrDefault(x => x.field == columns[l]);
                                if (columnProperties.hide)
                                    continue;
                                cmd.Parameters.AddWithValue($"@{i}{l}", rowData[columns[l]].ToString());
                            }
                            data.Remove(rowData);
                        }

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        for(int i=0; i<newRecords.Count; i++)
                        {
                            var rowData = data.FirstOrDefault(x => (int)x["Id"] == newRecords[i]);
                            oldRecords.Remove(newRecords[i]);
                            data.Remove(rowData);
                        }
                    }
                }

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

                if (data.Count > 0)
                {
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

                    for (int l = 0; l < columns.Count; l++)
                    {
                        if (columns[l] == "Id")
                            continue;

                        for (int i = 0; i < data.Count; i++)
                        {
                            cmd.Parameters.AddWithValue($"@{l}{i}id", (int)data[i]["Id"]);
                            cmd.Parameters.AddWithValue($"@{l}{i}value", data[i][columns[l]].ToString());
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            return "ok";
        }

        [WebMethod]
        public static string RefreshGrid(string DataSource)
        {
            DataTable dt = DBSupport.GetData(DataSource);            

            List<string> columns = new List<string>();
            List<object> rowData = new List<object>();
            string columnDefs = JsonConvert.SerializeObject(TableEntities.TableColumns[DataSource]);

            foreach(TableEntities.GridColumn col in TableEntities.TableColumns[DataSource])
            {
                columns.Add(col.field);
            }

            foreach (DataRow data in dt.Rows)
            {
                string rd = "{";
                for (int i = 0; i < columns.Count; i++)
                {
                    rd += "\"" + columns[i] + "\": \"" + data[i] + "\",";
                }
                rd = rd.Remove(rd.Length - 1) + "}";
                rowData.Add(rd);
            }

            DataTable dtRoles = DBSupport.GetData("UserPermissions");
            string UserRoles = "[";

            foreach(DataRow role in dtRoles.Rows)
            {
                UserRoles += $"\"{role["Role"]}\",";
            }

            UserRoles = UserRoles.Remove(UserRoles.LastIndexOf(",")) + "]";

            return "{ \"columnDefs\": " + columnDefs + ", \"rowData\": " + JsonConvert.SerializeObject(rowData) + ", \"rowSelection\": \"single\",  \"pagination\": true, \"cellEditorParamValues\": " + UserRoles + "}";
        }

        [WebMethod]
        public static string UploadSingleFile(string FileUri)
        {
            FileUri = Regex.Replace(FileUri, @"^data:image\/[a-zA-Z]+;base64,", string.Empty);

            string fileName = Guid.NewGuid() + ".png";
            try
            {
                using (FileStream fs = File.Create(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["UploadDirectory"]) + fileName))
                {
                    byte[] image = Convert.FromBase64String(FileUri);
                    fs.Write(image, 0, image.Length);
                }
                return fileName;
            }
            catch(Exception ex)
            {
                return null;
            }
        } 
    }
}