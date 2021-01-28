var page = 1;
var pageLength = 4;
var sort = 0;
$(document).ready(function () {
    dialog1 = $("#add-dialog").dialog({
        autoOpen: false,
        width: 800,
        modal: true,
    });
    dialog2 = $("#notify-dialog").dialog({
        autoOpen: false,
        width: 300,
        modal: true,
    });

    loadData(page);
    initEvens()
    
})
var query;

/**
 * Thực hiện load dữ liệu
 * Author: Vũ Hữu Thắng
 * */
function chooseSort() {
    if ($("#sort").val() == 1) {
        sort = 1;
        currentPage(1);
    } else {
        sort = 0;
        currentPage(1);
    }
}
function plusPages(n) {
    loadData(page += n);
}
function currentPage(n) {
    loadData(page = n);

}
function loadData(n) {
    if (n > 4) { page = 1 }
    if (n < 1) { page = pageLength }
    $('.btn-pagenumber').removeClass("btn-pagenumber-selected");
    $('.btn-pagenumber').eq(page - 1).addClass("btn-pagenumber-selected");
    $.ajax({
        url: 'http://localhost:52327/api/Employees/page?num='+ page +'&type='+ sort,
        method: 'GET',
    }).done(function (response) {
        
        $('#tb-customer tbody').empty();
        for (var i = 0; i < response.length; i++) {

            var dateBirth = formatDate(response[i].employeeBirth);
            var dateReg = formatDate(response[i].employeeDateRegistration);
            var dateJoin = formatDate(response[i].employeeJoinDate);
            var gender = formatGender((response[i].employeeGender));
            var trTable1 = `<tr class="table-row" onclick="loadAnEmployee(this)" >
                        
                        
                        <td>
                            <div class="cell">${response[i].employeeCode}</div>
                        </td>
                        <td>
                            <div class="cell">${response[i].employeeName}</div>
                        </td>
                        <td><div class="cell text-align-center">${dateBirth}</div></td>
                        <td><div class="cell">${gender}</div></td>
                        
                        <td><div class="cell">${response[i].employeeIdentifyNumber}</div></td>
                        <td><div class="cell">${dateReg}</div></td>
                        <td><div class="cell">${response[i].employeePlaceRegistration || "Khác"}</div></td>
                        
                        <td><div class="cell">${response[i].employeeEmail}</div></td>
                        <td><div class="cell">${response[i].employeePhone}</div></td>
                        <td><div class="cell">${response[i].employeePosition || "Khác"}</div></td>
                        <td><div class="cell">${response[i].employeeDepartment || "Khác"}</div></td>
                        <td><div class="cell">${response[i].employeeTaxNumber || "Khác"}</div></td>
                        <td><div class="cell">${response[i].employeeSalaryGrade}</div></td>
                        <td><div class="cell">${dateJoin}</div></td>
                        <td><div class="cell">${response[i].employeeStatus || "Khác"}</div></td>
                        
                    </tr>`;
            
            $('#tb-customer > tbody:last-child').append(trTable1);
        }
    }).fail(function (response) {
        alert("fail");
        })
}

//

/**
  * Thực hiện xử lý dữ liệu ngày tháng
  * Author:Vũ Hữu Thắng
  * */   
function formatDate(date) {
    
    var date = new Date(date);
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    if (day < 10) day = '0' + day;
    if (month < 10) month = '0' + month;
    return day + '/' + month + '/' + year;
}

function formatGender(_gender) {
    if (_gender == 1) return "Nam";
    if (_gender == 0) return "Nữ";
    if (_gender == 2) return "Khác";
}


/**
 * Thực hiện gán các sự kiện
 * Author: Vũ Hữu Thắng
 * */
function initEvens() {
    
    

    $('#btnCancel').click(function () {
        dialog1.dialog('close');
    })
    $('#btnCancelCf').click(function () {
        dialog2.dialog('close');
        $("#btnDeleteCf").hide();
    })

    
}

