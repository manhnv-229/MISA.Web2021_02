<template>
  <div id="ContentPageEmployeee">
    <div class="header-main-content">
      <div class="title">Nhân Viên</div>
      <button class="btn add-btn" @click="openDialogEmployeee()">Thêm</button>
    </div>
    <div class="back-web-btn">
      <div class="arrow left"></div>
      <span>Tất cả danh mục</span>
    </div>
    <div class="body-main-content">
      <input
        type="text"
        class="icon-ip searching-img searching-emp"
        placeholder="Tìm theo mã, tên nhân viên"
        @input="filter()"
        v-model="codeOrNameFinding"
      />
      <div class="all-information">
        <table>
          <thead>
            <tr>
              <th>MÃ NHÂN VIÊN</th>
              <th>TÊN NHÂN VIÊN</th>
              <th>CHỨC DANH</th>
              <th>TÊN ĐƠN VỊ</th>
              <th>SỐ TÀI KHOẢN</th>
              <th>TÊN NGÂN HÀNG</th>
              <th>TRẠNG THÁI</th>
              <th>CHI NHÁNH</th>
              <th style="border-right: none">CHỨC NĂNG</th>
            </tr>
          </thead>
          <tbody v-for="(employeee, index) in employeeesDisplay" :key="index">
            <tr>
              <td>{{ employeee.employeeeCode }}</td>
              <td>{{ employeee.fullName }}</td>
              <td>{{ employeee.position }}</td>
              <td>{{ formatOffice(employeee.placeWork) }}</td>
              <td>{{ formatBankCode(employeee.employeeeId) }}</td>
              <td>{{ formatNameBank(employeee.employeeeId) }}</td>
              <td>
                {{
                  formatNameBank(employeee.employeeeId) != ""
                    ? "Đang sử dụng"
                    : ""
                }}
              </td>
              <td>{{ formatBranchBank(employeee.employeeeId) }}</td>
              <td class="menu-fea">
                <button
                  class="ip"
                  style="margin-left: 8px"
                  @click="setUpToEditEmployeee(employeee)"
                >
                  Sửa
                </button>
                <select
                  class="slc"
                  v-model="extraFeature"
                  @change="excuteExtraFeature()"
                >
                  <option
                    :value="
                      '1 ' +
                      employeee.employeeeId +
                      ' ' +
                      employeee.employeeeCode
                    "
                  >
                    Nhân Bản
                  </option>
                  <option
                    :value="
                      '2 ' +
                      employeee.employeeeId +
                      ' ' +
                      employeee.employeeeCode
                    "
                  >
                    Xóa
                  </option>
                  <option
                    :value="
                      '3 ' +
                      employeee.employeeeId +
                      ' ' +
                      employeee.employeeeCode
                    "
                  >
                    Ngưng sử dụng
                  </option>
                </select>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="paging">
        <div class="all-records">
          Tổng số: <b>{{ employeees.length }}</b> bản ghi
        </div>
        <select class="slc records-page">
          <option value="">20 bản ghi trên 1 trang</option>
        </select>
        <div class="choice-page">
          <div class="prev">Trước</div>
          <div
            class="number-page"
            style="font-family: 'notosans-bold'; border: 1px solid black"
          >
            1
          </div>
          <div class="number-page">2</div>
          <div class="number-page">3</div>
          <div class="number-page">...</div>
          <div class="number-page">5</div>
          <div class="next" style="cursor: pointer">Sau</div>
        </div>
      </div>
      <DialogEmployeee
        :showDialog="showDialog"
        :offices="offices"
        :employeeeTodo="employeee"
        :banksTodo="banksOfEmployeee"
        @closeDialog="setUpShowDialog"
      />

      <md-dialog-alert :md-active.sync="showAlert" :md-content="contentAlert" />
      <md-dialog :md-active.sync="showConfirm" @keydown.esc="noConfirmDelete()">
        <div class="confirm-dialog">
          <div class="content-confirm-dialog">
            <div class="warning-img logo-confirm"></div>
            <div class="messege-confirm">
              Bạn thực sự có muốn xóa Nhân viên
              {{ employeeeCodeDeleted }} không?
            </div>
          </div>
          <div class="btn-confirm">
            <button
              class="no-btn-confirm"
              style="margin-left: 15px; margin-top: 15px; width: 75px"
              @click="noConfirmDelete()"
            >
              Không
            </button>
            <button
              class="yes-btn-confirm"
              style="margin-left: 295px; margin-top: 15px; width: 60px"
              @click="confirmDelete()"
            >
              Có
            </button>
          </div>
        </div>
      </md-dialog>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import DialogEmployeee from "../Dialog/DialogEmployeee.vue";
