var EmployeeDetails = {};
$(document).ready(function () {
    HideDiv();
    $body = $("body");
    $("#getAllEmpData").click(function () {
        GetEmployee(1);
        HideDiv();
    });
});

function HideDiv() {
    $("#div_getAllEmpData").hide();
    $("#div_AverageCalculations").hide();
    $("#div_ErrorMessage").hide();
    $("#loader").hide();
}

function GetEmployee(value) {
    //$.support.cors = true;
    $.ajax({
        url: '../api/Employee/GetAllEmployee',
        headers: {
            "Accept": "application/json",
            "Access-Control-Allow-Origin": "*"
        },
        type: "GET",
        dataType: 'json',
        contentType: "application/json",
        beforeSend: function () {
            // Show image container
            // $body.addClass("loading");
            $body.addClass("loading");
        },
        success: function (response) {
            //console.log(response); 
            EmployeeDetails = response;
            if (response.status !== null && value === 1)
                BindEmployeeDetailsTable(response);
            if (response.status !== null && value === 2)
                CalculateAverages(response);
            if (response.status == null) {
                HideDiv();
                $("#div_ErrorMessage").show();
            }
        },
        error: function (error) {
            console.log("Something went wrong", error);
        },
        complete: function (data) {
            // Hide image container
            //$body.removeClass("loading");
            $body.removeClass("loading");
        }
    });
}

function BindEmployeeDetailsTable(Employee) {
    $("#div_getAllEmpData").show();
    $('#tblAllEmployee').show();

    //$.noConflict();
    if ($.fn.DataTable.isDataTable('#tblAllEmployee')) {
        $('#tblAllEmployee').DataTable().destroy();
    }
    var table = $('#tblAllEmployee').DataTable({
        data: Employee.data,
        "columns": [
            { "data": "id" },
            { "data": "employee_name" },
            { "data": "employee_salary" },
            { "data": "employee_age" },
            { "data": "profile_image" }
        ],
        "columnDefs": [
            {
                "targets": [4],
                "visible": false
            }
        ]
    });
}
//Side Navigation
function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
    document.getElementById("main").style.marginLeft = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("main").style.marginLeft = "0";
}


$("#CalculateAverages").click(function () {
    GetEmployee(2);
    HideDiv();
});

function CalculateAverages(EmployeeDetails) {
    if (EmployeeDetails.status == 'success') {
        $("#AvgAge").text(EmployeeDetails.AverageAge);
        $("#AvgSalary").text(EmployeeDetails.AverageSalary);
        $("#div_AverageCalculations").show();
        $("#div_getAllEmpAverages").show();

    }
}

$("#BelowAverageAge").click(function () {
    BindEmployeeAverageDetailsTable(EmployeeDetails.BelowAverageAgeEmployees);
});
$("#AboveAverageAge").click(function () {
    BindEmployeeAverageDetailsTable(EmployeeDetails.AboveAverageAgeEmployees);
});

$("#BelowAverageSalary").click(function () {
    BindEmployeeAverageDetailsTable(EmployeeDetails.BelowAverageSalaryEmployees);
});
$("#AboveAverageSalary").click(function () {
    BindEmployeeAverageDetailsTable(EmployeeDetails.AboveAverageSalaryEmployees);
});

function BindEmployeeAverageDetailsTable(EmployeeData) {
    $('#tblAllEmployeeAverages').show();
    if ($.fn.DataTable.isDataTable('#tblAllEmployeeAverages')) {
        $('#tblAllEmployeeAverages').DataTable().destroy();
    }
    //$.noConflict();
    var table1 = $('#tblAllEmployeeAverages').DataTable({
        data: EmployeeData,
        "columns": [
            { "data": "id" },
            { "data": "employee_name" },
            { "data": "employee_salary" },
            { "data": "employee_age" },
            { "data": "profile_image" }
        ],
        "columnDefs": [
            {
                "targets": [4],
                "visible": false
            }
        ]
    });
}
