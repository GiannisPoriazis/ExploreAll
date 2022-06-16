var exploreall = {};

exploreall.setupGrid = function (source, grid, controls) {
    document.addEventListener('DOMContentLoaded', () => {
        var data = { DataSource: source };

        var suc = function (res, gridDiv, ctls) {
            if (res.d) {
                gridDiv.innerHtml = "";
                var options = JSON.parse(res.d);
                for (var i = 0; i < options.columnDefs.length; i++) {
                    options.columnDefs[i] = JSON.parse(options.columnDefs[i]);
                }
                for (var i = 0; i < options.rowData.length; i++) {
                    options.rowData[i] = JSON.parse(options.rowData[i]);
                }
                new agGrid.Grid(gridDiv, options);
                options.api.sizeColumnsToFit();
                if (ctls.toLowerCase() == "true") {
                    var gridControls = gridDiv.parentElement.querySelector(".gridControls");
                    gridDiv.querySelector(".ag-paging-panel").appendChild(gridControls);
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
                suc(res, grid, controls);
            },
            error: function (res) {
                exploreall.endProgress();
                //window.location.reload();
            },
        });
    });
} 

exploreall.addGridRecord = function (grid, createdRecords) {
    createdRecords.push(grid.rowData.length);
    grid.api.applyTransaction({ add: [{ Id: grid.rowData.length }] });
}

exploreall.removeGridRecord = function (grid, removeRecords) {
    const sel = grid.api.getSelectedRows();
    removeRecords.push(sel[0].Id);
    grid.api.applyTransaction({ remove: sel });
}

exploreall.getRowData = function (grid) {
    const rowData = [];
    grid.api.forEachNode(function (node) {
        rowData.push(node.data);
    });

    return rowData;
}

exploreall.updateGrid = function (grid, createdRecords, removedRecords, columnHeaders, table) {
    //grid.rowData contains the grid data
    var data = {
        gridData: null,
        newRecords: createdRecords,
        oldRecords: removedRecords,
        columns: columnHeaders,
        dataSource: table
    }

    data.gridData = JSON.stringify(exploreall.getRowData(grid));

    var suc = function (res) {
        if (res.d.success)
            alert("Operation succesfully completed.");

        location.reload();
    }

    var fail = function (res) {
        if(res.d)
            alert(res.d.message);

        location.reload();
    }

    exploreall.PageMethod("ExploreAllAdmin.aspx/UpdateGrid", data, suc, fail);
    createdRecords = [];
    removedRecords = [];
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