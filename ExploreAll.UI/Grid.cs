using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ExploreAll;
using Newtonsoft.Json;

namespace ExploreAll.UI
{
    [ToolboxData("<{0}:Grid runat=server></{0}:Grid>")]
    public class Grid: TemplateControl
    {
        [Bindable(true)]
        [Category("Appearance")] 
        [Localizable(true)]
        public string GridStyle { get; set; }
        public string WrapperCssClass { get; set; }
        public string DataSource { get; set; }
        public bool Editable { get; set; }

        protected HtmlGenericControl gridWrapper;
        protected HtmlGenericControl GridDiv;
        protected HtmlGenericControl AddRecord;
        protected HtmlGenericControl RemoveRecord;
        protected HtmlGenericControl UpdateGrid;
        protected HtmlGenericControl controlWrapper;

        protected override void CreateChildControls()
        {
            gridWrapper = new HtmlGenericControl("div");
            gridWrapper.Attributes.Add("class", WrapperCssClass);

            if (Editable)
            {
                controlWrapper = new HtmlGenericControl("div");
                controlWrapper.Attributes.Add("class", "gridControls");

                AddRecord = new HtmlGenericControl("button");
                AddRecord.Attributes.Add("type", "button");
                AddRecord.Attributes.Add("onclick", $"exploreall.addGridRecord({ID}gridOptions, {ID}newRecords)");
                AddRecord.InnerText = "New";
                controlWrapper.Controls.Add(AddRecord);

                RemoveRecord = new HtmlGenericControl("button");
                RemoveRecord.Attributes.Add("type", "button");
                RemoveRecord.Attributes.Add("onclick", $"exploreall.removeGridRecord({ID}gridOptions, {ID}deletedRecords)");
                RemoveRecord.InnerText = "Delete";
                controlWrapper.Controls.Add(RemoveRecord);

                UpdateGrid = new HtmlGenericControl("button");
                UpdateGrid.Attributes.Add("type", "button");
                UpdateGrid.Attributes.Add("onclick", $"exploreall.updateGrid({ID}gridOptions, {ID}newRecords, {ID}deletedRecords, {ID}columns, '{DataSource}')");
                UpdateGrid.InnerText = "Save";
                controlWrapper.Controls.Add(UpdateGrid);

                gridWrapper.Controls.Add(controlWrapper);
            }

            GridDiv = new HtmlGenericControl("div");
            GridDiv.ID = ID;
            GridDiv.Attributes.Add("class", "ag-theme-" + GridStyle);
            GridDiv.Attributes.Add("data-source", DataSource);

            gridWrapper.Controls.Add(GridDiv);
            Controls.Add(gridWrapper);

            DataTable dt = DBSupport.GetData(DataSource);

            List<string> columns = TableEntities.TableColumns[DataSource];
            List<object> rowData = new List<object>();
            List<string> columnDefs = new List<string>();

            foreach(DataRow data in dt.Rows)
            {
                string rd = "{";
                for (int i = 0; i < columns.Count; i++)
                {
                    rd += columns[i] + ": '" + data[i] + "',";
                }
                rd = rd.Remove(rd.Length - 1) + "}";
                rowData.Add(rd);
            }

            foreach(string col in columns)
            {
                columnDefs.Add(@"{field: '" + col + "', editable: true, filter: true}");
            }

            string jsinitialization = @"var " + ID + "columnDefs = " + JsonConvert.SerializeObject(columnDefs).Replace("\"", "") + @";
                var " + ID + "rowData = " + JsonConvert.SerializeObject(rowData).Replace("\"", "") + @";
                var " + ID + "columns = [" + JsonConvert.SerializeObject(columns).Remove(0,1).Remove(JsonConvert.SerializeObject(columns).Length-2) + @"];
                var " + ID + @"newRecords = [];
                var " + ID + @"deletedRecords = [];
                const " + ID + "gridOptions = { columnDefs: " + ID + "columnDefs, rowData: " + ID + "rowData , rowSelection: 'single',  pagination: true}" + @";
                exploreall.setupGrid(" + ID + "gridOptions, " + ID + ", '" + Editable + "');";
            registerJavaScript(jsinitialization);
        }

        public void registerJavaScript(string jsinitialization)
        {
            ScriptManager scr = ScriptManager.GetCurrent(Page);

            if ((scr != null) && (scr.IsInAsyncPostBack))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), jsinitialization, true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), this.ClientID + "_startup", jsinitialization, true);
            }
        }
    }
}
