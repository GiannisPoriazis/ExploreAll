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
            public string cellRenderer { get; set; }
            public string cellRendererParams { get; set; }
            public string cellEditor { get; set; }
            public string valueFormatter { get; set; }

            public GridColumn(string Field, bool Editable, bool Filter, bool Hide, bool SuppressToolPanel, string HeaderName = null, string CellRenderer = null, string CellRendererParams = null, string CellEditor = null, string ValueFormatter = null)
            {
                field = Field;
                editable = Editable;
                filter = Filter;
                hide = Hide;
                suppressToolPanel = SuppressToolPanel;

                if (String.IsNullOrEmpty(HeaderName))
                    headerName = Field;
                else
                    headerName = HeaderName;

                cellRenderer = CellRenderer;
                cellRendererParams = CellRendererParams;
                cellEditor = CellEditor;
                valueFormatter = ValueFormatter;
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
                    new GridColumn("Password", false, false, false, false, CellRenderer: "passwordFormatterComponent"),
                    new GridColumn("Email", true, true, false, false),
                    new GridColumn("Telephone", true, true, false, false),
                    new GridColumn("FirstName", true, true, false, false, "First Name"),
                    new GridColumn("LastName", true, true, false, false, "Last Name"),
                    new GridColumn("Role", true, true, false, false, CellEditor: "agSelectCellEditor"),
                }
            },
            {"SightsTable", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Name", true, true, false, false),
                    new GridColumn("Description", true, true, false, false),
                    new GridColumn("Lat", true, true, false, false),
                    new GridColumn("Long", true, true, false, false),
                    new GridColumn("Label", true, true, false, false),
                    new GridColumn("Thumbnail", false, false, false, false, CellRenderer: "fileUploaderComponent", CellRendererParams: null),
                }
            },
            {"UserPermissions", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Role", true, true, false, false),
                    new GridColumn("ManageAccounts", false, false, false, false, "Manage Accounts", CellRenderer: "checkboxRenderer"),
                    new GridColumn("Accounts", false, false, false, false, "View Accounts", CellRenderer: "checkboxRenderer"),
                    new GridColumn("EditContent", false, false, false, false, "Manage Content", CellRenderer: "checkboxRenderer"),
                    new GridColumn("ViewContent", false, false, false, false, "View Content", CellRenderer: "checkboxRenderer"),
                    new GridColumn("EditResources", false, false, false, false, "Manage Resources", CellRenderer: "checkboxRenderer"),
                    new GridColumn("ViewSetup", false, false, false, false, "View Setup", CellRenderer: "checkboxRenderer"),
                    new GridColumn("EditSetup", false, false, false, false, "Manage Setup", CellRenderer: "checkboxRenderer"),
                    new GridColumn("ViewFinances", false, false, false, false, "View Finances", CellRenderer: "checkboxRenderer"),
                    new GridColumn("EditFinances", false, false, false, false, "Manage Finances", CellRenderer: "checkboxRenderer"),
                }
            },
            {"StoresTable", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Title", true, true, false, false),
                    new GridColumn("Label", true, true, false, false),
                    new GridColumn("Description", true, true, false, false),
                    new GridColumn("Street", true, true, false, false),
                    new GridColumn("City", true, true, false, false),
                    new GridColumn("Zip", true, true, false, false),
                    new GridColumn("Country", false, false, false, false, ValueFormatter: "Country"),
                    new GridColumn("Lat", true, true, false, false),
                    new GridColumn("Long", true, true, false, false),
                    new GridColumn("Thumbnail", false, false, false, false, CellRenderer: "fileUploaderComponent", CellRendererParams: null),
                    new GridColumn("AccountId", true, true, false, false, "Cust. Account")
                }
            },
            { "Resources", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Name", true, true, false, false),
                    new GridColumn("en", true, true, false, false),
                    new GridColumn("gr", true, true, false, false)                   
                }
            },
            { "CustomersTable", new List<GridColumn>()
                {
                    new GridColumn("Id", false, true, false, false),
                    new GridColumn("Title", true, true, false, false),
                    new GridColumn("Description", true, true, false, false),
                    new GridColumn("Email", true, true, false, false),
                    new GridColumn("Telephone", true, true, false, false),
                    new GridColumn("Subscription", true, true, false, false, CellEditor: "agSelectCellEditor"),
                    new GridColumn("Host", true, true, false, false, CellEditor: "agSelectCellEditor"),
                }
            },
            { "HostTable", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Host", true, true, false, false),
                }
            },
            { "Subscriptions", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("Title", true, true, false, false),
                    new GridColumn("Rate", true, true, false, false),
                }
            },
            { "CustomerUsers", new List<GridColumn>()
                {
                    new GridColumn("Id", false, false, true, true),
                    new GridColumn("CustomersTable_Id", true, true, false, false, "Customer Account ID"),
                    new GridColumn("Username", true, true, false, false),
                    new GridColumn("Password", false, false, false, false, CellRenderer: "passwordFormatterComponent"),
                    new GridColumn("Email", true, true, false, false),
                    new GridColumn("Telephone", true, true, false, false),
                    new GridColumn("FirstName", true, true, false, false),
                    new GridColumn("LastName", true, true, false, false),
                    new GridColumn("Role", true, true, false, false, CellEditor: "agSelectCellEditor"),
                }
            }
        };
    }
}
