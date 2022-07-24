var exploreall = {};

exploreall.selectEditorParams = [
    {
        key: 'Role',
        values: null
    }
];

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
                passwordFormatterComponent: PasswordFormatterComponent
            };

            exploreall.selectEditorParams.find(x => x.key == "Role").values = gridObject.gridOptions.cellEditorParamValues;
                        
            for (var i = 0; i < gridObject.gridOptions.columnDefs.length; i++) {
                var cellEditorParams = exploreall.selectEditorParams.find(x => x.key == gridObject.gridOptions.columnDefs[i].field);
                if (cellEditorParams)
                    gridObject.gridOptions.columnDefs[i].cellEditorParams = {
                        values: cellEditorParams.values
                    }
                if (!ctls)
                    gridObject.gridOptions.columnDefs[i].editable = false;
            }

            for (var i = 0; i < gridObject.gridOptions.rowData.length; i++) {
                gridObject.gridOptions.rowData[i] = JSON.parse(gridObject.gridOptions.rowData[i]);
            }
            new agGrid.Grid(gridDiv, gridObject.gridOptions);
            gridObject.gridOptions.api.sizeColumnsToFit();

            if (ctls)
                gridDiv.querySelector(".ag-paging-panel").appendChild(gridControls);
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
        rowData.push(node.data);
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
        },
        error: function (res) {
            exploreall.endProgress();
            fail(res, table, controls, gridObj);
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
        },
        error: function (res, statusText, errorThrown) {
            exploreall.endProgress();            
            if (callerror) {
                callerror(res);
            }
        },
    });
};