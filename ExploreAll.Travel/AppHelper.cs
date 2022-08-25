using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExploreAll.Travel
{
    class AppHelper
    {
        public class ApiRequest
        {
            public string Method { get; set; }
            public string Data { get; set; }

            public object HandleRequest()
            {
                MethodInfo Method = new AppMethods().GetType().GetMethod(this.Method);
                try
                {
                    return Method.Invoke(this, (!String.IsNullOrEmpty(Data)) ? new object[] { Data } : null);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public class ApiResponse
        {
            public object Data { get; set; }
        }

        public class LoginCredentials
        {
            public string User { get; set; }
            public string Password { get; set; }
            public LoginCredentials(string user, string pass)
            {
                User = user;
                Password = pass;
            }
        }
    }
}
