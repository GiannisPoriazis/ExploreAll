class PasswordFormatterComponent {
    // gets called once before the renderer is used
    init(params) {
        // create the cell
        this.eGui = document.createElement('input');
        this.eGui.setAttribute("readonly", true);
        this.eGui.style.border = "none";
        this.eGui.style.outline = "none";
        this.eGui.value = "";
        if (params.data[params.colDef.field]) {
            for (var i = 0; i < params.data[params.colDef.field].length; i++) {
                this.eGui.value += '*';
            }
        }

        if (params.colDef.hasControls) {
            this.eGui.addEventListener("dblclick", function (e) {
                e.target.removeAttribute("readonly");
                e.target.value = "";
                e.target.focus();
            });
        }

        this.eGui.addEventListener("change", function (e) {
            params.data[params.column.colId] = e.target.value;
            e.target.blur();
            e.target.setAttribute("readonly", true);
            e.target.value = "";
            for (var i = 0; i < params.data[params.colDef.field].length; i++) {
                e.target.value += '*';
            }
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