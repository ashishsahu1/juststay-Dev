var strencrypt;
$(document).ready(function () {
	"use strict";	
	//MEGA MENU	
    $(".about-menu").hover(function() {
        $(".about-mm").fadeIn();
    });
    $(".about-menu").mouseleave(function() {
        $(".about-mm").fadeOut();
    });
    //MEGA MENU	
    $(".admi-menu").hover(function() {
        $(".admi-mm").fadeIn();
    });
    $(".admi-menu").mouseleave(function() {
        $(".admi-mm").fadeOut();
    });
    //MEGA MENU	
    $(".cour-menu").hover(function() {
        $(".cour-mm").fadeIn();
    });
    $(".cour-menu").mouseleave(function() {
        $(".cour-mm").fadeOut();
    });
    //SINGLE DROPDOWN MENU
    $(".top-drop-menu").on('click', function() {
        $(".man-drop").fadeIn();
    });
    $(".man-drop").mouseleave(function() {
        $(".man-drop").fadeOut();
    });
    $(".wed-top").mouseleave(function() {
        $(".man-drop").fadeOut();
    });

    //SEARCH BOX
    $("#sf-box").on('click', function() {
        $(".sf-list").fadeIn();
    });
    $(".sf-list").mouseleave(function() {
        $(".sf-list").fadeOut();
    });
    $(".search-top").mouseleave(function() {
        $(".sf-list").fadeOut();
    });
    $('.sdb-btn-edit').hover(function() {
        $(this).text("Click to edit my profile");
    });
    $('.sdb-btn-edit').mouseleave(function() {
        $(this).text("edit my profile");
    }); 
    //MOBILE MENU OPEN
    $(".ed-micon").on('click', function() {
        $(".ed-mm-inn").addClass("ed-mm-act");
    });
    //MOBILE MENU CLOSE
    $(".ed-mi-close").on('click', function() {
        $(".ed-mm-inn").removeClass("ed-mm-act");
    });

    //GOOGLE MAP IFRAME
    $('.map-container').on('click', function() {
        $(this).find('iframe').addClass('clicked')
    }).on('mouseleave', function() {
        $(this).find('iframe').removeClass('clicked')
    });

    $('#status').fadeOut();
    $('#preloader').delay(350).fadeOut('slow');
    $('body').delay(350).css({
        'overflow': 'visible'
    });

    //MATERIALIZE SELECT DROPDOWN
    $('select').material_select();
	//MATERIALIZE SLIDER
    $('.slider').slider();
   

    setTimeout(function () {
        $('#divresendbtn').css("display", "block");
    }, 10000);
   
});

function myFunction() {
    var input, filter, table, tr, td, i;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//DATE PICKER	
$(function() {
    var dateFormat = "mm/dd/yy",
        from = $("#ContentPlaceHolder1_from")
        .datepicker({
            defaultDate: new Date(),
            changeMonth: false,
            numberOfMonths: 1,
            minDate: new Date(),
            maxDate: "+1w",
        })
        .on("change", function() {
            to.datepicker("option", "minDate", getDate(this));
        }),
        to = $("#to,#to-1,#to-2,#to-3,#to-4,#to-5").datepicker({
            defaultDate: "+1w",
            changeMonth: false,
            numberOfMonths: 1
        })
        .on("change", function() {
            from.datepicker("option", "maxDate", getDate(this));
        });

   

    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
        }

        return date;
    }
});

//validation ob SignUp
function ValidateSignUp(ContentPlaceHolder1_txtUsername, ContentPlaceHolder1_txtUserMobile) {
    var txtvalues = '#' + ContentPlaceHolder1_txtUsername + ', #' + ContentPlaceHolder1_txtUserMobile;

    var isValid = true;
    $(txtvalues).each(function () {
        if ($.trim($(this).val()) == '') {
            isValid = false;
            $(this).css({
                "border": "1px solid red",
                "background": "#FFCECE"
            });
        }
        else {
            $(this).css({
                "border": "",
                "background": ""
            });
        }
    });

    return isValid;
}

