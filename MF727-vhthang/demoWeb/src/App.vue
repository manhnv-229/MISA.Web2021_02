<template>
  <div id="app">
     <div class="main">
        <!--phan ben trai-->
        <EmployeeMenu
            v-on:handleMenu="handleMenu"
            v-bind:MenuBarCus="MenuBarCus"
        />


        <!--phan ben phai-->

        <div class="panel-right">
            <EmployeeHeader
                v-bind:Department="Department"
            />
            <EmployeeContent
                :Employees="Employees"
                @addEmployee="addEmployee"
                @showEmployee="showEmployee"
                @refreshData="refreshData"
            />
            
            <EmployeePagingBar/> 
            
            
            
        </div>
        

    </div>
    <EmployeeDialogAdd
                :isDialogAddHide="isDialogAddHide"
                @btnCloseDialog="btnCloseDialog"
                @saveInformation="saveInformation"
                :employee="employee"
                :isDeleteHide="isDeleteHide"
            />
    <EmployeeDialogPopUp
        :isDialogPopupHide="isDialogPopupHide"
        @btnCancelPopup="btnCancelPopup"
        :msgPopUp="msgPopUp"
        />


    
  </div>
</template>

<script>
import 'regenerator-runtime/runtime'
import EmployeeMenu from './Employee/EmployeeMenu.vue';
import EmployeePagingBar from './Employee/EmployeePagingBar.vue';
import EmployeeContent from './Employee/EmployeeContent.vue';
import EmployeeHeader from './Employee/EmployeeHeader.vue';
import * as axios from "axios";
import './css/button.css';
import './css/input.css';
import './css/grid.css';
import EmployeeDialogAdd from './Employee/EmployeeDialogAdd.vue';
import EmployeeDialogPopUp from './Employee/EmployeeDialogPopUp.vue';



