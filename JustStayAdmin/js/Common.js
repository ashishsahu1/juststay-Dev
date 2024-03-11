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


function ValidateImageFile(value) {
    debugger;
    var file = getNameFromPath($(value).val());
    if (file != null) {
        var extension = file.substr((file.lastIndexOf('.') + 1));
        switch (extension) {
            case 'jpg':
            case 'JPG':
            case 'jpeg':
            case 'JPEG':
            case 'png':
            case 'PNG':
            case 'bmp':
            case 'BMP':
            case 'gif':
            case 'GIF':
                flag = true;
                break;
            default:
                flag = false;
        }
    }

    var data = "sp_" + value.id;

    if (flag == false) {

        $("#" + data).text("You can upload only jpg, jpeg, png, bmp and gif extension file Only");
        $("#" + value.id).val('');
        return false;
    }
    else {
        $("#" + data).text("");
    }
}

function getNameFromPath(strFilepath) {
    var objRE = new RegExp(/([^\/\\]+)$/);
    var strName = objRE.exec(strFilepath);

    if (strName == null) {
        return null;
    }
    else {
        return strName[0];
    }
}

