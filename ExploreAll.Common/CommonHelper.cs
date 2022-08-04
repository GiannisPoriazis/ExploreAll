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
            { 3, "ViewContent" },
            { 4, "EditResources" },
            { 5, "ViewSetup" },
            { 6, "EditSetup" },
            { 7, "ViewFinances" },
            { 8, "EditFinances" }
        };

        public enum eBoolValues
        {
            Ignore = -1,
            False = 0,
            True = 1
        }

        public enum eSubscriptions
        {
            Premium = 1,
            Bookings = 2,
            Rentals = 3,
            Basic = 4
        }
    }
}