export default {
  name: 'app',
  data () {
    return {
    //Ẩn thông báo    
    isDialogPopupHide:true,
    //ẩn nút xóa
    isDeleteHide:true,
    //add or update
    isAdd:true,
    //tin nhắn thông báo
    msgPopUp:"",
    //mã code phản hồi
    codeResponse:0,
    //trang hiện tại
    pageCurrent:1,
    //Loại sắp xếp
    typeSort:0,

      MenuBarCus:[
          {src:"dashboard.png", title:'Tổng quan'},
          {src:"report.png", title:'Báo cáo'},
          {src:"dashboard.png", title:'Mua hàng'},
          {src:"dic-employee.png", title:'Danh mục nhân viên'},
          {src:"dic-employee.png", title:'Danh mục khách hàng'},
          {src:"setting.png", title:'Thiết lập hệ thống'},

      ],
      
      Department:[
          {name:"Chi nhánh Biển Đông"},
          {name:"Chi nhánh Hải Dương"},
          {name:"Chi nhánh Đội Cấn"},
          {name:"Chi nhánh Cầu Giấy"},
          

      ],
      Employees: [
        {
          employeeId: 1,
          employeeCode: "Nguyễn Văn Mạnh",
        },
        {
          employeeId: 2,
          employeeCode: "Nguyễn Văn Mạnh",
        },
        {
          employeeId: 3,
          employeeCode: "Nguyễn Văn Mạnh",
        },
      ],
      isDialogAddHide:true,
       employee:{
        employeeId: "13009ae2-3273-11e8-fb69-4afe230d73a5",
        employeeCode: "",
        employeeName: "Hoàng Ngọc Anh",
        employeeBirth: "2000-12-21",
        employeeGender: "1",
        employeeIdentifyNumber: "1221212121212",
        employeeDateRegistration: "2000-12-21",
        employeePlaceRegistration: "Hưng yên",
        employeeEmail: "WW@gmail.com",
        employeePhone: "151515155115",
        employeePosition: "Giám Đốc",
        employeeDepartment: "Khác",
        employeeTaxNumber: "111111111111111111",
        employeeSalaryGrade: "120000000",
        employeeJoinDate: "2000-12-21",
        employeeStatus: "Đã nghỉ",
    },
   
    
      
    }
  },
  methods:{
      //Nút ẩn thông báo
      btnCancelPopup(){
          if(this.codeResponse == 201){
              this.isDialogPopupHide=true;
              this.isDialogAddHide=true;
          }else
          this.isDialogPopupHide=true;
      },

      //Xử lý menu  
      handleMenu(){
          
      },

      //Refresh dữ liệu
      async refreshData(){
          //Tạo hoạt ảnh loading
          //Lấy dữ liệu
          const response =await axios.get("http://localhost:52327/api/v1/Employees");
          this.Employees = response.data;
      },

      //Xử lý hiển thị 1 nhân viên  
      showEmployee(data){
          //mở dialog
          this.isDeleteHide=false;
          this.isAdd=false;
          this.isDialogAddHide=false;
          //lấy data từ Employees 
          //xử lý data
          data.employeeBirth = this.formatDateShow(data.employeeBirth);
          data.employeeDateRegistration = this.formatDateShow(data.employeeDateRegistration);
          data.employeeJoinDate = this.formatDateShow(data.employeeJoinDate);
          //truyền vào bảng
          this.employee = data;

      },

      //Xử lý thông tin dang ngày tháng để hiển thị
      formatDateShow(date){
          var date = new Date(date);
          var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();
            if  (year < 1800) return "01/01/1800";
            if (day < 10) day = '0' + day;
            if (month < 10) month = '0' + month;
            return year + '-' + month + '-' + day;
      },

      //Nút thêm nhân viên
      addEmployee(){
          this.isAdd=true;
          this.employee = {
            employeeId: "13009ae2-3273-11e8-fb69-4afe230d73a5",
            employeeCode: "",
            employeeName: "",
            employeeBirth: null,
            employeeGender: "Nam",
            employeeIdentifyNumber: "",
            employeeDateRegistration: null,
            employeePlaceRegistration: "",
            employeeEmail: "",
            employeePhone: "",
            employeePosition: "-1",
            employeeDepartment: "-1",
            employeeTaxNumber: "",
            employeeSalaryGrade: "",
            employeeJoinDate: null,
            employeeStatus: "-1",}
          // mở dialog
            this.isDeleteHide=true;
            this.isDialogAddHide=false;
            
          //lấy mã code cao nhất

          // đẩy vào code
            this.getHighestCode();

      },

      //Nút đóng Cửa sổ thêm nhân viên  
      btnCloseDialog(){
          this.isDialogAddHide=true;
      },

      //Lưu nhân viên bao gồm cả thêm mới và sửa nhân viên  
      saveInformation(){
          //kiểm tra là thêm hay sửa
          if(this.isAdd == true){

          
          axios.post("http://localhost:52327/api/v1/Employees", this.employee
                
            )
            .then(response => {
               console.log(response);
                this.msgPopUp=response.data;
                this.codeResponse=response.data.code;
                //Mở popup
                this.isDialogPopupHide=false;
            })
            .catch(err => {
                if (err.response) {
                console.log(err.response.data);
                this.msgPopUp=err.response.data.userMsg;
                this.codeResponse=err.response.data.code;
                this.isDialogPopupHide=false;
                } else if (err.request) {
                console.log(err.request)
                } else {
                
                }
            })
          
          
          }
          
      },
      validate(){
          //Kiểm tra các trừơng bắt buộc còn thiếu
          if(this.employeeCode == "" || this.employeeBirth == ""){}
      },

      
      
      async getHighestCode() {
          const response =await axios.get("http://localhost:52327/api/v1/Employees/code");
          this.employee.employeeCode = response.data;
          
         
      },
  },
  
  components:{
    EmployeeMenu,
    EmployeePagingBar,
    EmployeeContent,
    EmployeeHeader,
    EmployeeDialogAdd,
    EmployeeDialogPopUp,
   

  },
   async created() {
    const response =await axios.get("http://localhost:52327/api/v1/Employees");
    this.Employees = response.data;
    
  },
  
}
</script>

<style>
body {
    margin:0px;
    font-family: GoogleSans-Regular;
    font-size: 13px;
    
}
@font-face {
    font-family: 'GoogleSans-Italic';
    src: url('/public/content/font/GoogleSans-Italic.otf') format('opentype');
}
@font-face {
    font-family: 'GoogleSans-Bold';
    src: url('/public/content/font/GoogleSans-Bold.otf') format('opentype');
}
@font-face {
    font-family: 'GoogleSans-Regular';
    src: url('/public/content/font/GoogleSans-Regular.otf') format('opentype');
}
.panel-left {
    width: 220px;
    height: 100vh;
    border-right: 1px solid black;
}
.panel-right {
    width: calc(100% - 220px);
    height: 100vh;
    
}
.main {
    display: flex;
}
.panel-left .logo {
    align-items: center;
    display: flex;
    height: 60px;
    width: 100%;
   
}
.logo .expend-icon {
        margin-left: 20px;
        width: 27px;
        height: 25px;
        background-image: url('/public/content/img/toggle.png');
        background-size: cover;
        background-position: center center;
        background-repeat:no-repeat;
    }
.logo .logo-page {
    width: 100%;
    height: 35px;
    
 
    background-image: url('/public/content/img/cukcuk-logo.png');
    background-position:center;
    background-size: contain;
    background-repeat:no-repeat;

}
::-webkit-scrollbar {
    width: 5px !important;
    height: 5px !important;
    z-index: 12
}

::-webkit-scrollbar-track {
    width: 6px;
    background-color: #bbb;
}

::-webkit-scrollbar-thumb {
    background-color: #808080;
    border-radius: 8px
}

</style>
