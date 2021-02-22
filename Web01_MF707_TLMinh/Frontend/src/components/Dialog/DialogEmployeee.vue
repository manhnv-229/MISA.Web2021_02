<template>
  <md-dialog
    :md-active.sync="showDialog"
    @keydown.esc="closeDialog()"
    @md-clicked-outside="closeDialog()"
  >
    <div class="main-dialog">
      <div class="header-dialog">
        <div class="title-dialog">Thông tin nhân viên</div>
        <input
          type="checkbox"
          style="margin-left: 20px"
          v-model="checkedCustomer"
        />
        Là khách hàng
        <input
          type="checkbox"
          style="margin-left: 28px"
          v-model="checkedProvider"
        />
        Là nhà cung cấp
      </div>
      <div class="body-dialog">
        <div class="line-information">
          <div class="title-input">
            <span style="margin-left: 20px">Mã<b style="color: red">*</b></span>
            <span style="margin-left: 119px"
              >Tên<b style="color: red">*</b></span
            >
            <span style="margin-left: 202px">Ngày sinh</span>
            <span style="margin-left: 90px">Giới tính</span>
          </div>
          <div class="content-input">
            <input
              id="focus-infor"
              @blur="$v.employeee.employeeeCode.$touch()"
              :class="{ 'border-red': $v.employeee.employeeeCode.$error }"
              v-model.trim="$v.employeee.employeeeCode.$model"
              type="text"
              class="ip"
              style="width: 140px; margin-left: 20px"
            />
            <input
              @blur="$v.employeee.fullName.$touch()"
              :class="{ 'border-red': $v.employeee.fullName.$error }"
              v-model.trim="$v.employeee.fullName.$model"
              type="text"
              class="ip"
              style="width: 210px; margin-left: 8px"
            />
            <input
              v-model="employeee.dateOfBirth"
              type="date"
              class="ip"
              style="margin-left: 20px"
            />
            <label class="cb" style="margin-left: 8px">
                <input type="checkbox" class="cb" v-model="checkedGenderBoy"/>
                <span style="margin-left: 4px">Nam</span>
            </label>
            <label class="cb" style="margin-left: 16px">
                <input type="checkbox" class="cb" v-model="checkedGenderGirl"/>
                <span style="margin-left: 4px"> Nữ</span>
            </label>
          </div>
        </div>
        <div class="line-notify">
          <div
            class="notify"
            style="top: 106px; left: 20px"
            v-show="$v.employeee.employeeeCode.$error"
          >
            Không được để trống!
          </div>
          <div
            class="notify"
            style="top: 106px; left: 167px"
            v-show="$v.employeee.fullName.$error"
          >
            Không được để trống!
          </div>
        </div>
        <div class="line-information">
          <div class="title-input">
            <span style="margin-left: 20px">Đơn vị</span>
            <span style="margin-left: 339px"
              >Số CMND<b style="color: red">*</b></span
            >
            <span style="margin-left: 160px">Ngày cấp</span>
          </div>
          <div class="content-input">
            <select
              class="slc"
              style="width: 358px; margin-left: 20px"
              v-model="employeee.placeWork"
            >
              <option
                v-for="(office, index) in offices"
                :key="index"
                :value="office.officeId"
              >
                {{ office.officeName }}
              </option>
            </select>
            <input
              @blur="$v.employeee.identity.$touch()"
              :class="{ 'border-red': $v.employeee.identity.$error }"
              v-model="$v.employeee.identity.$model"
              type="text"
              class="ip"
              style="width: 220px; margin-left: 20px"
            />
            <input
              v-model="employeee.identityDate"
              type="date"
              class="ip"
              style="margin-left: 8px; width: 160px"
            />
          </div>
        </div>
        <div class="line-notify">
          <div
            class="notify"
            style="margin-left: 399px; margin-top: -15px"
            v-show="$v.employeee.identity.$error"
          >
            Không được để trống!
          </div>
        </div>
        <div class="line-information">
          <div class="title-input">
            <span style="margin-left: 20px">Chức danh</span>
            <span style="margin-left: 311px">Nơi cấp</span>
          </div>
          <div class="content-input">
            <input
              v-model="employeee.position"
              type="text"
              class="ip"
              style="width: 358px; margin-left: 20px"
            />
            <input
              v-model="employeee.identityPlace"
              type="text"
              class="ip"
              style="width: 388px; margin-left: 20px"
            />
          </div>
        </div>

        <div class="tab">
          <button
            class="choice-tab"
            @click="showTab = true"
            :class="{ choosen: showTab }"
          >
            Liên hệ
          </button>
          <button
            class="choice-tab"
            @click="showTab = false"
            :class="{ choosen: !showTab }"
          >
            Tài khoản ngân hàng
          </button>
          <div class="content-tab">
            <div v-show="showTab" class="infor-connetion">
              <div class="line-information" style="margin-top: 10px">
                <div class="title-input">
                  <span style="margin-left: 10px">Địa chỉ</span>
                </div>
                <div class="content-input">
                  <input
                    v-model="employeee.address"
                    type="text"
                    class="ip"
                    style="width: 750px; margin-left: 10px"
                  />
                </div>
              </div>
              <div class="line-information" style="margin-top: 10px">
                <div class="title-input">
                  <span style="margin-left: 10px">ĐT di động</span>
                  <span style="margin-left: 123px">ĐT cố định</span>
                  <span style="margin-left: 124px">Email</span>
                </div>
                <div class="content-input">
                  <input
                    v-model="employeee.cellPhone"
                    type="text"
                    class="ip"
                    style="width: 185px; margin-left: 8px"
                  />
                  <input
                    v-model="employeee.homePhone"
                    type="text"
                    class="ip"
                    style="width: 185px; margin-left: 8px"
                  />
                  <input
                    v-model="employeee.email"
                    type="text"
                    class="ip"
                    style="width: 185px; margin-left: 8px"
                  />
                </div>
              </div>
            </div>
            <div v-show="!showTab" class="infor-bank">
              <table>
                <thead>
                  <tr>
                    <th>SỐ TÀI KHOẢN</th>
                    <th>NGÂN HÀNG</th>
                    <th>CHI NHÁNH</th>
                    <th>TỈNH/TP CỦA NGÂN HÀNG</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody v-for="(bank, index) in banksOfEmployeee" :key="index">
                  <tr>
                    <td>
                      <input
                        v-model="bank.bankCode"
                        type="text"
                        style="width: 100px"
                      />
                    </td>
                    <td>
                      <input
                        v-model="bank.nameBank"
                        type="text"
                        style="width: 150px"
                      />
                    </td>
                    <td><input type="text" v-model="bank.branchBank" /></td>
                    <td><input type="text" v-model="bank.placeBank" /></td>
                    <td
                      class="delete-img delete-fea"
                      @click="deleteBank(index)"
                    ></td>
                  </tr>
                </tbody>
              </table>
              <button
                class="btn-w"
                style="margin-left: 16px; margin-top: 5px"
                @click="addBank()"
              >
                Thêm dòng
              </button>
              <button
                class="btn-w"
                style="margin-left: 6px"
                @click="deleteAllBanks()"
              >
                Xóa hết dòng
              </button>
            </div>
          </div>
        </div>
      </div>
      <div class="footer-dialog">
        <button class="btn-w close-btn" @click="closeDialog()">Hủy</button>
        <button class="btn-w edit-btn" @click="editEmployeee()">Cất</button>
        <button class="btn add-btn" @click="addEmployeee()">Cất và thêm</button>
      </div>
      <md-dialog-alert :md-active.sync="showAlert" :md-content="contentAlert" />
    </div>
  </md-dialog>