//load 1 nhân viên
function loadAnEmployee(entity) {
    var code = $(entity).find('div').html();
   
    $.ajax({
        url: 'http://localhost:52327/api/Employees/'+code,
        method: 'GET',
    }).done(function (response) {
        console.log(response);
        var dateBirth = dateF(response[0].employeeBirth);
        var dateReg = dateF(response[0].employeeDateRegistration);
        var dateJoin = dateF(response[0].employeeJoinDate);
        if (response[0].employeeGender == "1") { $("#employeeGender").val("1"); }
        else if (response[0].employeeGender == "0") { $("#employeeGender").val("0"); }
        else { $("#employeeGender").val("2"); }
        
        if (response[0].employeePosition == "Giám đốc") { $("#employeePosition").val("0");  }
        else if (response[0].employeePosition == "Trưởng phòng") { $("#employeePosition").val("1"); }
        else if (response[0].employeePosition == "Nhân viên") { $("#employeePosition").val("2"); }
        else { $("#employeePosition").val("3"); }

        if (response[0].employeeDepartment == "Phòng hành chính") { $("#employeeDepartment").val("0"); }
        else if (response[0].employeeDepartment == "Phòng kĩ thuật") { $("#employeeDepartment").val("1"); }
        else if (response[0].employeeDepartment == "Phòng nhân sự") { $("#employeeDepartment").val("2"); }
        else { $("#employeeDepartment").val("3"); }

        if (response[0].employeeStatus == "Đang làm việc") { $("#employeeStatus").val("0"); }
        else if (response[0].employeeStatus == "Đã nghỉ") { $("#employeeStatus").val("1"); }
        else { $("#employeeStatus").val("2"); }


        $('#employeeId').val(response[0].employeeId);
        
        $('#employeeCode').val(response[0].employeeCode);
        $('#employeeName').val(response[0].employeeName);
        $('#employeeBirth').val(dateBirth);
        
        $('#employeeIdentifyNumber').val(response[0].employeeIdentifyNumber);
        $('#employeeDateRegistration').val(dateReg);
        $('#employeePlaceRegistration').val(response[0].employeePlaceRegistration);
        $('#employeeEmail').val(response[0].employeeEmail);
        $('#employeePhone').val(response[0].employeePhone);
        
        
        $('#employeeTaxNumber').val(response[0].employeeTaxNumber);
        $('#employeeSalaryGrade').val(response[0].employeeSalaryGrade);
        $('#employeeJoinDate').val(dateJoin);
        query = "update";
        dialog1.dialog('open');
        $("#btnDelete").show();

    }).fail(function(response){
    })

}

