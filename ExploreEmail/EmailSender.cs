using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace email
{

    public class EmailSender
    {

        static void Main(string[] args)
        {

            SendEmail(fromAdress:GetUserName(), GetPassword());
            Console.ReadLine();

        }

        public static void SendEmail(string fromAdress, string password)
        {

            using SmtpClient email = new SmtpClient
            {

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAdress, password)

            };

            string subject = "ExploreAll-Email";
            string body = $"ExploreAll Test/Demo Email\nDate and Time: {DateTime.UtcNow:F}";

            try
            {

                Console.WriteLine("Sending Email...");
                email.Send(fromAdress, recipients:ToAdress(), subject, body);
                Console.WriteLine("Email Succesfully Sent.");

            }
            catch (SmtpException e)
            {

                Console.WriteLine(e);

            }

           
        }

            public static string GetUserName()
            {

              return "nickkaramas@gmail.com";

            }

            public static string GetPassword()
            {

              return "wgkkhlohyeynpgay";

            }

            public static string ToAdress()
            {

              return "nickkaramas@gmail.com";

            }



    }
}