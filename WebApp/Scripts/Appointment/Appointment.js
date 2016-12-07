﻿
var _objAppointment = {}; //appointment data to hold and save at the end
var _objPharmacy = {}; //pharmacy data to hold and save at the end
var _selecteddoctorID;
var myappTime;
function uploadFiles() {
    var form = $('#mydropzone')[0];
    var dataString = new FormData(form);
    $.ajax({
        url: '/SeeDoctor/UploadFiles',  //Server script to process data
        type: 'POST',
        xhr: function () {  // Custom XMLHttpRequest
            var myXhr = $.ajaxSettings.xhr();
            if (myXhr.upload) { // Check if upload property exists
                //myXhr.upload.onprogress = progressHandlingFunction
                myXhr.upload.addEventListener('progress', progressHandlingFunction,
				false); // For handling the progress of the upload
            }
            return myXhr;
        },
        //Ajax events
        success: successHandler,
        error: errorHandler,
        complete: completeHandler,
        // Form data
        data: dataString,
        //Options to tell jQuery not to process data or worry about content-type.
        cache: false,
        contentType: false,
        processData: false
    });
}
function setDateTime(myappTime,myappDate)
{
   
    _objAppointment["appDate"] = myappDate;
    _objAppointment["appTime"] = myappTime;
    _selecteddoctorID = $("#doctorid").val();
    $('#myModal1').modal('hide');
    $('#wizard').smartWizard('goToStep', 2);
    if ($("#wizard").smartWizard('currentStep', '2')) {
        //alert('2');
        $('.buttonNext').show();
        $('.buttonPrevious').show();

    }
    showDoctorInfo();
    //showApppointmentSummary(myappTime, myappDate);
    return false;
   // $('#step-2').show();
}
function showDoctorInfo()
{
    var tableHtml = "";
    $.ajax({
        type: 'POST',
        //url: '@Url.Action("GetAllLanguages", "SeeDoctor")',
        url: '/SeeDoctor/FetchDoctoInfo',
        data:{'doctorID': _selecteddoctorID},
        dataType: 'json',
        success: function (response) {
            var spec = "";
               
            $.each(response.Object, function (item) {
                spec = spec+response.Object[item].specialityName +",";
          
            });
            var lang = "";

            $.each(response.Object, function (item) {
                lang = lang + response.Object[item].languageName + ",";

            });
           
            var specresult = spec.substring(0, spec.length - 1);
            var langresult = lang.substring(0, lang.length - 1);
            var doccell = "";
            var docemail = "";
            var cc = "";
            var docstate = "";
            if (response.Object[0].cellPhone != null) { doccell = response.Object[0].cellPhone; }
            if (response.Object[0].email != null) { docemail = response.Object[0].email; }
            if (response.Object[0].consultCharges != null) { cc = response.Object[0].consultCharges; }
            if (response.Object[0].state != null) { docstate = response.Object[0].state; }
            tableHtml = "<address>" +
                     "<strong>Dr. " + response.Object[0].doctorName + " (" + response.Object[0].gender + ")</strong>" +
                     "<br><strong>Specaility: </strong>&nbsp;" + specresult +
                     "<br><strong>Languages: </strong>&nbsp;" + langresult +
                     "<br><strong>State: </strong>&nbsp;" + docstate +
                     "<br><strong>Phone: </strong>&nbsp;" + doccell +
                     "<br><strong>Email: </strong>&nbsp; " + docemail +
                     "<br><strong>Consult Charges: </strong>&nbsp; " + cc +
                      "</address>";
            document.getElementById("docInfo").innerHTML = tableHtml;
        },
        error: errorRes

    });
   
}
function showApppointmentSummary() {
    var ROV = $("#ROV option:selected").text()
    if (ROV == "Choose ROV") {

        ROV = "";
    }
   // _objAppointment["appDate"] = myappDate;
   // _objAppointment["appTime"] = myappTime;
    customDateFormat(_objAppointment["appDate"]);
    var tableHtml = "<address>" +
                     "<strong>Date: </strong>&nbsp;" + customDateFormat(_objAppointment["appDate"]) +
                     "<br><strong>Time:</strong>&nbsp;" + _objAppointment["appTime"] +
                     "<br><strong>Reason for Visit: </strong>&nbsp;" + ROV +
                     "<br><strong>Chief Complaints: </strong>&nbsp;" + $("#chiefcomplaints").val() +
                     "<br><strong>Pharmacy: </strong>&nbsp;" + $("#pharmacy").val() +
                    "</address>";
                    document.getElementById("appsummary").innerHTML = tableHtml;
       

}
function customDateFormat(s) {

    var b = s.split(/\D/);
    
    var d = new Date(b[2], --b[1], b[0]);

    // Replace with day names in appropriate language
    var days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday',
                'Thursday', 'Friday', 'Saturday'];

    // Replace with month names in appropriate language
    var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July',
                  'August', 'September', 'October', 'November', 'December'];

    // Helper for padding single digit values
    function z(n) { return (n < 10 ? '0' : '') + n; }
   
    return days[d.getDay()] + ' ' + d.getDate() + ' ' +
           months[d.getMonth()] + ' ' + d.getFullYear();
}
function CreateAppointment(patientID) {
    
    _objAppointment["appDate"] = $("#fetchdate").val();
    _objAppointment["doctorID"] = $("#doctorid").val();
    _objAppointment["patientID"] = patientID;
    _objAppointment["rov"] = $("#ROV option:selected").text();
    _objAppointment["chiefComplaints"] = $("#chiefcomplaints").val();
    


    $.ajax({
        type: 'POST',
        url: '/SeeDoctor/SaveAppointment',
        data: JSON.stringify(_objAppointment),
        contentType: "application/json",
        dataType: 'json',
        success: function (response) {

            if (response.Success == true) {
                if (response.ApiResultModel.message != "") {
                    new PNotify({
                        title: 'Error',
                        text: response.ApiResultModel.message,
                        type: 'error',
                        styling: 'bootstrap3'
                    });
                }
                else if (response.ApiResultModel.message == "") {
                    new PNotify({
                        title: 'Success',
                        text: "Appointment is scheduled successfully.",
                        type: 'success',
                        styling: 'bootstrap3'
                    });

                }



            }

        },
        error: errorRes

    });

}
function AddUpdatePharmacy(patientID,pharmacy) {

    _objPharmacy["patientID"] = patientID;
    _objPharmacy["pharmacy"] = pharmacy;//$("#pharmacy").val();
    _objAppointment["pharmacyid"] = 1;//$("#pharmacyid").val();


    $.ajax({
        type: 'POST',
        url: '/SeeDoctor/AddUpdatePharmacy',
        data: _objPharmacy,
        dataType: 'json',
        success: function (response) {
            if (response.Success == true) {
                if (response.ApiResultModel.message != "") {
                    new PNotify({
                        title: 'Error',
                        text: response.ApiResultModel.message,
                        type: 'error',
                        styling: 'bootstrap3'
                    });
                }
                else if (response.ApiResultModel.message == "") {
                    new PNotify({
                        title: 'Success',
                        text: "Pharmacy is saved successfully.",
                        type: 'success',
                        styling: 'bootstrap3'
                    });
                   
                }



            }
           
        },
        error: errorRes

    });

}

function errorRes(data) {
     new PNotify({
        title: 'Error',
        text: data.Message,
        type: 'error',
        styling: 'bootstrap3'
    });
}