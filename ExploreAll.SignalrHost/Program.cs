using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ExploreAll.SignalrHost
{
    class Program
    {   
        static void Main()
        {
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                new ManualResetEvent(false).WaitOne();
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class ExploreAllSignalrHub : Hub
    {
        static string dateFormat = ConfigurationManager.AppSettings["dateFormat"];
        public static int StoreNotification(DB.NotificationEntity notif)
        {
            if (notif.ContainsEmptyValue)
            {
                return 0;
            }

            using (DBSupport db = new DBSupport(ConfigurationManager.AppSettings["sql"]))
            {
                var con = db.GetConnection();
                notif.Date = DateTime.UtcNow.ToString(dateFormat);
                SqlCommand cmd = new SqlCommand($"INSERT INTO Notifications OUTPUT INSERTED.ID VALUES ('{notif.Sender}', '{notif.Title}', '{notif.Message}', '{notif.Date}')", con);
                if (cmd != null)
                {
                    return (int)cmd.ExecuteScalar();
                }

                return 0;
            }
        }

        public void getNewNotifications(string user, string fromProject)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(fromProject))
            {
                return;
            }

            int lastSeenNotif;
            using (DBSupport db = new DBSupport(ConfigurationManager.AppSettings["sql"]))
            {
                SqlConnection con = db.GetConnection();
                SqlCommand cmd = null;
                if (fromProject == "admin")
                {
                    cmd = new SqlCommand($"SELECT LastSeenNotification FROM UserTable WHERE Username='{user}'", con);
                }
                else if (fromProject == "bookings")
                {
                    cmd = new SqlCommand($"SELECT LastSeenNotification FROM CustomerUsers WHERE Username='{user}'", con);
                }
                else
                {
                    return;
                }

                int temp = 0;
                if (cmd != null) {
                    temp = (int)cmd.ExecuteScalar();
                }

                lastSeenNotif = temp >= 1 ? temp : 0;
            }

            List<DB.NotificationEntity> notifs = new List<DB.NotificationEntity>();
            DataTable notifsTable = DBSupport.GetData("Notifications");
            foreach (DataRow row in notifsTable.Rows)
            {
                int notifId = (int)row["ID"];
                if (notifId > lastSeenNotif)
                {
                    DB.NotificationEntity notif = new DB.NotificationEntity(
                        (string)row["Sender"],
                        (string)row["Title"],
                        (string)row["Message"],
                        (string)row["Date"],
                        notifId
                    );
                    notifs.Add(notif);
                }
            }
            Clients.Caller.getNewNotifications(notifs);
        }

        public void broadcastMessage(DB.NotificationEntity notif)
        {
            int id = StoreNotification(notif);
            if (id > 0)
            {
                notif.ID = id;
                Clients.All.broadcastMessage(notif);
            }
        }

        public void updateLatestSeenNotif(string user, string fromProject, int notifId)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(fromProject))
            {
                return;
            }

            using (DBSupport db = new DBSupport(ConfigurationManager.AppSettings["sql"]))
            {
                SqlCommand cmd = null;
                if (fromProject == "admin")
                {
                    cmd = new SqlCommand("UPDATE UserTable SET LastSeenNotification = @notifId WHERE Username = @user", db.GetConnection());
                }
                else if (fromProject == "bookings")
                {
                    cmd = new SqlCommand("UPDATE CustomerUsers SET LastSeenNotification = @notifId WHERE Username = @user", db.GetConnection());
                }
                else
                {
                    return;
                }

                if (cmd != null)
                {
                    cmd.Parameters.AddWithValue("@notifId", notifId);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}