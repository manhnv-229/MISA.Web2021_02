<template>
       
        <div class="dialog-modal" :class="{isDialogAddHide:isDialogAddHide}">    
        <div class="dialog-content" >
             <div class="dialog-header">
          <div class="dialog-header-title">THÔNG TIN NHÂN VIÊN</div>
          <div class="dialog-header-close">
            <button @click="btnCloseDialog">x</button>
          </div>
        </div>
            <div class="dialog-body">
                <div class="grid-dialog-container">
                    <div class="grid-item1">
                        <div class="img-dialog"></div>
                        <div class="text-img">
                            Vui lòng chọn ảnh có định dạng <br><b>.jpg, .jpeg, .png, .gif. </b>
                        </div>
                    </div>
                    <div class="grid-item2">
                        <div class="m-label">A. THÔNG TIN CHUNG:</div>
                        <div class="under-label"></div>
                    </div>
                    <div class="grid-item">

                        <div class="">Mã nhân viên (<span class="label-required">*</span>)</div>
                        <div class=""><input v-model="employee.employeeCode" id="employeeCode" required class="input-required input1" type="text" /></div>
                    </div>
                    <div class="grid-item">
                        <div class="">Họ và tên (<span class="label-required">*</span>)</div>
                        <div class="">
                            <input v-model="employee.employeeName" id="employeeName" class="input-required input1" type="text" required />
                        </div>

                    </div>
                    <div class="grid-item">

                        <div class="m-label">Ngày sinh</div>
                        <div class="m-control"><input v-model="employee.employeeBirth" id="employeeBirth" class="input1" type="date" /></div>

                    </div>
                    <div class="grid-item">
                        <div class="m-label">Giới tính</div>
                        <!-- <select id="employeeGender" class="input1" v-model="employee.employeeGender">
                            <option class="option1" value="-1">Giới tính</option>
                            <option class="option1" value="1">Nam</option>
                            <option class="option1" value="0">Nữ</option>
                            <option class="option1" value="2">Khác</option>

                        </select> -->
                        <EmployeeSelectCustom
                                :options="['Nam', 'Nữ', 'Khác']"
                                :default="employee.employeeGender"
                                class="select"
                                @input="input"
                                
                        />


                    </div>


                    <div class="grid-item">
                        <div class="m-label">Số CMND/Căn cước (<span class="label-required">*</span>)</div>
                        <div class="m-control"><input v-model="employee.employeeIdentifyNumber" id="employeeIdentifyNumber" class="input1" type="text" required/></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label ">Ngày cấp</div>
                        <div class="m-control"><input v-model="employee.employeeDateRegistration" id="employeeDateRegistration" class="input1" type="date" /></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Nơi cấp</div>
                        <div class="m-control"><input v-model="employee.employeePlaceRegistration" id="employeePlaceRegistration" type="email" class="input1" /></div>
                    </div>
                    <div class="grid-item" style="display:none" >
                        <input v-model="employee.employeeId" id="employeeId" class="input-required input1" type="text" />
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Email (<span class="label-required">*</span>)</div>
                        <div class="m-control"><input v-model="employee.employeeEmail" id="employeeEmail" class="input-required input1" type="text" required  placeholder="example@domain.com"/></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Số điện thoại (<span class="label-required">*</span>)</div>
                        <div class="m-control"><input v-model="employee.employeePhone" id="employeePhone" class="input-required input1" type="text" required /></div>
                    </div>


                    <div class="grid-item2">
                        <div class="m-label">B. THÔNG TIN CÔNG VIỆC:</div>
                        <div class="under-label"></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Vị trí</div>
                        <select id="employeePosition" class="input1" v-model="employee.employeePosition">
                            <option class="option1" value="-1">Vị trí</option>
                            <option class="option1">Giám đốc</option>
                            <option class="option1">Trưởng phòng</option>
                            <option class="option1">Quản lý</option>
                            <option class="option1">Nhân viên</option>
                            <option class="option1">Khác</option>

                        </select>

                    </div>

                    <div class="grid-item">
                        <div class="m-label">Phòng ban</div>
                        <select id="employeeDepartment" class="input1" v-model="employee.employeeDepartment">
                            <option class="option1" value="-1">Phòng ban</option>
                            <option class="option1">Phòng Hành Chính</option>
                            <option class="option1">Phòng Kĩ Thuật</option>
                            <option class="option1">Phòng Nhân Sự</option>
                            <option class="option1">Phòng Điều Hành</option>
                            <option class="option1">Khác</option>

                        </select>
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Mã số thuế cá nhân</div>
                        <div class="m-control"><input v-model="employee.employeeTaxNumber" id="employeeTaxNumber" class="input1"  type="text" /></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label" formatType="Money">Mức lương cơ bản</div>
                        <div class="m-control"><input v-model="employee.employeeSalaryGrade" id="employeeSalaryGrade" class="input1" type="text" /></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Ngày gia nhập công ty</div>
                        <div class="m-control"><input v-model="employee.employeeJoinDate" id="employeeJoinDate" class="input1" type="date" /></div>
                    </div>
                    <div class="grid-item">
                        <div class="m-label">Tình trang công việc</div>
                        <select id="employeeStatus" class="input1" v-model="employee.employeeStatus" >
                            <option class="option1" value="-1">Tình trạng</option>
                            <option class="option1" >Đang làm việc</option>
                            <option class="option1" >Đã nghỉ</option>

                            <option class="option1" >Khác</option>

                        </select>
                    </div>

                </div>



            </div>
            <div class="dialog-footer">
                <button id="btnDelete" class="m-btn" :class="{isDeleteHide:isDeleteHide}" @click="btnDelete">Xóa</button>
                <button id="btnCancel" class="m-btn m-btn-cancel" @click="btnCloseDialog">Hủy</button>
                <button id="btnSave" class="m-btn" @click="saveInformation"><i class="far fa-save"></i><span class="btn-text">Lưu</span></button>

            </div>
        </div>
        </div>
        
   