export default {
  components: {
    DialogEmployeee,
  },
  data() {
    return {
      showDialog: false,
      showAlert: false,
      showConfirm: false,

      contentAlert: "",
      contentConfirm: "",

      extraFeature: "",

      codeOrNameFinding: "",

      employeeeIdDeleted: null,
      employeeeCodeDeleted: null,

      employeees: [],
      employeeesDisplay: [],
      banks: [],
      banksOfEmployeee: [],
      offices: [],

      employeee: {
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
      },
    };
  },
  watch: {
    extraFeature: function () {},
  },
  methods: {
    // bat Alert
    openAlert(msg) {
      this.contentAlert = msg;
      this.showAlert = true;
    },

    //filter
    filter() {
      if (this.codeOrNameFinding == "")
        this.employeeesDisplay = this.employeees;
      else {
        this.employeeesDisplay = [];
        for (let i = 0; i < this.employeees.length; i++) {
          if (
            this.employeees[i].employeeeCode.search(this.codeOrNameFinding) !=
              -1 ||
            this.employeees[i].fullName.search(this.codeOrNameFinding) != -1
          )
            this.employeeesDisplay.push(this.employeees[i]);
        }
      }
    },
    //end filter

    //--- phụ ----
    // lưa chọn tính năng thực hiện với nhân viên
    excuteExtraFeature() {
      let excute = this.extraFeature.split(" ");
      if (excute[0] == "2") {
        // goi confirm xoa
        this.showConfirm = true;
        this.employeeeIdDeleted = excute[1];
        this.employeeeCodeDeleted = excute[2];
      }
    },

    // setting tất cả về default
    setUpDefault() {
      axios
        .get("https://localhost:44337/api/v1/banks")
        .then((res) => {
          this.banks = res.data;
          axios
            .get("https://localhost:44337/api/v1/employeees")
            .then((resp) => {
              this.employeees = resp.data;
              this.employeeesDisplay = resp.data;
            })
            .catch((err) => alert(err));
        })
        .catch((err) => alert(err));

      this.extraFeature = "";
      this.codeOrNameFinding = "";
    },
    //--- end phụ

    // xóa nhân viên
    deleteEmployeee(employeeeId) {
      axios
        .delete(
          "https://localhost:44337/api/v1/banks?entityId=" +
            employeeeId +
            "&way=2"
        )
        .then(() => {
          axios
            .delete(
              "https://localhost:44337/api/v1/employeees?entityId=" +
                employeeeId
            )
            .then(() => {
              this.openAlert("Xóa thành công");
              this.setUpDefault();
            })
            .catch((err) => {
              let msg = "";
              for (let i = 0; i < err.response.data.userMsg.length; i++) {
                msg += err.response.data.userMsg[i] + "<br>";
              }
              this.openAlert(msg);
            });
        })
        .catch((error) => {
          let msg = "";
          for (let i = 0; i < error.response.data.userMsg.length; i++) {
            msg += error.response.data.userMsg[i] + "<br>";
          }
          this.openAlert(msg);
        });
    },

    // dialog
    // bấm không Confirm
    noConfirmDelete()
    {
      this.showConfirm = false;
      this.extraFeature = null;
    },
    // bấm Confirm
    confirmDelete() {
      this.showConfirm = false;
      this.extraFeature = null;
      this.deleteEmployeee(this.employeeeIdDeleted);
    },

    // điền sẵn các thông tin của nhân viên vào dialog trước khi edit
    setUpToEditEmployeee(employeeeEdit) {
      this.employeee.address = employeeeEdit.address; // address: (...)
      this.employeee.capacity = employeeeEdit.capacity; // capacity: (...)
      this.employeee.cellPhone = employeeeEdit.cellPhone; // cellPhone: (...)
      this.employeee.email = employeeeEdit.email; // email: (...)
      this.employeee.employeeeCode = employeeeEdit.employeeeCode; // employeeeCode: (...)
      this.employeee.employeeeId = employeeeEdit.employeeeId; // employeeeId: (...)
      this.employeee.fullName = employeeeEdit.fullName; // fullName: (...)
      this.employeee.gender = employeeeEdit.gender; // gender: (...)
      this.employeee.homePhone = employeeeEdit.homePhone; // homePhone: (...)
      this.employeee.identity = employeeeEdit.identity; // identity: (...)
      this.employeee.identityDate = employeeeEdit.identityDate; // identityDate: (...)
      this.employeee.dateOfBirth = employeeeEdit.dateOfBirth; // dateOfBirth: (...)
      this.employeee.identityPlace = employeeeEdit.identityPlace; // identityPlace: (...)
      this.employeee.placeWork = employeeeEdit.placeWork; // placeWork: (...)
      this.employeee.position = employeeeEdit.position; // position: (...)

      for (let i = 0; i < this.banks.length; i++) {
        if (this.banks[i].userId == this.employeee.employeeeId)
          this.banksOfEmployeee.push(this.banks[i]);
      }

      this.showDialog = true;
    },

    // set up biến showDialog sau khi tat Dialog
    setUpShowDialog(showDig, employeeeDefault, banksOfEmployeeeDefault) {
      this.employeee = employeeeDefault;
      this.showDialog = showDig;
      this.banksOfEmployeee = banksOfEmployeeeDefault;
    },

    openDialogEmployeee() {
      this.showDialog = true;
      //lấy mã nhân viên tiếp theo
      var nextEmployeeeCode = parseInt(
        this.employeees[0].employeeeCode.substr(4)
      );
      nextEmployeeeCode++;
      if (nextEmployeeeCode <= 9) nextEmployeeeCode = "00" + nextEmployeeeCode;
      else if (nextEmployeeeCode <= 99)
        nextEmployeeeCode = "0" + nextEmployeeeCode;

      nextEmployeeeCode = "ASNT" + nextEmployeeeCode;

      this.employeee.employeeeCode = nextEmployeeeCode;
    },

    //end dialog

    //format
    formatBankCode(userId) {
      for (let i = 0; i < this.banks.length; i++) {
        if (this.banks[i].userId == userId) return this.banks[i].bankCode;
      }
    },
    formatNameBank(userId) {
      for (let i = 0; i < this.banks.length; i++) {
        if (this.banks[i].userId == userId) return this.banks[i].nameBank;
      }
      return "";
    },
    formatBranchBank(userId) {
      for (let i = 0; i < this.banks.length; i++) {
        if (this.banks[i].userId == userId) return this.banks[i].branchBank;
      }
    },
    formatOffice(placeWork) {
      for (let i = 0; i < this.offices.length; i++) {
        if (this.offices[i].officeId == placeWork)
          return this.offices[i].officeName;
      }
    },
    //end format
  },
  created() {
    axios
      .get("https://localhost:44337/api/v1/offices")
      .then((res) => {
        this.offices = res.data;
      })
      .catch((err) => alert(err));

    axios
      .get("https://localhost:44337/api/v1/banks")
      .then((res) => {
        this.banks = res.data;
        axios
          .get("https://localhost:44337/api/v1/employeees")
          .then((resp) => {
            this.employeees = resp.data;
            this.employeeesDisplay = resp.data;
            console.log(this.employeeesDisplay);
          })
          .catch((err) => alert(err));
      })
      .catch((err) => alert(err));
  },
};
</script>

