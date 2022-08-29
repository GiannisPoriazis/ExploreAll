using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace ExploreAll.Travel
{
    class AppMethods
    {
        public static object DBSupport { get; private set; }

        public static string DoLogin(string data)
        {
            var cred = JsonConvert.DeserializeObject<AppHelper.LoginCredentials>(data);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["sql"]))
            {
                con.Open();
                string query = "select * from CustomerUsers where Username = @username and Password = @password";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", cred.User);
                cmd.Parameters.AddWithValue("@password", cred.Password);

                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.Read())
                        return JsonConvert.SerializeObject(new AppHelper.ApiResponse().Data = true);
                }
            }

            return JsonConvert.SerializeObject(new AppHelper.ApiResponse().Data = false);
        }

        public static string GetFeed()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["sql"]))
            {
                con.Open();
                string query = @"WITH added_row_number AS
                    (
                        SELECT *,
                            ROW_NUMBER() OVER(PARTITION BY partnerId ORDER BY postdate DESC) AS row_number
                            FROM partnerPosts
                    )
                    SELECT attachmentuid
                    FROM added_row_number
                    WHERE row_number = 1;";
                var cmd = new SqlCommand(query, con);

                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    List<string> storyuid = new List<string>();
                    while (dataReader.Read())
                    {
                        storyuid.Add(dataReader[0].ToString());
                    }

                    if (storyuid.Count > 0)
                        return JsonConvert.SerializeObject(new AppHelper.ApiResponse().Data = storyuid);
                }
            }

            return JsonConvert.SerializeObject(new AppHelper.ApiResponse().Data = null);
        }


        //public string DbConnection()
        //{
        //    DataTable dt = DBSupport.GetData("LabelsTable");

        //    return JsonConvert.SerializeObject(new AppHelper.ApiResponse().Data);
        //}




    }
}
