function CheckAllCheckBox(selectAllCheckbox, gridViewId) {
    $('td :checkbox:enabled', gridViewId).prop("checked", selectAllCheckbox.checked);
}
function UnCheckSelectAll(selectCheckbox, gridViewId) {
    if (!selectCheckbox.checked)
        $('th :checkbox', gridViewId).prop("checked", false);
}

function ConfirmDelete(gridViewId) {
    var count = 0;
    $('input:checkbox[id*=cbSelect]:checked', gridViewId).each(function (item, index) {
        count = count + 1;
    });

    if (count == 0) {
        alert("No records to delete.");
        return false;
    }
    else {
        return confirm("Do you want to delete " + count + " records.");
    }

}
