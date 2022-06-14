var exploreall = {};

exploreall.setupGrid = function (options, grid, controls) {
    document.addEventListener('DOMContentLoaded', () => {
        new agGrid.Grid(grid, options);
        options.api.sizeColumnsToFit();
        if (controls.toLowerCase() == "true") {
            var gridControls = grid.parentElement.querySelector(".gridControls");
            grid.querySelector(".ag-paging-panel").appendChild(gridControls);
        }
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