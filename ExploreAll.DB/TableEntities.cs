using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreAll
{
    public class TableEntities
    {
        public class GridColumn
        {
            public string field { get; set; }
            public string headerName { get; set; }
            public bool editable { get; set; }
            public bool filter { get; set; }
            public bool hide { get; set; }
            public bool suppressToolPanel { get; set; }

            public GridColumn(string Field, bool Editable, bool Filter, bool Hide, bool SuppressToolPanel, string HeaderName = null)
            {
                field = Field;
                editable = Editable;
                filter = Filter;
                hide = Hide;
                suppressToolPanel = SuppressToolPanel;

                if (String.IsNullOrEmpty(headerName))
                    headerName = Field;
                else
                    headerName = HeaderName;
            }
        }

        public static Dictionary<string, List<GridColumn>> TableColumns = new Dictionary<string, List<GridColumn>>()
        {
            {"LabelsTable", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Selector", true, true, false, false),
                    new GridColumn("Value", true, true, false, false),
                    new GridColumn("Host", false, false, true, true)
                }
            },
            {"UserTable", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Username", true, true, false, false),
                    new GridColumn("Password", true, true, false, false),
                    new GridColumn("Email", true, true, false, false),
                    new GridColumn("Telephone", true, true, false, false),
                    new GridColumn("FirstName", true, true, false, false, "First Name"),
                    new GridColumn("LastName", true, true, false, false, "Last Name"),
                    new GridColumn("Role", true, true, false, false),
                }
            },
        };
    }
}
