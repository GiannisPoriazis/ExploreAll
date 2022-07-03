class FileUploaderComponent {
    // gets called once before the renderer is used
    init(params) {
        // create the cell
         this.eGui = document.createElement('div');
        if (!params.value) {
            if (params.data[params.colDef.field])
                this.eGui.innerHTML = "<span><button type='button' class='btn-simple'>" + params.data[params.colDef.field] + "</button></span>";
            else
                this.eGui.innerHTML = "<span><button type='button' class='btn-simple'>No file selected</button></span>";
        }
        else {
            this.eGui.innerHTML = "<span><button type='button' class='btn-simple'>" + params.value + "</button></span>";
        }
        
        // get references to the elements we want
        this.eButton = this.eGui.querySelector('.btn-simple');

        // add event listener to button
        this.eventListener = () => this.initFileUpload(params);
        this.eButton.addEventListener('click', this.eventListener);
    }

    initFileUpload(params) {
        $("#FileUploader").click().unbind("change").on("change", () => {
            UploadFile(this, params);
        });
    }

    getGui() {
        return this.eGui;
    }

    // gets called whenever the cell refreshes
    refresh(params) {
        // set value into cell again
        this.cellValue = this.getValueToDisplay(params);
        this.eValue.innerHTML = this.cellValue;

        // return true to tell the grid we refreshed successfully
        return true;
    }

    // gets called when the cell is removed from the grid
    destroy() {
        // do cleanup, remove event listener from button
        if (this.eButton) {
            // check that the button element exists as destroy() can be called before getGui()
            this.eButton.removeEventListener('click', this.eventListener);
        }
    }

    getValueToDisplay(params) {
        return params.valueFormatted ? params.valueFormatted : params.value;
    }
}

toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});

UploadFile = async (gridRow, params) => {
    exploreall.startProgress();

    var file = await toBase64(document.querySelector("#FileUploader").files[0]);
    var data = {
        FileUri: file
    }
    var suc = (res, row, prms) => {
        if (res.d) { 
            row.eGui.querySelector('.btn-simple').innerHTML = res.d;
            prms.data[prms.column.colId] = res.d;
        } 
    }

    $.ajax({
        type: "POST",
        url: "ExploreAllAdmin.aspx/UploadSingleFile",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (res) {
            exploreall.endProgress();
            suc(res, gridRow, params);
        },
        error: function (res) {
            exploreall.endProgress();  
            console.log(res);
        },
    });
};