<template>
  <div class="row">
    <div class="grid grid-customer">
      <div
        class="el-table__body-wrapper is-scrolling-none el-table__body_custom"
      >
        <table
          id="tbListData"
          cellspacing="0"
          cellpadding="0"
          border="0"
          class="el-table__body"
          style="min-width: 100%"
        >
          <thead class="has-gutter">
            <tr class="el-table__row">
              <th colspan="1" rowspan="1" fieldName="EmployeeCode">
                <div class="cell" style="width: 130px">Mã nhân viên</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="FullName">
                <div class="cell">Họ và tên</div>
              </th>
              <th
                colspan="1"
                rowspan="1"
                fieldName="Gender"
                formatType="Gender"
              >
                <div class="cell w-82">Giới tính</div>
              </th>
              <th
                colspan="1"
                rowspan="1"
                fieldName="DateOfBirth"
                formatType="ddmmyyyy"
                style="text-align: center"
              >
                <div class="cell">Ngày sinh</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="PhoneNumber">
                <div class="cell">Số điện thoại</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="Email">
                <div class="cell">Email</div>
              </th>
              <th
                colspan="1"
                rowspan="1"
                fieldName="PositionId"
                formatType="PositionName"
              >
                <div class="cell">Chức vụ</div>
              </th>
              <th
                colspan="1"
                rowspan="1"
                fieldName="DepartmentId"
                formatType="DepartmentName"
              >
                <div class="cell">Phòng ban</div>
              </th>
              <th colspan="1" rowspan="1" fieldName="Salary" formatType="Money">
                <div class="cell w-140">Mức lương cơ bản</div>
              </th>
              <th
                colspan="1"
                rowspan="1"
                fieldName="WorkStatus"
                formatType="WorkStatusName"
              >
                <div class="cell w-155">Tình trạng công việc</div>
              </th>
              <th class="gutter" style="width: 6px"></th>
            </tr>
          </thead>
          <tbody>
            <tr
              class="el-table__row first"
              v-for="employee in employees"
              :key="employee.EmployeeId"
              @click="selectRow(employee.EmployeeId)"
              v-bind:class="isSelected(employee.EmployeeId) ? 'selected' : ''"
            >
              <td>
                <div class="cell">{{ employee.EmployeeCode }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.FullName }}</div>
              </td>
              <td>
                <div class="cell" v-bind:data-id="employee.Gender">
                  {{ employee.GenderName }}
                </div>
              </td>
              <td>
                <div class="cell">{{ employee.DateOfBirth | getDate }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.PhoneNumber }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.Email }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.PositionName }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.DepartmentName }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.Salary }}</div>
              </td>
              <td>
                <div class="cell">{{ employee.WorkStatusName }}</div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <!-- processing load -->
    <div class="process-centure" v-show="processing">
      <div class="processing-example text-info" role="status"></div>
      <span class="sr-only">Loading...</span>
    </div>
    <EmployeeModalEdit
      ref="EmployeeModalEdit_ref"
      :employee="employee"
      @edited="editedCofirm"
    />
    <EmployeeModalDelete
      ref="EmployeeModalDelete_ref"
      :listId="selected"
      @deleted="deletedCofirm"
    />
    <EmployeeModalConfirm
       ref="EmployeeModalConfirm_ref"
       :message="messageConfirm"
       :success="successConfirm"
    />
  </div>
</template>

<script>
import * as axios from "axios";
import EmployeeModalEdit from "../modals/employee/EmployeeModalEdit.vue";
import EmployeeModalDelete from "../modals/employee/EmployeeModalDelete.vue";
import EmployeeModalConfirm from "../modals/employee/EmployeeModalConfirm.vue"
// import VueToastr from "vue-toastr";

