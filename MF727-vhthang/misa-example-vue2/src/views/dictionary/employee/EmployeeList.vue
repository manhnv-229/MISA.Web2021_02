<template>
  <div class="content-body">
    <div class="header-content">
      <div class="title">Danh sách nhân viên</div>
      <div class="content-feature">
        <button
          id="btnAdd"
          class="m-btn m-btn-default"
          v-on:click="btnAddOnClick"
        >
          <div class="m-btn-icon icon-add"></div>
          <div class="btn-text" @click="btnAddOnClick">Thêm nhân viên</div>
        </button>
        <Details :isHide="isHideParent"
          @btnCancelOnClick="btnCancelOnClick"
        />
      </div>
    </div>
    <div class="filter-bar">
      <div class="filter-left">
        <input
          id="txtSearchEmployee"
          class="icon-search input-search"
          type="text"
          placeholder="Tìm kiếm theo Mã, Tên hoặc Số điện thoại"
        />
        <select
          id="cbxDepartment"
          fieldName="CustomerGroupName"
          fieldValue="CustomerGroupId"
          api="/api/customergroups"
          class="m-control"
        >
          <option value="19165ed7-212e-21c4-0428-030d4265475f">
            Tất cả phòng ban
          </option>
          <option value="19165ed7-212e-21c4-0428-030d4265475f">
            Văn phòng Tổng công ty
          </option>
          <option value="7a0b757e-41eb-4df6-c6f8-494a84b910f4">
            Phong đào tạo công nghệ
          </option>
          <option value="3631011e-4559-4ad8-b0ad-cb989f2177da">
            Phòng Nhân sự
          </option>
        </select>
        <select
          id="cbxPosition"
          fieldName="CustomerGroupName"
          fieldValue="CustomerGroupId"
          api="/api/customergroups"
          class="m-control"
        >
          <option value="19165ed7-212e-21c4-0428-030d4265475f">
            Tất cả vị trí
          </option>
          <option value="19165ed7-212e-21c4-0428-030d4265475f">Giám đốc</option>
          <option value="7a0b757e-41eb-4df6-c6f8-494a84b910f4">
            Trưởng phòng
          </option>
          <option value="3631011e-4559-4ad8-b0ad-cb989f2177da">
            Nhân viên
          </option>
        </select>
      </div>
      <div class="filter-right">
        <button id="btnRefresh" class="m-second-button m-btn-refresh"></button>
      </div>
    </div>
    <!-- <v-data-table
      :headers="headers"
      :items="desserts"
      :items-per-page="5"
      class="elevation-1"
    >
    </v-data-table> -->

    <div
      class="grid grid-employee el-table el-table--fit el-table--scrollable-y el-table--enable-row-hover el-table--enable-row-transition"
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
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_114 is-leaf"
              fieldName="EmployeeCode"
            >
              <div class="cell">Mã nhân viên</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_115 is-leaf"
              fieldName="FullName"
            >
              <div class="cell">Họ và tên</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="GenderName"
            >
              <div class="cell">Giới tính</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="DateOfBirth"
              formatType="ddmmyyyy"
              style="text-align: center"
            >
              <div class="cell">Ngày sinh</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="PhoneNumber"
            >
              <div class="cell">Điện thoại</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="Email"
            >
              <div class="cell">Email</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="PositionName"
            >
              <div class="cell">Chức vụ</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="DepartmentName"
            >
              <div class="cell">Phòng ban</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="Salary"
              formatType="Money"
            >
              <div class="cell" style="text-align: right">Mức lương cơ bản</div>
            </th>
            <th
              colspan="1"
              rowspan="1"
              class="el-table_30_column_116 is-leaf"
              fieldName="WorkStatusName"
            >
              <div class="cell">Tình trạng công việc</div>
            </th>
            <th class="gutter" style="width: 6px"></th>
          </tr>
        </thead>
        <tbody>
          <tr
            class="el-table__row"
            v-for="employee in employees"
            :key="employee.EmployeeId"
            @dblclick="rowOnClick(employee)"
          >
            <td>
                            <div class="cell">{{ employee.EmployeeCode }}</div>
                            </td>
                            <td>
                            <div class="cell">{{ employee.FullName }}</div>
                            </td>
                            <td>
                            <div class="cell">{{ employee.GenderName }}</div>
                            </td>
                            <td>
                            <div class="cell">{{ employee.DateOfBirth }}</div>
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
    <div class="paging-bar">
      <div class="paging-record-info">Hiển thị <b>1-10/1000</b> nhân viên</div>
      <div class="paging-option">
        <div class="btn-select-page m-btn-firstpage"></div>
        <div class="btn-select-page m-btn-prev-page"></div>
        <div class="m-btn-list-page">
          <button class="btn-pagenumber btn-pagenumber-selected">1</button>
          <button class="btn-pagenumber">2</button>
          <button class="btn-pagenumber">3</button>
          <button class="btn-pagenumber">4</button>
        </div>
        <div class="btn-select-page m-btn-next-page"></div>
        <div class="btn-select-page m-btn-lastpage"></div>
      </div>
      <div class="paging-record-option"><b>10</b> nhân viên/trang</div>
    </div>
    
  </div>