</template>

<script>

import EmployeeSelectCustom from './EmployeeSelectCustom';
export default {
    name:'EmployeeDialogAdd',
    props:{
        isDialogAddHide:{
            type:Boolean,
            default:true
        },
         employee:{
             type:Object,
             default:[]
         },
         isDeleteHide:{
            type:Boolean,
            default:true
         }

    },
    data(){
        return{
           
        }
    },
    methods:{
        btnCloseDialog(){
            this.$emit('btnCloseDialog');
        },
        saveInformation(){
            this.$emit('saveInformation');
        },
        btnDelete(){

        },
        input(value){
            return value;    
        }
       
        
    },
    components:{
        EmployeeSelectCustom,
    }
}
</script>

<style>

.isDialogAddHide{
    display:none;
}
.isDeleteHide{
    display: none;
}

.dialog-modal {
        
        position: fixed;
        top: 0;
        left: 0;
        bottom: 0;
        right: 0;
        background-color: rgba(0,0,0,0.4);
        z-index: 100;
        width: 100%;
        height: 100%;
    }

.dialog-content {
        position: absolute;
        background-color: #ffffff;

        z-index: 110;
        border-radius: 5px;
        width: 800px;
        height:auto;
        top:10px;
        left:350px;
        border: unset;
        
    }

.dialog-header {
    display: flex;
    padding: 24px 24px 0px 24px;
    cursor: move;
}

.dialog-header .dialog-header-close {
   position: absolute;
   right: 0;
   top: 0;
}

.dialog-header .dialog-header-close:hover {
    border-radius: 5px;
}

.dialog-header .dialog-header-close button {
   width: 40px;
   height: 40px;
   border-radius: 0 5px 0 0;
   border: none;
   outline: none;
   cursor: pointer;
   background-color: #ffffff;
   background-image: url('/public/content/icon/x.svg');
   background-repeat: no-repeat;
   background-position: center;
   background-size: 20px;
   opacity: .7;
}
.dialog-header .dialog-header-close button:hover {
   background-color: #ccc;
}

 

.dialog-header .dialog-header-title {
            font-size: 20px;
            text-transform: uppercase;
            font-weight: bold;
}

.dialog-content .dialog-body {
    padding: 24px 24px 24px;
}


.dialog-footer {
    display: flex;
    width: 100%;
    height: 60px;
    background-color: #e9ebee;
    border-radius: 0 0 5px 5px;
    align-items: center;
    justify-content: flex-end;
    padding: 10px 24px;
    box-sizing: border-box;
}

.dialog-footer button {
        margin-left: 16px;
}
.img-dialog {
    margin: auto;
    width: 160px;
    height: 160px;
    background-image: url('/public/content/img/default-avatar.jpg');
    border-radius: 50%;
    border: 1px solid gray;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
}
.under-label{
    height:3px;
    background-color:#01b075;
    width: 80px;
}
</style>