function dateF(date) {
    var now = new Date(date);

    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);

    return  now.getFullYear() + "-" + (month) + "-" + (day);
}
//thêm mới nv
function addEmployee() {
    clearDialog();
    $.ajax({
        url: 'http://localhost:52327/api/Employees/code' ,
        method: 'GET',
    }).done(function (response) {
        $('#employeeCode').val(response);
        query = "add";
        
    })
    
    dialog1.dialog('open');
    $("#btnDelete").hide();
}
//clear dialog
function clearDialog() {
    $("#employeeId").val("");
    $("#employeeGender").val("default");
    $("#employeePosition").val("default"); 
    $("#employeeDepartment").val("default");
    $("#employeeStatus").val("default");
    $('#employeeCode').val("");
    $('#employeeName').val("");
    $('#employeeBirth').val("");

    $('#employeeIdentifyNumber').val("");
    $('#employeeDateRegistration').val("");
    $('#employeePlaceRegistration').val("");
    $('#employeeEmail').val("");
    $('#employeePhone').val("");


    $('#employeeTaxNumber').val("");
    $('#employeeSalaryGrade').val("");
    $('#employeeJoinDate').val("");
}
function addQuery() {
    
    var employeeId = $('#employeeId').val();
    var employeeCode = $('#employeeCode').val().trim();
    var employeeName = $('#employeeName').val().trim();
    var employeeBirth = $('#employeeBirth').val();
    
    var employeeIdentifyNumber = $('#employeeIdentifyNumber').val().trim();
    var employeeDateRegistration = $('#employeeDateRegistration').val();
    var employeePlaceRegistration = $('#employeePlaceRegistration').val();
    var employeeEmail = $('#employeeEmail').val().trim();
    var employeePhone = $('#employeePhone').val().trim();

    if ($('#employeeGender').val() == 0) { var employeeGender = "0"; }
    else if ($('#employeeGender').val() == 1) { var employeeGender = "1"; }
    else { var employeeStatus = "2"; }

    if ($('#employeePosition').val() == 0) { var employeePosition = "Giám đốc"; }
    else if ($('#employeePosition').val() == 1) { var employeePosition = "Trưởng phòng"; }
    else if ($('#employeePosition').val() == 2) { var employeePosition = "Nhân viên"; }
    else { var employeePosition = "Khác"; }

    if ($('#employeeDepartment').val() == 0) { var employeeDepartment = "Phòng hành chính"; }
    else if ($('#employeeDepartment').val() == 1) { var employeeDepartment = "Phòng kĩ thuật"; }
    else if ($('#employeeDepartment').val() == 2) { var employeeDepartment = "Phòng nhân sự"; }
    else { var employeeDepartment = "Khác"; }

    if ($('#employeeStatus').val() == 0) { var employeeStatus = "Đang làm việc"; }
    else if ($('#employeeStatus').val() == 1) { var employeeStatus = "Đã nghỉ"; }
    else { var employeeStatus = "Khác"; }
    
    var employeeTaxNumber = $('#employeeTaxNumber').val();
    var employeeSalaryGrade = $('#employeeSalaryGrade').val();
    var employeeJoinDate = $('#employeeJoinDate').val();

    if (employeeCode == "" || employeeName == "" || employeeIdentifyNumber == "" || employeeEmail == "" || employeePhone == "") {
        dialog2.dialog('open');
        $("#notify-text").html("Vui lòng điền đầy đủ thông tin");
    } else {
        
        //thêm mới Employee
        if (query == "add") {
            var employee = {
                "employeeId": "114ebdc0-36a8-1d80-fc69-4afe230d73a5",
                "employeeCode": employeeCode,
                "employeeName": employeeName,
                "employeeBirth": employeeBirth,
                "employeeGender": employeeGender,
                "employeeIdentifyNumber": employeeIdentifyNumber,
                "employeeDateRegistration": employeeDateRegistration,
                "employeePlaceRegistration": employeePlaceRegistration,
                "employeeEmail": employeeEmail,
                "employeePhone": employeePhone,
                "employeePosition": employeePosition,
                "employeeDepartment": employeeDepartment,
                "employeeTaxNumber": employeeTaxNumber,
                "employeeSalaryGrade": employeeSalaryGrade,
                "employeeJoinDate": employeeJoinDate,
                "employeeStatus": employeeStatus
            }
            $.ajax({
                url: 'http://localhost:52327/api/Employees',
                method: 'POST',
                data: JSON.stringify(employee),
                contentType: 'application/json',
                success: function (result) {

                    console.log(result);
                }
            }).done(function (res) {
                dialog2.dialog('open');
                $("#notify-text").html(res);
                currentPage(1);
                console.log(res);
            }).fail(function (res) {
                dialog2.dialog('open');
                $("#notify-text").html(res);
                console.log(res);
            })
        }
        //update employee
        if (query == "update") {
            var employee = {
                "employeeId": employeeId,
                "employeeCode": employeeCode,
                "employeeName": employeeName,
                "employeeBirth": employeeBirth,
                "employeeGender": employeeGender,
                "employeeIdentifyNumber": employeeIdentifyNumber,
                "employeeDateRegistration": employeeDateRegistration,
                "employeePlaceRegistration": employeePlaceRegistration,
                "employeeEmail": employeeEmail,
                "employeePhone": employeePhone,
                "employeePosition": employeePosition,
                "employeeDepartment": employeeDepartment,
                "employeeTaxNumber": employeeTaxNumber,
                "employeeSalaryGrade": employeeSalaryGrade,
                "employeeJoinDate": employeeJoinDate,
                "employeeStatus": employeeStatus
            }
            $.ajax({
                url: 'http://localhost:52327/api/Employees/update',
                method: 'POST',
                data: JSON.stringify(employee),
                contentType: 'application/json',
                success: function (result) {

                    console.log(result);
                }
            }).done(function (res) {
                dialog2.dialog('open');
                $("#notify-text").html(res);
                console.log(res);
            }).fail(function (res) {
                dialog2.dialog('open');
                $("#notify-text").html(res);
                console.log(res);
            })
        }
    }
    
}

//Xóa Nhân viên
function clickDelete() {
    dialog2.dialog('open');
    $("#notify-text").html("Bạn có chắc chán muốn xóa nhân viên này không?");
    $("#btnDeleteCf").show();

}
function deleteEmployee() {
    var employeeId = $('#employeeId').val();
    $.ajax({
        url: 'http://localhost:52327/api/Employees/delete',
        method: 'POST',
        data: JSON.stringify(employeeId),
        contentType: 'application/json',
        success: function (result) {

            
        }
    }).done(function (res) {
        dialog2.dialog('open');
        $("#notify-text").html(res);
        currentPage(1);
        $("#btnDeleteCf").hide();
        console.log(res);
    }).fail(function (res) {
        dialog2.dialog('open');
        $("#notify-text").html(res);
        $("#btnDeleteCf").hide();
        console.log(res);
    })
}
//xử lý tiền tệ
/*$("#employeeSalaryGrade").on("change", function () {
    
    $("#employeeSalaryGrade").val(new Intl.NumberFormat('vn-VN', { style: 'currency', currency: 'VND' }).format($("#employeeSalaryGrade").val()));
    
})*/