</template>
<script>
import * as axios from "axios";
import Details from "./EmployeeProfileDetail";
export default {
  name: "Employees",
  components: {
    Details,
  },
  methods: {
    btnAddOnClick() {
      this.isHideParent=false;
    },
    btnCancelOnClick(value){
      this.isHideParent=value;
      
    },
    rowOnClick(employee){
      alert(employee.FullName);
    }
  },
  data() {
    return {
       Employee:{
        EmployeeId: "",
        EmployeeCode: "",
        FirstName: "",
        LastName: "",
        FullName: "",
        Gender: "",
        DateOfBirth: "",
        PhoneNumber: "",
        Email: "",
        Address: "",
        IdentityNumber: "",
        IdentityDate: "",
        IdentityPlace: "",
        JoinDate: "",
        MaritalStatus: "",
        PersonalTaxCode: "",
        Salary: "",
        EducationalBackground: "",
        WorkStatus: "",
        PositionId: "",
        PositionName: "",
        DepartmentId: "",
        DepartmentName: "",
        QualificationId: "",
        QualificationName: "",
        GenderName: "",
        WorkStatusName: ""
    },
      isHideParent:true,
      selectedEmployee: {
        EmployeeId: 1,
        FullName: "Nguyễn Văn Mạnh",
      },
      employees: [
        {
          EmployeeId: 1,
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          EmployeeId: 1,
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          EmployeeId: 1,
          FullName: "Nguyễn Văn Mạnh",
        },
      ],
      headers: [
        {
          text: "Mã nhân viên",
          align: "start",
          sortable: false,
          value: "EmployeeCode",
        },
        { text: "Họ và tên", value: "FullName", align: "end" },
        { text: "Ngày sinh", value: "DateOfBirth" },
        { text: "Giới tính", value: "GenderName" },
        { text: "Vị trí", value: "PositionName" },
        { text: "Phòng ban", value: "DepartmentName" },
        { text: "Địa chỉ Email", value: "Email" },
        { text: "Số điện thoại", value: "PhoneNumber" },
        { text: "Mức lương", value: "Salary" },
        { text: "Địa chỉ", value: "Address" },
        { text: "Trạng thái công việc", value: "WorkStatusName" },
      ],
      desserts: [
        {
          name: "Frozen Yogurt",
          calories: 159,
          fat: 6.0,
          carbs: 24,
          protein: 4.0,
          iron: "1%",
        },
        {
          name: "Ice cream sandwich",
          calories: 237,
          fat: 9.0,
          carbs: 37,
          protein: 4.3,
          iron: "1%",
        },
        {
          name: "Eclair",
          calories: 262,
          fat: 16.0,
          carbs: 23,
          protein: 6.0,
          iron: "7%",
        },
        {
          name: "Cupcake",
          calories: 305,
          fat: 3.7,
          carbs: 67,
          protein: 4.3,
          iron: "8%",
        },
        {
          name: "Gingerbread",
          calories: 356,
          fat: 16.0,
          carbs: 49,
          protein: 3.9,
          iron: "16%",
        },
        {
          name: "Jelly bean",
          calories: 375,
          fat: 0.0,
          carbs: 94,
          protein: 0.0,
          iron: "0%",
        },
        {
          name: "Lollipop",
          calories: 392,
          fat: 0.2,
          carbs: 98,
          protein: 0,
          iron: "2%",
        },
        {
          name: "Honeycomb",
          calories: 408,
          fat: 3.2,
          carbs: 87,
          protein: 6.5,
          iron: "45%",
        },
        {
          name: "Donut",
          calories: 452,
          fat: 25.0,
          carbs: 51,
          protein: 4.9,
          iron: "22%",
        },
        {
          name: "KitKat",
          calories: 518,
          fat: 26.0,
          carbs: 65,
          protein: 7,
          iron: "6%",
        },
      ],
    };
  },
  async created() {
    const response = await axios.get("api.manhnv.net/api/employees");
    this.employees=response.data;
  },
};
</script>

<style scoped>
.grid-employee {
  margin-top: 10px;
  height: calc(100vh - 234px);
}

.el-avatar-employee {
  padding-top: 16px;
  padding-right: 16px;
}

.el-left {
  width: calc(100% - 180px);
}

.el-avatar-employee .el-avatar {
  border: 1px solid #ccc;
  width: 160px;
  height: 160px;
  margin: 0 auto;
  border-radius: 50%;
  cursor: pointer;
  /* background-image: url("/assets/img/default-avatar.jpg"); */
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}

.el-avatar-note {
  font-size: 12px;
}
.filter-left {
  display: flex;
}
.filter-left select {
  margin-left: 10px;
  margin-right: 10px;
}

.currency-for-input {
  position: absolute;
  right: 40px;
  line-height: 40px;
  font-style: italic;
}

#txtSearchEmployee {
  min-width: 300px;
}
</style>