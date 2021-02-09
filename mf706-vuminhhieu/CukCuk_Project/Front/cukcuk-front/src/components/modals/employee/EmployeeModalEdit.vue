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
          <img src="~@/content/img/default-avatar.jpg" class="default-avt img-circle">

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
                <input type="text" id="em-code" class="form-control" required v-model="employee.employeeCode" />
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
                type="text" id="em-name" class="form-control" required 
                v-model="employee.fullName"/>
              </div>
              <div class="form-group">
                <p class="label-text">Giới tính</p>
                <select
                  id="em-gender"
                  dataIndex="gender"
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
                <input type="text" class="form-control" id="em-identifyPlace"
                v-model="employee.identityPlace" />
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
                  <option value="19165ed7-212e-21c4-0428-030d4265475f">
                    Giám đốc
                  </option>
                  <option value="3631011e-4559-4ad8-b0ad-cb989f2177da">
                    Trưởng phòng
                  </option>
                  <option value="3631011e-4559-4ad8-b0ad-cb989f2177da">
                    Nhân viên
                  </option>
                </select>
              </div>
              <div class="form-group">
                <p class="label-text">Mã số thuế cá nhân</p>
                <input type="text" id="em-tax" class="form-control" 
                v-model="employee.taxCode"/>
              </div>
              <div class="form-group">
                <p class="label-text">Ngày gia nhập công ty</p>
                <input type="date" id="em-dateJoin" class="form-control"
                v-model="employee.dateJoin" />
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
                  <option value="34bd2cef-5026-567c-3b71-153b37881afe">
                    Phòng đào tạo
                  </option>
                  <option value="43a6bdf5-1b6b-451b-3695-2c566fa88632">
                    Phòng công nghệ
                  </option>
                  <option value="64a59a25-2488-54b0-f6b4-c8af08a50cbf">
                    Phòng nhân sự
                  </option>
                  <option value="674934cc-42cf-20cf-1d4a-aea48a10ed18">
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
                <select id="cbxworkStatus" class="form-control" v-model="employee.workStatus" >
                  <option value="1">Đang làm việc</option>
                  <option value="2">Đang thử việc</option>
                  <option value="0">Đã nghỉ việc</option>
                </select>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="h-dialog-footer h-container-end-center">
        <button
          class="h-btn h-cancel-btn"
          id="btnCancel"
          v-on:click="hide()"
        >
          Hủy
        </button>
        <button class="h-btn h-save-btn" id="btnSave" v-on:click="Confirm()">
          <i class="fa fa-floppy-o" aria-hidden="true" ></i>Lưu
        </button>
      </div>
    </div>
  </BaseModalConfirm>
</template>

<script>
import * as axios from "axios";
import BaseModalConfirm from "../BaseModalForm.vue"

export default {
  props: {
    employee: Object
  },
  data() {
    return {
      visible: false,
    };
  },
  components: {
    BaseModalConfirm
  },
  // created() {
  //   console.log("run create");
  //   console.log(this.employee);
  // },
  
 
  methods: {
    hide: async function() {
     
      await this.$refs.BaseForm_ref.hide();

      
    },
    show: async function() {  
      await this.$refs.BaseForm_ref.show();    
    },

    Confirm : async function(){      
    //  console.log(this.employee);
      var edited;
      await axios.put('https://localhost:44339/api/employee', this.employee)
            .then(function (res) {
              console.log("success in edit: "+res);
              edited = true;
              
            })
            .catch(function (err) {
               console.log("false in edit: " +err);
              edited = false;                         
            });
            this.$emit("edited", edited);              
    }
  },
};
</script>

<style src="../modal.scss" lang="scss" />
<style scoped>
.currency-for-input {
  position: absolute;
  right: 12px;
  top: 22px;
  line-height: 40px;
  font-style: italic;
}

.label-text {
  margin-bottom: 2px;
}

.default-avt {
  width: 170px;
  height: 165px;
  border: 1px solid #ccc;
  /* background-image: url('../../content/img/default-avatar.jpg'); */
  background-size: contain;
  margin: 0 auto;
  cursor: pointer;
}

.hr-group-label {
  width: 70px;
  margin-left: 0;
  margin-top: 7px;
  margin: 7px 0 7px 0;
  border: 2px solid #019160;
  background-color: #019160;
}
