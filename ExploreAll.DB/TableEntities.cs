using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreAll
{
    public class TableEntities
    {
        public static Dictionary<string, List<string>> TableColumns = new Dictionary<string, List<string>>()
        {
            {"headingsTable", new List<string>()
                {
                    "Id",
                    "Selector",
                    "Value"
                }}
        };
    }
}
