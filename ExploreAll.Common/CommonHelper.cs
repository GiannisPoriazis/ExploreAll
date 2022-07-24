using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreAll.Common
{
    public class CommonHelper
    {
        public static Dictionary<int, string> Permissions = new Dictionary<int, string>
        {
            { 0, "ManageAccounts" },
            { 1, "Accounts" },
            { 2, "EditContent" },
            { 3, "ViewContent" }
        };

        public enum eBoolValues
        {
            Ignore = -1,
            False = 0,
            True = 1
        }
    }
}