export default {
  name: "Table",
  props: {
    msg: String,
  },
  components: {
    EmployeeModalEdit,
    EmployeeModalDelete,
    EmployeeModalConfirm,
  },
  data() {
    return {
      processing: true,
      employees: [],
      employee: {
        Address: "",
        DateOfBirth: "",
        DepartmentId: "",
        DepartmentName: "",
        EducationalBackground: null,
        Email: "",
        EmployeeCode: "",
        EmployeeId: "",
        FirstName: "",
        FullName: "",
        Gender: null,
        GenderName: "",
        IdentityDate: "",
        IdentityNumber: "",
        IdentityPlace: "",
        JoinDate: "",
        LastName: "",
        MaritalStatus: null,
        PersonalTaxCode: "",
        PhoneNumber: "",
        PositionId: "",
        PositionName: "",
        QualificationId: "",
        QualificationName: "",
        Salary: null,
        WorkStatus: null,
        WorkStatusName: "",
      },
      selected: [],
      messageConfirm: '',
      successConfirm: true
    };
  },
watch:{
  employees: function() {
    console.log(this.employee);
  }
},
  methods: {
    // lấy data
    async getData() {
      this.processing = true;
      this.resetSelected();
      const response = await axios.get("http://api.manhnv.net/api/Employees");     
      //this.employees = response.data.data;
      this.employees = response.data;
       console.log("employees");
      console.log(this.employees);
      this.processing = false;
      // console.log(this.employees);
    },
    async openEmployeeModalConfirm(){

      await this.$refs.EmployeeModalConfirm_ref.show();
      },

    // kiểm tra xem đã nhấn dòng chưa để sửa ui
    isSelected(id) {
      const index = this.selected.indexOf(id);
      if (index > -1) return true;
      return false;
    },
    // thêm hoặc xóa dòng đã chọn vào list selected
    selectRow(id) {
      const index = this.selected.indexOf(id);
      if (index > -1) {
        this.selected.splice(index, 1);
      } else {
        this.selected.push(id);
      }
      console.log(this.selected);
    },
    //mở modal edit
    openEmployeeModalEdit: async function(employee)  {
      this.employee = employee;
      // console.log(this.employee);
      if (
        this.employee.DateOfBirth != null &&
        this.employee.DateOfBirth != ""
      ) {
        this.employee.DateOfBirth = this.employee.DateOfBirth.split("T")[0];
      }
      if (
        this.employee.IdentityDate != null &&
        this.employee.IdentityDate != ""
      ) {
        this.employee.IdentityDate = this.employee.IdentityDate.split("T")[0];
      }
      if (this.employee.JoinDate != null && this.employee.JoinDate != "") {
        this.employee.JoinDate = this.employee.JoinDate.split("T")[0];
      }

      await this.$refs.EmployeeModalEdit_ref.show();

      // console.log(this.$refs.EmployeeModalEdit.show());
    },

    
    //kiểm xoát việc mở form edit bởi cha nó
    showEmployeeModalEdit:function() {
      
      if (this.selected.length < 1) {
        alert("vui lòng chọn nhân viên");
        return;
      } else if (this.selected.length > 1) {
        alert("vui lòng chỉ chọn 1 nhân viên để sửa");
        return;
      }
      var empId = this.selected[0];
      var emp = this.employees.find((e) => e.EmployeeId == empId);
      this.openEmployeeModalEdit(emp);
      
    },
    resetSelected() {
      this.selected.length = 0; // tối ưu về hiệu suất
    },
    //kiểm xoát việc mở form delete bởi cha nó
    showEmployeeModalDelete: async function() {
      if (this.selected.length < 1) {
        alert("vui lòng chọn nhân viên");
        return;
      }     
     
      await this.$refs.EmployeeModalDelete_ref.show();
    },
    // thông báo cho cha nó sau khi đã sửa
    editedCofirm: async function (e) {
      if (e === true) {
        this.messageConfirm = "Cập nhật thành công";
        this.successConfirm = true;        
      } 
      else {
         this.messageConfirm = "Cập nhật thất bại";
         this.successConfirm = false;        
      }
      await Promise.all([this.$refs.EmployeeModalConfirm_ref.show(),this.getData()]); 
      await this.$refs.EmployeeModalEdit_ref.hide()
    },
    deletedCofirm: async function (e) {
      var strAnnounce = "";
      e.array.forEach(function(item){
          if(item.status == false){
            strAnnounce = strAnnounce + " xóa thất bại: " + item.id +"\n";
          }
          else{
            strAnnounce = strAnnounce + " Xóa thành công: " + item.id + "\n";
          }
      });        
     
      
        alert(strAnnounce);
        var get = this.getData();
        await this.$refs.EmployeeModalDelete_ref.hide();
        get.await;
      
    },
  },
  filters: {
    getDate(value) {
      if (value != "" && value != null) var valuefomat = value.split("T")[0];
      return valuefomat;
    },
  },

  async created() {
    await this.getData();
  },
};
</script>

<style src="./table.scss" lang="scss" />
<style scoped>
.process-centure {
  text-align: center;
}
.selected {
  background-color: rgba(0, 131, 238, 0.767) !important;
  color: #ffffff;
}
</style>
