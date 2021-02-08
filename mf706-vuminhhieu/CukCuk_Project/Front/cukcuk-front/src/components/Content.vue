<template>
  <div class="content">
    <section class="content-header h-container-between-center">
      <h1>Danh sách sinh viên</h1>

      <button
        type="button"
        class="h-btn"
        id="btnAdd"
        data-toggle="modal"
        v-on:click="openEmployeeModeCreate()"
      >
        <i class="h-icon h-icon-add"></i> &nbsp; Thêm mới
      </button>

      <!-- /.container-fluid -->
    </section>
    <!-- /.Header content -->
    <section class="content-main">
      <!-- control content -->
      <div class="h-container-row">
        <div class="col-md-3">
          <div class="form-group">
            <input
              type="search"
              class="form-control input-search h-icon-search"
              placeholder="Tìm kiếm theo mã nhân viên, họ tên..."
              aria-controls="example1"
              name="searching"
            />
          </div>
        </div>
        <div class="col-md-2">
          <!-- select -->
          <div class="form-group">
            <select class="form-control" name="PhongBan" id="PhongBan">
              <option value="0" selected>-Tất cả phòng ban--</option>
              <option value="1">Phòng Đào tạo</option>
              <option value="2">Phòng Công nghệ</option>
              <option value="3">Phòng Narketing</option>
              <option value="4">Phòng Nhân sự</option>
            </select>
          </div>
        </div>
        <div class="col-md-2">
          <!-- select -->
          <div class="form-group">
            <select class="form-control" name="ViTri" id="ViTri">
              <option value="0" selected>--Tất cả vị trí--</option>
              <option value="1">Giám đốc</option>
              <option value="2">Thu ngân</option>
              <option value="3">Nhân viên Marketing</option>
            </select>
          </div>
        </div>
        <div class="col-md-2"></div>

        <div class="col-md-3 ml-auto h-container-end">
          <button id="btnSearch" class="h-second-button h-btn-search"></button>
          <button id="btnUpdate" class="h-second-button" @click="openEditModal()">Sửa</button>
          <button id="btnDelete" class="h-second-button" @click="openDeleteModal()">Xóa</button>
          <button
            id="btnRefresh"
            class="h-second-button h-btn-refresh"
            @click="reloadData()"
          ></button>
        </div>

        <!-- /.control content -->
      </div>
      <Table msg="Welcome to Your Vue.js App"  ref="table_ref" />
      <Footer msg="Welcome to Your Vue.js App" class="content-footer" />
      <EmployeeModeCreate ref="EmployeeModeCreate_ref" @created="createCofirm"
        id="createNV"       
      />
     
    </section>
  </div>
</template>

<script>
import Table from "./table/Table.vue";
import Footer from "./footer/Footer.vue";
import EmployeeModeCreate from "./modals/employee/EmployeeModeCreate.vue";


export default {
  name: "Content",
  data() {
    return {     
     
    };
  },
  components: {
    Table,
    Footer,
    EmployeeModeCreate,
    
  }, 
  methods: {
    openEmployeeModeCreate() {
      
      this.$refs.EmployeeModeCreate_ref.show(); 

      // do stuff with the data received by the modal
    },
    createCofirm : async function(){
       alert("Thêm mới thành công");
       var getData = this.$refs.table_ref.getData();      
       this.$refs.EmployeeModeCreate_ref.hide();
      getData.await;

    },
    openEditModal: async function() {
      await this.$refs.table_ref.showEmployeeModalEdit();
    },
    openDeleteModal() {
      this.$refs.table_ref.showEmployeeModalDelete();
    },
    reloadData: async function(){
      await this.$refs.table_ref.getData();  
      
    }
    
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.content {
  position: relative;
  margin-left: 201px;
  width: calc(100%-201px);
  background-color: azure;

  padding: 2px;
}
.content-main {
  margin-left: 10px;
  margin-right: 10px;
}

.content-header {
  margin: 0.5rem 1rem 0.5rem 1rem;
}

.content-footer {
  margin-left: 10px;
  margin-right: 10px;
  height: 56px;
  border-top: 2px solid #bbbbbb;
  position: relative;
  padding: 0 16px;
}
</style>
