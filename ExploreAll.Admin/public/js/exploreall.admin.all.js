var exploreall = {};

exploreall.selectEditorParams = [
    {
        key: 'Role',
        values: null
    },
    {
        key: 'Subscription',
        values: null
    },
    {
        key: 'Host',
        values: null
    }
];

exploreall.hostCountries = {
    "limnos.exploreall.gr": "Greece",
    "localhost": "Greece"
}

exploreall.setupGrid = function (source, controls, gridObj) {
    var gridElem = document.getElementById(gridObj.Id);
    var data = { DataSource: source };
    var suc = function (res, gridDiv, ctls, gridObject) { 
        ctls = (ctls.toLowerCase() === 'true');

        if (res.d) {
            gridObject.gridOptions = JSON.parse(res.d);

            if (ctls)
                var gridControls = gridDiv.parentElement.querySelector(".gridControls");
                
            gridDiv.innerHTML = "";
            gridObject.gridOptions.components = {
                fileUploaderComponent: FileUploaderComponent,
                passwordFormatterComponent: PasswordFormatterComponent,
                checkboxRenderer: CheckboxRenderer
            };

            exploreall.selectEditorParams.find(x => x.key == "Role").values = gridObject.gridOptions.cellEditorRoleValues;
            exploreall.selectEditorParams.find(x => x.key == "Subscription").values = gridObject.gridOptions.cellEditorSubscriptionValues;
            exploreall.selectEditorParams.find(x => x.key == "Host").values = gridObject.gridOptions.cellEditorHostValues;
                        
            for (var i = 0; i < gridObject.gridOptions.columnDefs.length; i++) {
                var cellEditorParams = exploreall.selectEditorParams.find(x => x.key == gridObject.gridOptions.columnDefs[i].field);
                if (cellEditorParams)
                    gridObject.gridOptions.columnDefs[i].cellEditorParams = {
                        values: cellEditorParams.values
                    }
                if (gridObject.gridOptions.columnDefs[i].valueFormatter) {
                    gridObject.gridOptions.columnDefs[i].valueFormatter = exploreall.countryFormatter;
                }
                if (!ctls) {
                    gridObject.gridOptions.columnDefs[i].editable = false;
                    gridObject.gridOptions.columnDefs[i].hasControls = false;
                } 
                else 
                    gridObject.gridOptions.columnDefs[i].hasControls = true;
            }

            for (var i = 0; i < gridObject.gridOptions.rowData.length; i++) {
                gridObject.gridOptions.rowData[i] = JSON.parse(gridObject.gridOptions.rowData[i]);
            }
            new agGrid.Grid(gridDiv, gridObject.gridOptions);
            gridObject.gridOptions.api.sizeColumnsToFit();

            if (ctls) {
                gridDiv.querySelector(".ag-paging-panel").appendChild(gridControls);
                gridControls.style.display = "block";
            }
        }
    }
  
    $.ajax({
        type: "POST",
        url: "ExploreAllAdmin.aspx/RefreshGrid",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (res) {
            exploreall.endProgress();
            suc(res, gridElem, controls, gridObj);
        },
        error: function (res) {
            exploreall.endProgress();
            //window.location.reload();
        },
    });
} 

exploreall.addGridRecord = function (gridObj) {
    gridObj.newRecords.push(gridObj.gridOptions.rowData.length);
    gridObj.gridOptions.api.applyTransaction({ add: [{ Id: gridObj.gridOptions.rowData.length }] });
}

exploreall.removeGridRecord = function (gridObj) {
    const sel = gridObj.gridOptions.api.getSelectedRows();
    gridObj.deletedRecords.push(sel[0].Id);
    gridObj.gridOptions.api.applyTransaction({ remove: sel });
}

exploreall.getRowData = function (grid) {
    const rowData = [];
    grid.api.forEachNode(function (node) {
        for (let i = 0; i < Object.keys(node.data).length; i++) {
            node.data[Object.keys(node.data)[i]] = Object.values(node.data)[i].replace('"', '\"');
        }
        rowData.push(node.data);
        debugger;
    });

    return rowData;
}

exploreall.updateGrid = function (gridObj, table, controls) {
    //grid.rowData contains the grid data
    var data = {
        gridData: null,
        newRecords: gridObj.newRecords,
        oldRecords: gridObj.deletedRecords,
        columns: gridObj.columns,
        dataSource: table
    }

    data.gridData = JSON.stringify(exploreall.getRowData(gridObj.gridOptions));

    $.ajax({
        type: "POST",
        url: "ExploreAllAdmin.aspx/UpdateGrid",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (res) {
            exploreall.endProgress();
            suc(res, table, controls, gridObj);
            exploreall.notify("Operation successful.");
        },
        error: function (res) {
            exploreall.endProgress();
            fail(res, table, controls, gridObj);
            exploreall.notify("Operation failed.", true);
        },
    });

    var suc = function (res, source, ctrls, gridObject) {
        if (res.d.success)
            alert("Operation succesfully completed.");

        exploreall.setupGrid(source, ctrls, gridObject);
    }

    var fail = function (res, source, ctrls, gridObject) {
        if(res.d)
            alert(res.d.message);

        exploreall.setupGrid(source, ctrls, gridObject);
    }

    gridObj.newRecords = [];
    gridObj.deletedRecords = [];
}

exploreall.startProgress = function() {
    
}

exploreall.endProgress = function () {

}

exploreall.PageMethod = function (path, paramArray, successFn, errorFn) {
    exploreall.startProgress();

    var callsuccess = successFn;
    var callerror = errorFn;

    //Call the page method
    $.ajax({
        type: "POST",
        url: path,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(paramArray),
        dataType: "json",
        success: function (res) {
            exploreall.endProgress();
            if (callsuccess) {
                callsuccess(res);
            }
            exploreall.notify("Operation successful.");
        },
        error: function (res, statusText, errorThrown) {
            exploreall.endProgress();            
            if (callerror) {
                callerror(res);
            }
            exploreall.notify("Operation failed.", true);
        },
    });
};

exploreall.notify = function (msg, error = false) {
    var notifWrapper = document.createElement("div");
    notifWrapper.classList.add("notification-top-bar");

    var notification = document.createElement("p");
    notification.innerText = msg;

    if (error)
        notifWrapper.classList.add("error");

    notifWrapper.appendChild(notification);
    document.querySelector(".dashboard-wrapper").prepend(notifWrapper);

    setTimeout(function () {
        notifWrapper.remove();
    }, 4000);
}

exploreall.countryFormatter = function (params) {
    console.log(params);
    switch (params.colDef.field) {
        case "Country":
            return exploreall.hostCountries[window.location.hostname];
    }
}