//vslidation SignIn
function CheckSignInValidation(ContentPlaceHolder1_txtMobile, ContentPlaceHolder1_txtPassword) {
    var txtvalues = '#' + ContentPlaceHolder1_txtMobile + ', #' + ContentPlaceHolder1_txtPassword;

    var isValid = true;
    $(txtvalues).each(function () {
        if ($.trim($(this).val()) == '') {
            isValid = false;
            $(this).css({
                "border": "1px solid red",
                "background": "#FFCECE"
            });
        }
        else {
            $(this).css({
                "border": "",
                "background": ""
            });
        }
    });

    return isValid;
}

//check email exist
function CheckEmailExist(emailTextId, spanid, userTypeId) {

    var email = $('#' + emailTextId).val();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/BusinessLogic/ValidateData.ashx?mode=email&value=" + email + "&userTypeId=" + userTypeId,
        async: false,
        success: function (response) {
            if (response == "True") {
                $('#' + emailTextId).val('');
                $('#' + spanid).text('Email Already Exist');
                $('#' + spanid).css("display", "block");
            }
            else {
                $('#' + spanid).css("display", "none");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            return false;
        }
    });
}
//check mobile exist
function CheckMobileExist(mobileid, spanid) {

    var mobile = $('#' + mobileid).val();
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/BusinessLogic/ValidateData.ashx?mode=mobile&value=" + mobile + "&userTypeId=3",
        async: false,
        success: function (response) {
            if (response == "True") {
                $('#' + mobileid).val('');
                $('#' + spanid).css("display", "block");
            }
            else {
                $('#' + spanid).css("display", "none");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            return false;
        }
    });
}
//validate verify otp
function ValidateVerifyOTP(ContentPlaceHolder1_txtOTP, ContentPlaceHolder1_txtPassword, ContentPlaceHolder1_txtConfirmPassword) {
    var txtvalues = '#' + ContentPlaceHolder1_txtOTP + ', #' + ContentPlaceHolder1_txtPassword + ', #' + ContentPlaceHolder1_txtConfirmPassword;

    var isValid = true;
    $(txtvalues).each(function () {
        if ($.trim($(this).val()) == '') {
            isValid = false;
            $(this).css({
                "border": "1px solid red",
                "background": "#FFCECE"
            });
        }
        else {
            $(this).css({
                "border": "",
                "background": ""
            });
        }
    });

    return isValid;
}
//validate password
function ValidatePassword(ContentPlaceHolder1_txtOTP, ContentPlaceHolder1_txtPassword, ContentPlaceHolder1_txtConfirmPassword, spanid) {
    var isValid = ValidateVerifyOTP(ContentPlaceHolder1_txtOTP, ContentPlaceHolder1_txtPassword, ContentPlaceHolder1_txtConfirmPassword);
    debugger;
    if (isValid) {
        if ($('#' + ContentPlaceHolder1_txtPassword).val() != $('#' + ContentPlaceHolder1_txtConfirmPassword).val()) {
            $('#' + ContentPlaceHolder1_txtPassword).val('');
            $('#' + ContentPlaceHolder1_txtConfirmPassword).val('');
            $('#' + spanid).css("display", "block");
            isValid = false;
        }
        else {
            $('#' + spanid).css("display", "none");

        }
    }
    return isValid;
}

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}
function showPosition(position) {
    $("#ContentPlaceHolder1_hdFromLat").val(position.coords.latitude);
    $("#ContentPlaceHolder1_hdFromLng").val(position.coords.longitude);
    $("#ContentPlaceHolder1_txtfrom").val('Current Location');
}

//validation on serach button
//function ValidateSearch() {
//    var isValid = true;
//    $("#ContentPlaceHolder1_txtfrom,#ContentPlaceHolder1_txtTO,#ContentPlaceHolder1_from,#ContentPlaceHolder1_timepicker,#ContentPlaceHolder1_drpperson").each(function () {
//        if ($.trim($(this).val()) == "" || $.trim($(this).val()) == null) {
//            isValid = false;
//            $(this).css({
//                "border": "0.1px solid #EF5555"
//            });
//        }
//        else {
//            $(this).css({
//                "border": ""
//            });
//        }
//    });
   
//    return isValid;
//}
function SetTarget() {
    document.forms[0].target = "_blank";
}
function getUrlParam(name) {
    var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return (results && results[1]) || undefined;
}

 function Enpt(data) {
   $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/BusinessLogic/ValidateData.ashx?mode=enq&value=" + data,
        async: false,
        success: function (response) {
            strencrypt = response;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            return '';
        }
   });
   return strencrypt;
}