</template>

<script>
import axios from "axios";
import { required } from "vuelidate/lib/validators";
export default {
  props: ["showDialog", "offices", "employeeeTodo", "banksTodo"],
  data() {
    return {
      checkedCustomer: null,
      checkedProvider: null,
      checkedGenderBoy: true,
      checkedGenderGirl: false,

      contentAlert: "",
      showAlert: false,
      showTab: true,

      banksOfEmployeee: [],

      employeeeCodeEdit: null,
      identityEdit: null,

      employeee: {
        address: "",
        capacity: null,
        cellPhone: "",
        dateOfBirth: null,
        email: "",
        employeeeCode: "",
        employeeeId: null,
        fullName: null,
        gender: 1,
        homePhone: "",
        identity: "",
        identityDate: "",
        identityPlace: "",
        placeWork: "",
        position: "",
      },
    };
  },
  validations: {
    employeee: {
      employeeeCode: {
        required,
      },
      fullName: {
        required,
      },
      identity: {
        required,
      },
    },
  },
  methods: {
    //validate
    validate() {
      this.$v.$touch();
      if (this.$v.$invalid) return false;
      return true;
    },

    //------phụ--------
    // format
    // format ngày
    formatInputDate(date) {
      if (date == null) return null;
      else {
        let d = new Date(date);
        return (
          d.getFullYear() +
          "-" +
          (d.getMonth() + 1 < 10
            ? "0" + (d.getMonth() + 1)
            : d.getMonth() + 1) +
          "-" +
          (d.getDate() < 10 ? "0" + d.getDate() : d.getDate())
        );
      }
    },

    //format gioi tinh
    formatGender() {
      if (this.employeeeTodo.gender == 1) {
        this.checkedGenderBoy = true;
        this.checkedGenderGirl = false;
      } else {
        this.checkedGenderBoy = false;
        this.checkedGenderGirl = true;
      }
    },

    //format chức danh(capacity)
    formatCapacity() {
      if (this.employeeeTodo.capacity == null) {
        this.checkedCustomer = null;
        this.checkedProvider = null;
        return;
      }

      if (this.employeeeTodo.capacity == 0) {
        this.checkedCustomer = false;
        this.checkedProvider = true;
      } else {
        this.checkedCustomer = true;
        this.checkedProvider = false;
      }
    },

    //------end phụ-------

    // them sua nhan vien
    handleInfo() {
      if (this.employeee.dateOfBirth == "NaN-NaN-NaN")
        this.employeee.dateOfBirth = null;
      if (this.employeee.identityDate == "NaN-NaN-NaN")
        this.employeee.identityDate = null;

      if (
        this.checkedCustomer == null &&
        this.checkedProvider == null &&
        this.checkedCustomer == false &&
        this.checkedProvider == false
      )
        this.employeee.capacity = null;
      else {
        if (this.checkedCustomer) this.employeee.capacity = 1;
        else if (this.checkedProvider) this.employeee.capacity = 0;
      }

      if (this.checkedGenderBoy) this.employeee.gender = 1;
      else this.employeee.gender = 0;

      if (this.employeee.placeWork == "") this.employeee.placeWork = null;
    },

    addEmployeee() {
      // xu li du lieu
      this.handleInfo();
      // validate du lieu
      if (!this.validate()) {
        this.contentAlert = "Bạn vui lòng xem lại thông tin đã nhập!";
        this.showAlert = true;
        return;
      }
      //them du lieu
      let isComplete = 0;
      axios
        .post("https://localhost:44337/api/v1/employeees", this.employeee)
        .then((response) => {
          if (this.banksOfEmployeee.length == 0) {
            this.$parent.openAlert("Thêm thành công");
            this.$parent.setUpDefault();
            this.closeDialog();
          } else {
            for (var i = 0; i < this.banksOfEmployeee.length; i++) {
              axios
                .post(
                  "https://localhost:44337/api/v1/banks?entityCode=" +
                    this.employeee.employeeeCode,
                  this.banksOfEmployeee[i]
                )
                .then(() => {
                  isComplete++;
                  if (
                    isComplete == this.banksOfEmployeee.length &&
                    response.data == 1
                  ) {
                    this.$parent.openAlert("Thêm thành công");
                    this.$parent.setUpDefault();
                    this.closeDialog();
                  }
                })
                .catch((err) => {
                  this.contentAlert = "";
                  for (let i = 0; i < err.response.data.userMsg.length; i++) {
                    this.contentAlert += err.response.data.userMsg[i] + "<br>";
                  }
                  this.showAlert = true;
                });
            }
          }
        })
        .catch((error) => {
          this.contentAlert = "";
          for (let i = 0; i < error.response.data.userMsg.length; i++) {
            this.contentAlert += error.response.data.userMsg[i] + "<br>";
          }
          this.showAlert = true;
        });
    },

    editEmployeee() {
      // xu li du lieu
      this.handleInfo();
      // validate du lieu
      if (!this.validate()) {
        this.contentAlert = "Bạn vui lòng xem lại thông tin đã nhập!";
        this.$parent.openAlert(this.contentAlert);
        return;
      }
      let doSuccess = 0;
      // sửa thông tin nhân viên
      console.log(this.employeee);
      axios
        .put(
          "https://localhost:44337/api/v1/employeees?entityCode=" +
            this.employeeeCodeEdit +
            "&identity=" +
            this.identityEdit,
          this.employeee
        )
        .then((res) => {
          if (res.data == 1) {
            doSuccess++;
          }
          if (doSuccess == this.banksOfEmployeee.length + 1) {
            this.contentAlert = "Sửa thành công";
            this.$parent.openAlert(this.contentAlert);
            this.$parent.setUpDefault();
            this.closeDialog();
          }
          
          if(res.data == 0)
          {
            this.contentAlert = "Nhân viên này chưa có trong danh sách để sửa thông tin";
            this.showAlert = true;
          }
        })
        .catch((err) => {
          this.contentAlert = "";
          for (let i = 0; i < err.response.data.userMsg.length; i++) {
            this.contentAlert += err.response.data.userMsg[i] + "<br>";
          }
          this.showAlert = true;
        });

      // sửa thông tin tài khoản của nhân viên
      axios
        .delete(
          "https://localhost:44337/api/v1/banks?entityId=" +
            this.employeee.employeeeId +
            "&way=2"
        )
        .then(() => {
          for (let i = 0; i < this.banksOfEmployeee.length; i++) {
            this.banksOfEmployeee[i].userId = this.employeee.employeeeId;
            axios
              .post(
                "https://localhost:44337/api/v1/banks",
                this.banksOfEmployeee[i]
              )
              .then((res) => {
                if (res.data == 1) {
                  doSuccess++;
                }
                if (doSuccess == this.banksOfEmployeee.length + 1) {
                  this.contentAlert = "Sửa thành công";
                  this.$parent.openAlert(this.contentAlert);
                  this.$parent.setUpDefault();
                  this.closeDialog();
                }
              })
              .catch((err) => {
                this.contentAlert = "";
                for (let i = 0; i < err.response.data.userMsg.length; i++) {
                  this.contentAlert += err.response.data.userMsg[i] + "<br>";
                }
                this.showAlert = true;
              });
          }
        })
        .catch((error) => {
          this.contentAlert = "";
          for (let i = 0; i < error.response.data.userMsg.length; i++) {
            this.contentAlert += error.response.data.userMsg[i] + "<br>";
          }
          this.showAlert = true;
        });
    },

    // end them sua nhan vien

    // su kien cac nut tat, luu, them moi nhan vien
    closeDialog() {
      var employeeeDefault = {
        address: "",
        capacity: null,
        cellPhone: "",
        email: "",
        dateOfBirth: null,
        employeeeCode: "",
        employeeeId: null,
        fullName: "",
        gender: 1,
        homePhone: "",
        identity: "",
        identityDate: null,
        identityPlace: "",
        placeWork: "",
        position: "",
      };

      this.banksOfEmployeee = [];
      this.$emit("closeDialog", false, employeeeDefault, this.banksOfEmployeee);
      this.$v.$reset();
    },

    // them xoa bank
    addBank() {
      var bank = {
        bankCode: "",
        bankId: null,
        branchBank: "",
        nameBank: "",
        placeBank: "",
        userId: null,
      };
      this.banksOfEmployeee.push(bank);
    },
    deleteBank(index) {
      this.banksOfEmployeee.splice(index, 1);
    },
    deleteAllBanks() {
      this.banksOfEmployeee = [];
    },
  },
  watch: {
    showDialog: function () {
      this.employeee.address = this.employeeeTodo.address; // address: (...)
      this.employeee.capacity = this.formatCapacity(); // capacity: (...)
      this.employeee.cellPhone = this.employeeeTodo.cellPhone; // cellPhone: (...)
      this.employeee.email = this.employeeeTodo.email; // email: (...)
      this.employeee.employeeeCode = this.employeeeTodo.employeeeCode; // employeeeCode: (...)
      this.employeee.employeeeId = this.employeeeTodo.employeeeId; // employeeeId: (...)
      this.employeee.fullName = this.employeeeTodo.fullName; // fullName: (...)
      this.employeee.gender = this.formatGender(); // gender: (...)
      this.employeee.homePhone = this.employeeeTodo.homePhone; // homePhone: (...)
      this.employeee.identity = this.employeeeTodo.identity; // identity: (...)
      this.employeee.identityDate = this.formatInputDate(
        this.employeeeTodo.identityDate
      ); // identityDate: (...)
      this.employeee.dateOfBirth = this.formatInputDate(
        this.employeeeTodo.dateOfBirth
      ); // dateOfBirth: (...)
      this.employeee.identityPlace = this.employeeeTodo.identityPlace; // identityPlace: (...)
      this.employeee.placeWork = this.employeeeTodo.placeWork; // placeWork: (...)
      this.employeee.position = this.employeeeTodo.position; // position: (...)

      this.banksOfEmployeee = this.banksTodo;
      this.employeeeCodeEdit = this.employeeeTodo.employeeeCode;
      this.identityEdit = this.employeeeTodo.identity;
    },

    checkedGenderBoy: function () {
      if (this.checkedGenderBoy == true) this.checkedGenderGirl = false;
      else this.checkedGenderGirl = true;
    },
    checkedGenderGirl: function () {
      if (this.checkedGenderGirl == true) this.checkedGenderBoy = false;
      else this.checkedGenderBoy = true;
    },
    checkedCustomer: function () {
      if (this.checkedCustomer == true) this.checkedProvider = false;
    },
    checkedProvider: function () {
      if (this.checkedProvider == true) this.checkedCustomer = false;
    },
  },
};
</script>

