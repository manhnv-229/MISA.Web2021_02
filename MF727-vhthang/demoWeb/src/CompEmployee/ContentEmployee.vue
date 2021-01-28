<template>
<div class="content-employee">
  <div class="page">
                <div class="content">
                    <div class="content-left">

                        <h2>Danh sách nhân viên</h2>
                        <div class="grid-content">
                            <div class="grid-item">
                                <div class="search1">
                                    <input class="input-search icon-search" type="search" id="search" placeholder="Tìm kiếm theo mã, Tên Khách hàng" />
                                </div>
                            </div>
                            <div class="grid-item">

                                <select id="sort" class="input1">
                                    <option class="option1" value="default">Sắp xếp</option>
                                    <option class="option1" value="0">Mã nhân viên</option>
                                    <option class="option1" value="1">Họ và tên</option>
                                    <option class="option1" value="2">Khác</option>
                                </select>
                            </div>
                            <div class="grid-item">
                                <button class="m-btn" onclick="chooseSort()">Đặt</button>
                            </div>
                        </div>

                    </div>
                    <div class="content-right">
                        <div>
                            <button class="m-btn m-btn-h-icon" id="btnAdd" @click="addEmployee">  
                                <div class="btn-icon"></div>
                                <div class="btn-text">Thêm nhân viên mới</div>
                            </button>
                        </div>
                        <div class="margin-btn-top">
                            <button class="m-btn m-btn-default" id="btnReload" @click="refreshData">
                                <div class="btn-icon2"></div>
                            </button>
                        </div>
                    </div>

                </div>
                <div class="grid grid-customer ">
                    <table id="tb-customer" cellspacing="0" cellpadding="0" border="0" class="table1" >
                        <thead>
                            <tr class="title-tb1">

                                <th colspan="1" rowspan="1" fieldName="CustomerCode"><div class="cell">Mã nhân viên</div></th>
                                <th colspan="1" rowspan="1" fieldName="FullName"><div class="cell">Họ và tên</div></th>
                                <th colspan="1" rowspan="1" fieldName="GenderName"><div class="cell">Ngày sinh</div></th>
                                <th colspan="1" rowspan="1" fieldName="DateOfBirth"><div class="cell">Giới tính</div></th>
                                <th colspan="1" rowspan="1" fieldName="CustomerGroupName"><div class="cell">Số CMND</div></th>
                                <th colspan="1" rowspan="1" fieldName="PhoneNumber"><div class="cell">Ngày cấp</div></th>
                                <th colspan="1" rowspan="1" fieldName="Email"><div class="cell">Nơi cấp</div></th>
                                <th colspan="1" rowspan="1" fieldName="Address"><div class="cell">Email</div></th>
                                <th colspan="1" rowspan="1" fieldName="DebitAmount"><div class="cell">Phone</div></th>
                                <th colspan="1" rowspan="1" fieldName="MemberCardCode"><div class="cell">Vị trí</div></th>
                                <th colspan="1" rowspan="1" fieldName="MemberCardCode"><div class="cell">Phòng ban</div></th>
                                <th colspan="1" rowspan="1" fieldName="MemberCardCode"><div class="cell">Mã số thuế</div></th>
                                <th colspan="1" rowspan="1" fieldName="MemberCardCode"><div class="cell">Mức lương</div></th>
                                <th colspan="1" rowspan="1" fieldName="MemberCardCode"><div class="cell">Ngày gia nhập công ty</div></th>
                                <th colspan="1" rowspan="1" fieldName="MemberCardCode"><div class="cell">Tính trạng công việc</div></th>

                            </tr>
                        </thead>
                        <tbody class="tb1">
                            <tr 
                                v-for="employee in Employees"
                                v-bind:key="employee.employeeId"
                                @click="showEmployee(employee)">
                            <td>
                                <div class="cell">{{ employee.employeeCode }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeName }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ formatDate(employee.employeeBirth) }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ formatGender(employee.employeeGender) }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeIdentifyNumber }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ formatDate(employee.employeeDateRegistration) }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeePlaceRegistration }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeEmail }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeePhone }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeePosition }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeDepartment }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeTaxNumber }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeSalaryGrade }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ formatDate(employee.employeeJoinDate) }}</div>
                                </td>
                                <td>
                                <div class="cell">{{ employee.employeeStatus }}</div>
                                </td>
                            </tr>
                
                        </tbody>
                    </table>
                </div>
            </div>
    </div>
</template>

<script>
export default {
    name:'content-employee',
    props:{
        Employees:{
            type:Array,
            
        },
    },
    methods:{
        addEmployee(){
            this.$emit('addEmployee');
        },
        refreshData(){

        },
        showEmployee(data){
            
            this.$emit('showEmployee',data);
        },
        formatGender(value){
            if(value == 1){
                return "Nam";
            }else if(value == 0){
                return "Nữ";
            }else return "Khác";

        },
        formatDate(date) {
    
        var date = new Date(date);
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();
        if  (year < 1800) return "01/01/1800";
        if (day < 10) day = '0' + day;
        if (month < 10) month = '0' + month;
        return day + '/' + month + '/' + year;
}

    }
}
</script>

<style>

/* table */
.grid {
    overflow-x: scroll;
    overflow-y: scroll;
    width:100%;
    height: calc(100vh - 230px);
}


.grid .grid-header {
    height: 56px;
}

    .grid .grid-content{
        height: calc(100% - 25px);
    }



.grid table th {
    border-bottom: 1px solid #bbbbbb;
    text-align: left;
}

    .grid table th .cell {
        padding: 15px 16px !important;
    }

.grid table td {
    border-bottom: 1px solid #bbbbbb;
    padding: 15px 16px !important;
    text-align: left;
    white-space: nowrap;
    box-sizing: border-box;
    text-overflow: ellipsis;
    word-break: break-all;
}


.grid table th {
    z-index: 1;
    position: sticky;
    background-color: #ffffff;
    top: 0px;
    left: 0;
    padding-top: 22px !important;
    font-weight: bold !important;
}

.grid tbody tr:nth-child(2n) {
    background-color: #fafafa;
}

.grid tbody tr:hover:nth-child(2n) {
    background-color: #d9d9d9;
    cursor: pointer;
}

.tb1 tr:hover {
    background-color: #d9d9d9;
    cursor: pointer;
}

.grid table td span {
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
}


.grid td div {
    max-width: 200px;
    white-space: nowrap;
    box-sizing: border-box;
    overflow: hidden;
    text-overflow: ellipsis;
    word-break: break-all;
}

/* content */
.content {
    display: flex;
    padding: 10px 0px 0px 0px;
}
.content-right{
    position:absolute;
    right:20px;
}
.content-right .margin-btn-top{
    margin-top:16px;
}
#search {
    width: 100%;
    height: 40px;
    border-radius: 4px;
    outline: none;
    border: 1px solid #bbbbbb;
    font-size: 12px;
    box-sizing: border-box;
    font-family: GoogleSans-Regular;
}


.icon-search {
    background-image: url('/public/content/icon/search.png');
    background-repeat: no-repeat;
    background-position: 16px center;
}
#search:focus {
    border: 1px solid #019160;
    font-size: 12xpx;
}

.text-img {
    text-align:center;
}
.label-required{
    color:red;
}
.page {
    padding: 0px 20px 0px 20px;
}
.margin-label {
    margin-top: 25px;
    margin-bottom: 25px;
    
}
</style>