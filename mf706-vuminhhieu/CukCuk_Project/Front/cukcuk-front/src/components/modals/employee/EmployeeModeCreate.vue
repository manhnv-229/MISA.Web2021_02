<template>
  <BaseModalConfirm ref="BaseForm_ref">
    <div class="h-dialog-content">
      <div class="h-dialog-header">
        <div class="h-dialog-header-title">Thông tin nhân viên</div>
        <div class="h-dialog-header-close">
          <button id="btnCancel" v-on:click="hide()"></button>
        </div>
      </div>
      <div class="h-dialog-content-body">
        <div class="col-xs-3 ml-2">
          <img
            src="~@/content/img/default-avatar.jpg"
            class="default-avt img-circle"
          />

          <p>(Vui lòng chọn ảnh có địng dạng .jpg, .jpeg, .png, .gif)</p>
          <input type="file" id="avtUpdate" style="display: none" />
        </div>
        <div class="col-xs-9 ml-2 mr-1 h-container-column">
          <div>
            <div class="group-label-info">A. Thông tin chung</div>
            <hr class="hr-group-label" />
          </div>
          <div>
            <div class="col-xs-6 h-container-column pd-1">
              <div class="form-group">
                <p class="label-text">
                  Mã nhân viên(<span class="required">*</span>)
                </p>
                <input
                  type="text"
                  id="em-code"
                  class="form-control"
                  required
                  v-model="employee.employeeCode"
                />
              </div>
              <div class="form-group">
                <p class="label-text">Ngày sinh</p>
                <input
                  type="date"
                  id="em-birth"
                  class="form-control"
                  placeholder="mm/dd/yyyy"
                  v-model="employee.dateOfBirth"
                />
              </div>

              <div class="form-group">
                <p class="label-text">
                  Số CMTND/ Căn cước(<span class="required">*</span>)
                </p>
                <input
                  type="text"
                  id="em-identification"
                  class="form-control"
                  required
                  v-model="employee.identityCardNumber"
                />
              </div>
            </div>

            <div class="col-xs-6 h-container-column">
              <div class="form-group">
                <p class="label-text">
                  Họ và tên(<span class="required">*</span>)
                </p>
                <input
                  type="text"
                  id="em-name"
                  class="form-control"
                  required
                  v-model="employee.fullName"
                />
              </div>
              <div class="form-group">
                <p class="label-text">Giới tính</p>
                <select
                  id="em-gender"
                  dataIndex="Gender"
                  class="form-control"
                  fieldValue="value"
                  fieldText="text"
                  apiGetUrl="/api/v1/enums/gender"
                  v-model="employee.gender"
                >
                  <option value="1">Nam</option>
                  <option value="0">Nữ</option>
                  <option value="2">Khác</option>
                </select>
              </div>

              <div class="form-group">
                <p class="label-text">Ngày cấp</p>
                <input
                  type="date"
                  id="em-birth"
                  class="form-control"
                  placeholder="mm/dd/yyyy"
                  v-model="employee.identityDate"
                />
              </div>
            </div>
          </div>
          <div>
            <div class="col-xs-6 h-container-column pd-1">
              <div class="form-group">
                <p class="label-text">Nơi cấp</p>
                <input
                  type="text"
                  class="form-control"
                  id="em-identifyPlace"
                  v-model="employee.identityPlace"
                />
              </div>
            </div>
          </div>
          <div>
            <div class="col-xs-6 h-container-column pd-1">
              <div class="form-group">
                <p class="label-text">email(<span class="required">*</span>)</p>
                <input
                  type="email"
                  id="em-email"
                  class="form-control"
                  required
                  v-model="employee.email"
                />
              </div>
            </div>
            <div class="col-xs-6 h-container-column pd-1">
              <div class="form-group">
                <p class="label-text">
                  Số điện thoại(<span class="required">*</span>)
                </p>
                <input
                  type="text"
                  id="em-phone"
                  class="form-control"
                  required
                  v-model="employee.phoneNumber"
                />
              </div>
            </div>
          </div>
          <div>
            <div class="group-label-info">B. Thông tin công việc</div>
            <hr class="hr-group-label" />
          </div>
          <div>
            <div class="col-xs-6 h-container-column pd-1">
              <div class="form-group">
                <p class="label-text">Vị trí</p>
                <select
                  id="em-position"
                  fieldName="positionName"
                  fieldValue="positionId"
                  class="form-control"
                  api="https://localhost:44376/api/EmployeePositions"
                  v-model="employee.positionId"
                >
                  <option value="3700cc49-55b5-69ea-4929-a2925c0f334d">
                    Giám đốc
                  </option>
                  <option value="25c6c36e-1668-7d10-6e09-bf1378b8dc91">
                    Thu ngân
                  </option>
                  <option value="148ed882-32b8-218e-9c20-39c2f00615e8">
                    Nhân viên Marketing
                  </option>
                </select>
              </div>
              <div class="form-group">
                <p class="label-text">Mã số thuế cá nhân</p>
                <input
                  type="text"
                  id="em-tax"
                  class="form-control"
                  v-model="employee.taxCode"
                />
              </div>
              <div class="form-group">
                <p class="label-text">Ngày gia nhập công ty</p>
                <input
                  type="date"
                  id="em-dateJoin"
                  class="form-control"
                  v-model="employee.dateJoin"
                />
              </div>
            </div>
            <div class="col-xs-6 h-container-column">
              <div class="form-group">
                <p class="label-text">Phòng ban</p>
                <select
                  id="em-department"
                  fieldName="departmentName"
                  fieldValue="departmentId"
                  class="form-control"
                  api="https://localhost:44376/api/EmployeeDepartments"
                  v-model="employee.departmentId"
                >
                  <option value="17120d02-6ab5-3e43-18cb-66948daf6128">
                    Phòng đào tạo
                  </option>
                  <option value="4e272fc4-7875-78d6-7d32-6a1673ffca7c">
                    Phòng công nghệ
                  </option>
                  <option value="469b3ece-744a-45d5-957d-e8c757976496">
                    Phòng nhân sự
                  </option>
                  <option value="142cb08f-7c31-21fa-8e90-67245e8b283e">
                    Phòng Marketting
                  </option>
                </select>
              </div>

              <div class="form-group pos-relative">
                <p class="label-text">Mức lương cơ bản</p>

                <input
                  type="text"
                  id="em-salary"
                  class="text-align-right pr-45 form-control"
                  v-model="employee.salary"
                />
                <span class="currency-for-input">(VNĐ)</span>
              </div>
              <div class="form-group">
                <p class="label-text">Tình trạng công việc</p>
                <select
                  id="cbxworkStatus"
                  class="form-control"
                  v-model="employee.workStatus"
                >
                  <option value="1">Đang làm việc</option>
                  <option value="2">Đang thử việc</option>
                  <option value="0">Đã nghỉ việc</option>
                </select>
              </div>
            </div>
          </div>
        </div>

        <!--<div class="dialog-btn">

                    </div>-->
      </div>
      <div class="h-dialog-footer h-container-end-center">
        <button
          class="h-btn h-cancel-btn"
          id="btnCancel"
          v-on:click="visible = false"
        >
          Hủy
        </button>
        <button class="h-btn h-save-btn" id="btnSave" v-on:click="Confirm()">
          <i class="fa fa-floppy-o" aria-hidden="true"></i>Lưu
        </button>
      </div>
    </div>
  </BaseModalConfirm>
</template>

<script>
import * as axios from "axios";
import BaseModalConfirm from "../BaseModalForm.vue";
export default {
  // props: {
  //     showModal: Boolean
  // }, pr
  data() {
    return {
      visible: false,
      employee: {       
            employeeCode: "",
            fullName: "",
            dateOfBirth: "",
            gender: null,
            identityCardNumber: "",
            identityDate: "",
            identityPlace: "",
            email: "",
            phoneNumber: "",
            positionId: "",
            departmentId: "",
            taxCode: "",
            salary: null,
            dateJoin: "",
            workStatus: null
      },
     
    };
  },
  components: {
    BaseModalConfirm,
  },
  methods: {
    hide: async function () {
      this.$refs.BaseForm_ref.hide();
    },
    show: async function () {
      this.$refs.BaseForm_ref.show();
    },

    Confirm: async function () {
      var confirm = false;
      console.log(this.employee);
      await axios
        .post("https://localhost:44339/api/employee", this.employee)
        .then(function (res) {
          console.log("success: " + res);
          confirm = true;
        })
        .catch(function (err) {
          console.log("false: " + err);
          confirm = false;
        });

      this.$emit("created", confirm);
    },
  },
};
</script>

<style src="../modal.scss" lang="scss" />

