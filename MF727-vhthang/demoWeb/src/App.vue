<template>
  <div id="app">
     <div class="main">
        <!--phan ben trai-->
        <menu-left 
            v-on:handleMenu="handleMenu"
            v-bind:MenuBarCus="MenuBarCus"
        />


        <!--phan ben phai-->

        <div class="panel-right">
            <header-page
                v-bind:Department="Department"
            />
            <content-employee
                v-bind:Employees="Employees"
                @addEmployee="addEmployee"
                @showEmployee="showEmployee"
            />
            <paging-bar/> 
            
            
            
        </div>
        

    </div>
    <DialogEmployee 
                v-bind:isDialogAddHide="isDialogAddHide"
                @btnCloseDialog="btnCloseDialog"
                @saveInformation="saveInformation"
                :employee="employee"
            />
    <dialog-pop-up 
        :isDialogPopupHide="isDialogPopupHide"
        @btnCancelPopup="btnCancelPopup"
        />


    
  </div>
</template>

<script>
import 'regenerator-runtime/runtime'
import MenuLeft from './CompEmployee/MenuLeft.vue';
import PagingBar from './CompEmployee/PagingBar.vue';
import ContentEmployee from './CompEmployee/ContentEmployee.vue';
// import DialogEmployee from './CompEmployee/DialogEmployee.vue';
// import DialogPopUp from './CompEmployee/DialogPopUp.vue';
import HeaderPage from './CompEmployee/HeaderPage.vue';
import * as axios from "axios";
import './css/button.css';
import './css/input.css';
import './css/grid.css';
import DialogEmployee from './CompEmployee/DialogEmployee.vue';
import DialogPopUp from './CompEmployee/DialogPopUp.vue';

export default {
  name: 'app',
  data () {
    return {
    isDialogPopupHide:false,
    

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
      btnCancelPopup(){
          this.isDialogPopupHide=true;
      },
      handleMenu(){
          
      },
      showEmployee(data){
          this.isDialogAddHide=false;
          this.employee = data;
      },
      addEmployee(){
          // mở dialog
            this.isDialogAddHide=false;
            
          //lấy mã code cao nhất
          // đẩy vào code
            this.getHighestCode();

      },
      btnCloseDialog(){
          this.isDialogAddHide=true;
      },
      async saveInformation(){
          const response = await axios.post("http://localhost:52327/api/Employees",this.employee);
          console.log(response.data);
      },
      
      
      async getHighestCode() {
          const response =await axios.get("http://localhost:52327/api/Employees/code");
          this.employee.employeeCode = response.data;
         
      },
  },
  
  components:{
    MenuLeft,
    PagingBar,
    ContentEmployee,
    // DialogEmployee,
    // DialogPopUp,
    HeaderPage,
    DialogEmployee,
    DialogPopUp,


  },
   async created() {
    const response =await axios.get("http://localhost:52327/api/Employees");
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
