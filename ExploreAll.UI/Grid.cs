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
                AddRecord.Attributes.Add("onclick", $"exploreall.addGridRecord({ID})");
                AddRecord.InnerText = "New";
                controlWrapper.Controls.Add(AddRecord);

                RemoveRecord = new HtmlGenericControl("button");
                RemoveRecord.Attributes.Add("type", "button");
                RemoveRecord.Attributes.Add("onclick", $"exploreall.removeGridRecord({ID})");
                RemoveRecord.InnerText = "Delete";
                controlWrapper.Controls.Add(RemoveRecord);

                UpdateGrid = new HtmlGenericControl("button");
                UpdateGrid.Attributes.Add("type", "button");
                UpdateGrid.Attributes.Add("onclick", $"exploreall.updateGrid({ID}, '{DataSource}',{Editable.ToString().ToLower()})");
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

            List<string> columns = new List<string>();

            foreach (TableEntities.GridColumn col in TableEntities.TableColumns[DataSource])
            {
                columns.Add(col.field);
            }

            string jsinitialization = @"var " + ID + @" = {
                Id: '" + ID + @"',
                columns: [" + JsonConvert.SerializeObject(columns).Remove(0, 1).Remove(JsonConvert.SerializeObject(columns).Length - 2) + @"],
                newRecords: [],
                deletedRecords: [],
                gridOptions: null};
                exploreall.setupGrid('" + DataSource + "', '" + Editable + "', " + ID + ");";
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
