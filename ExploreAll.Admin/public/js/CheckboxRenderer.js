class CheckboxRenderer {

    init(params) {
        this.params = params;

        this.eGui = document.createElement('input');
        this.eGui.type = 'checkbox';
        this.eGui.checked = false;

        if (params.data[params.colDef.field]) {
            if (params.value != 0 && params.value != 1)
                this.eGui.checked = params.value.toLowerCase() === 'true';
            else
                this.eGui.checked = params.value == 0 ? false : true;
        }

        params.data[params.column.colId] = this.eGui.checked ? 1 : 0;

        if (params.colDef.hasControls) {
            this.eGui.addEventListener("click", function (e) {
                let checked = e.target.checked;
                let colId = params.column.colId;
                params.data[colId] = checked ? 1 : 0;
                console.log(params.data[colId]);
            });
        }
        else
            this.eGui.disabled = true;
    }

    getGui() {
        return this.eGui;
    }
}