<style scope>
#ContentPageEmployeee {
  height: 100%;
  width: 100%;
  background-color: #d9d9d9;
}

.header-main-content {
  width: 100%;
  height: 70px;
  display: flex;
  align-items: center;
}

.title {
  font-size: 25px;
  font-family: "notosans-bold";
  margin-left: 16px;
  width: 150px;
}

@media screen and (max-width: 1980px){
    .add-btn {
    width: 60px;
    color: white;
    margin-left: 1497px;
  }
}

@media screen and (max-width: 1820px){
    .add-btn {
    width: 60px;
    color: white;
    margin-left: 1115px;
  }
}

.back-web-btn {
  margin-top: -20px;
  margin-left: 16px;
}

span {
  color: #3366ff;
}

@media screen and (max-width: 1920px) and (max-height: 1050px){
  .body-main-content {
    height: 845px;
    width: calc(100% - 32px);
    background-color: white;
    margin-left: 16px;
    border-radius: 2px;
  }
}

@media screen and (max-width: 1820px) and (max-height: 1050px){
  .body-main-content {
    height: 630px;
    width: calc(100% - 32px);
    background-color: white;
    margin-left: 16px;
    border-radius: 2px;
  }
}

.searching-emp {
  margin-top: 16px;
  margin-left: 16px;
  width: 215px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat 160px -1658px !important;
}

@media screen and (max-height: 1050px){
  .all-information {
    width: 99%;
    height: 745px;
    max-height: 745px;
    overflow: auto;
    margin-top: 8px;
  }
}

@media screen and (max-height: 900px){
  .all-information {
    width: 99%;
    height: 535px;
    max-height: 535px;
    overflow: auto;
    margin-top: 8px;
  }
}

.menu-fea {
  border-right: none;
  cursor: pointer;
  max-width: 70px;
}

.menu-fea .ip {
  text-align: center;
  cursor: pointer;
  border: none;
  width: 60px;
}

.menu-fea .slc {
  width: 19px;
  height: 20px;
  margin-left: 20px;
}

.menu-fea .slc:focus-within {
  outline: 1px solid black;
}

.paging {
  height: 40px;
  width: 100%;
  display: flex;
  align-items: center;
}

.all-records {
  margin-left: 16px;
  width: 150px;
}

@media screen and (max-width: 1920px){
  .records-page {
    margin-left: 1125px;
    width: 200px;
    border: 1px solid black !important;
    height: 30px;
  }
}


@media screen and (max-width: 1820px){
  .records-page {
    margin-left: 775px;
    width: 200px;
    border: 1px solid black !important;
    height: 30px;
  }
}
.choice-page {
  margin-left: 15px;
  display: flex;
  height: 20px;
  width: 200px;
}

.prev {
  height: 20px;
  width: 40px;
  margin-right: 10px;
}

.next {
  height: 20px;
  width: 40px;
  margin-left: 10px;
}

.number-page {
  height: 20px;
  width: 20px;
  text-align: center;
}

.confirm-dialog {
  width: 460px;
  height: 200px;
}

.content-confirm-dialog {
  display: flex;
  width: 430px;
  height: 130px;
  align-items: center;
  justify-content: center;
  border-bottom: 1px solid #d9d9d9;
  margin: auto;
}

.logo-confirm {
  height: 60px;
  width: 60px;
}

.messege-confirm {
  font-size: 15px;
  width: 330px;
}
</style>