<style>
.main-dialog {
  width: 810px;
  height: 600px;
}

.infor-bank table {
  width: 96% !important;
  background-color: #d9d9d9 !important;
}

.infor-bank table tbody tr {
  height: 35px !important;
}

.infor-bank table td,
th {
  width: 25px !important;
  padding-left: 8px;
}

input[type="text"],
input[type="date"] {
  height: 30px !important;
}

input:focus {
  outline: 1px solid black !important;
}

input[type="checkbox"]:focus {
  outline: none !important;
}

.content-input{
  display: flex;
  align-items: center;
}

.content-input select {
  border: 1px solid #d9d9d9 !important;
  height: 30px;
}

.content-input select:focus {
  outline: 1px solid black !important;
}

.header-dialog {
  display: flex;
  height: 10%;
  width: 100%;
  align-items: center;
}

.title-dialog {
  margin-left: 20px;
  font-size: 22px;
  font-family: "notosans-bold";
}

.body-dialog {
  width: 100%;
  height: 80%;
  font-size: 13px;
}

.body-dialog span {
  color: black !important;
  font-family: "notosans-semibold";
}

.line-information {
  width: 100%;
  height: 13%;
}

.tab {
  margin-left: 20px;
  margin-top: 10px;
  width: 95%;
  height: 60%;
  border-bottom: 1px solid #d9d9d9;
}

.choice-tab {
  background-color: white;
  margin-right: 2px;
  border: 1px solid darkgray;
  border-radius: 1px !important;
}

.choosen {
  padding-top: 10px;
  background-color: #d9d9d9;
  margin-bottom: 5px;
}

.content-tab {
  margin-top: -5px;
  width: 100%;
  height: 80%;
  border: 1px solid #d9d9d9;
}

.content-tab .infor-connection,
.infor-bank {
  height: 100%;
  width: 100%;
}

.infor-bank {
  overflow: scroll;
}

.delete-fea {
  cursor: pointer;
}

.footer-dialog .add-btn {
  border-radius: 2px !important;
  height: 35px !important;
  width: 100px;
  color: white;
  margin-left: 10px;
}

.close-btn {
  height: 35px !important;
  width: 60px;
  margin-left: 20px;
  margin-top: 10px;
}

.edit-btn {
  height: 35px !important;
  width: 60px;
  margin-left: 540px;
  margin-top: 10px;
}

.line-notify {
  display: flex;
}

.notify {
  position: absolute;
  color: red;
  font-family: "notosans-italic";
  font-size: 10px;
}

.border-red {
  border: 1px solid red !important;
}

</style>
