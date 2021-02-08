<template lang="">
    <div class="dialog__add">
        <div class="dialog__modal"></div>
        <div class="container">
            <div class="container__header">
                <div class="header__title">THÔNG TIN NHÂN VIÊN</div>
                <div class="icon--x" @click="setDisplay(false)">X</div>
            </div>
            <div class="container__content">
                <div class="content__left">
                    <div id="image"></div>
                    <div class="text">(Vui lòng chọn ảnh có định dạng .jpg, .jpeg, .png, .gif.)</div>
                </div>
                <div class="content__right">
                    <table border="0">
                        <tbody>
                            <tr>
                                <td colspan="2">A.THÔNG TIN CHUNG</td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Mã nhân viên (<span class="red">*</span>)</label>
                                    <div :class="{input: true, requiredError: !infoRequired.EmployeeCode.status}">
                                        <input type="text" name="EmployeeCode" maxlength="20"
                                            v-model="employee.EmployeeCode"
                                            @blur="validate('EmployeeCode')"
                                            :title="infoRequired.EmployeeCode.message"/>
                                    </div>
                                </td>
                                <td>
                                    <label>Họ và tên (<span class="red">*</span>)</label>
                                    <div :class="{input: true, requiredError: !infoRequired.FullName.status}">
                                        <input type="text" name="FullName" maxlength="100" 
                                            v-model="employee.FullName" 
                                            @blur="validate('FullName')"
                                            :title="infoRequired.FullName.message"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Ngày sinh</label>
                                    <div class="input">
                                        <input type="date" v-model="employee.DateOfBirth"/>
                                    </div>
                                </td>
                                <td>
                                    <label>Giới tính</label>
                                    <div class="drop--down">
                                        <select v-model="employee.Gender">
                                            <option value="0">Nam</option>
                                            <option value="1">Nữ</option>
                                            <option value="2">Khác</option>
                                        </select>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Số CMTND/ Căn cước (<span class="red">*</span>)</label>
                                    <div :class="{input: true, requiredError: !infoRequired.IdentityNumber.status}">
                                        <input type="text" v-model="employee.IdentityNumber" 
                                            @blur="validate('IdentityNumber')" maxlength="20"
                                            :title="infoRequired.IdentityNumber.message"/>
                                    </div>
                                </td>
                                <td>
                                    <label>Ngày cấp</label>
                                    <div class="input">
                                        <input type="date" v-model="employee.IdentityDate"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Nơi cấp</label>
                                    <div class="input">
                                        <input type="text" v-model="employee.IdentityPlace" maxlength="255"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Email (<span class="red">*</span>)</label>
                                    <div :class="{input: true, requiredError: !infoRequired.Email.status}">
                                        <input type="email" v-model="employee.Email" 
                                            @blur="validate('Email')" maxlength="50" 
                                            :title="infoRequired.Email.message"/>
                                    </div>
                                </td>
                                <td>
                                    <label>Số điện thoại (<span class="red">*</span>)</label>
                                    <div :class="{input: true, requiredError: !infoRequired.PhoneNumber.status}">
                                        <input type="text" v-model="employee.PhoneNumber" 
                                            @blur="validate('PhoneNumber')" maxlength="20" 
                                            :title="infoRequired.PhoneNumber.message"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">A.THÔNG TIN CÔNG VIỆC</td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Vị trí</label>
                                    <div class="drop--down position">
                                        <select v-model="employee.PositionId">
                                            <option v-for="(position, index) in positions" :key="index" :value="position.PositionId">{{ position.PositionName }}</option>
                                        </select>
                                    </div>
                                </td>
                                <td>
                                    <label>Phòng ban</label>
                                    <div class="drop--down department">
                                        <select v-model="employee.DepartmentId">
                                            <option v-for="(department, index) in departments" :key="index" :value="department.DepartmentId">{{ department.DepartmentName }}</option>
                                        </select>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Mã số thuế cá nhân</label>
                                    <div class="input">
                                        <input type="text" v-model="employee.PersonalTaxCode" maxlength="20"/>
                                    </div>
                                </td>
                                <td>
                                    <label>Mức lương cơ bản</label>
                                    <div class="input">
                                        <input type="text" v-model="employee.Salary" maxlength="11"/>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Ngày gia nhập công ty</label>
                                    <div class="input">
                                        <input type="date" v-model="employee.JoinDate"/>
                                    </div>
                                </td>
                                <td>
                                    <label>Tình trạng công việc</label>
                                    <div class="drop--down">
                                        <select v-model="employee.JobStatus">
                                            <option value="2">Đang thử việc</option>
                                            <option value="0">Đang làm việc</option>
                                            <option value="1">Đã nghỉ việc</option>
                                        </select>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="container__footer">
                <button class="button--icon button--save" @click="saveOnClick()">
                    <div class="icon icon--save"></div>
                    <div class="text">Lưu</div>
                </button>
                <button class="button--second button--cancel" @click="setDisplay(false)">Hủy</button>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    data() {
        return {
            employee: {
                EmployeeCode: '',
                FullName: '',
                IdentityNumber: '',
                PhoneNumber: '',
                Email: '',
                JobStatus: '2',
                Salary: 0,
                Gender: '2',
                DepartmentId: this.departments.length>0 ? this.departments[0].DepartmentId:'',
                PositionId: this.positions.length>0 ? this.positions[0].PositionId:''
            },
            infoRequired: {
                FullName: {
                    status: true,
                    message: null,
                },
                EmployeeCode: {
                    status: true,
                    message: null,
                },
                Email: {
                    status: true,
                    message: null,
                },
                PhoneNumber: {
                    status: true,
                    message: null,
                },
                IdentityNumber: {
                    status: true,
                    message: null,
                }
            }
        }
    },
    props: {
        setDisplay: Function,
        loadData: Function,
        departments: Array,
        positions: Array,
        dialogMode: String,
        employeeId: String
    },
    mounted() {
        if (this.dialogMode === 'EDIT') {
            axios.get('http://localhost:49779/api/Employees/' + this.employeeId)
                .then(res => {
                    if (res.data.Data != null && res.data.Code === 200) {
                        this.employee = res.data.Data;
                    }
                    this.employee.DateOfBirth = this.formatDate(this.employee.DateOfBirth);
                    this.employee.IdentityDate = this.formatDate(this.employee.IdentityDate);
                    this.employee.JoinDate = this.formatDate(this.employee.JoinDate);
                })
                .catch(res => {
                    console.log(res);
                })
        } else if (this.dialogMode === 'ADD') {
            axios.get('http://localhost:49779/api/Employees/GetEmployeeCodeMax')
                .then(res => {
                    console.log(res)
                    if (res.data.Data !== null && res.data.Code === 200) {
                        this.employee.EmployeeCode = 'NV' + (new Number(res.data.Data.EmployeeCode.slice(2, res.data.Data.EmployeeCode.length)) + 1);
                    }
                })
                .catch(res => {
                    console.log(res);
                })
        }
    },
    methods: {
        formatDate(date) {
            var d = new Date(date);
            var day = d.getDate();
            var month = d.getMonth() + 1;
            var year = d.getYear() + 1900;
            if (day < 10) {
                day = '0' + day;
            } if (month < 10) {
                month = '0' + month;
            }
            return year + '-' + month + '-' + day;
        },
        validate(type) {
            if (!this.employee[type] || this.employee[type] === null || this.employee[type].length === 0) {
                this.infoRequired[type].message = 'Bạn phải điền thông tin này';
                this.infoRequired[type].status = false;
            } else {
                var format;
                if (type === "Email") {
                    format = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    this.infoRequired[type].message = "Hãy nhập đúng định dạng Email!";
                } else if (type === "PhoneNumber" || type === "IdentityNumber") {
                    format = /(([0-9]{1,})$)/g;
                    this.infoRequired[type].message = "Chỉ được nhập số!";
                } else if (type === "FullName") {
                    format = /./g;
                    this.infoRequired[type].message = "Chỉ được nhập số!";
                } else if (type === "EmployeeCode") {
                    format = /^(NV)[0-9]{1,}$/g;
                    this.infoRequired[type].message = "Hãy nhập đúng định dạng NV______!"
                }
                this.infoRequired[type].status = format.test(this.employee[type]);
                if (this.infoRequired[type].status) {
                    this.infoRequired[type].message = null;
                }
            }
        },
        saveOnClick() {
            for (let key in this.infoRequired) {
                this.validate(key);
            }
            for (let key in this.infoRequired) {
                if (!this.infoRequired[key].status) {
                    return ;
                }
            }
            if (this.employee.PositionId === '' || this.employee.DepartmentId === '') {
                return ;
            }
            if (this.dialogMode === 'ADD') {
                axios.post('http://localhost:49779/api/Employees', this.employee)
                    .then(res => {
                        console.log(res.data);
                        if (res.data.Data != null && res.data.Code === 200) {
                            this.setDisplay(false);
                            this.loadData();
                        } else if (res.data.Code == 400) {
                            this.infoRequired.EmployeeCode.status = false;
                            this.infoRequired.EmployeeCode.message = "Mã nhân viên đã tồn tại!"
                        } else {
                            console.log(res.data);
                        }
                    })
                    .catch(res => {
                        console.log(res);
                    })
            } else if (this.dialogMode === 'EDIT') {
                axios.put('http://localhost:49779/api/Employees', this.employee)
                    .then(res => {
                        if (res.data.Data != null && res.data.Code === 200) {
                            this.loadData();
                            this.setDisplay(false);
                        } else if (res.data.Code == 400) {
                            this.infoRequired.EmployeeCode.status = false;
                            this.infoRequired.EmployeeCode.message = "Mã nhân viên đã tồn tại!"
                        } else {
                            console.log(res);
                        }
                    })
                    .catch((res) => {
                        console.log(res);
                    })
            }
        }
    }
}
</script>
<style scoped>
.dialog__add {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100vh;
}
.dialog__add .dialog__modal {
    position: absolute;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    background-color: #000000;
    opacity: 0.4;
}
.dialog__add .container{
    position: absolute;
    width: 800px;
    height: 750px;
    top: calc((100% - 750px)/2);
    left: calc((100% - 800px)/2);
    background-color: #ffffff;
    border-radius: 5px;
    overflow: hidden;
}

    .dialog__add .container .container__header {
        height: 50px;
        background-color: #E5E5E5;
    }

        .dialog__add .container .container__header .header__title {
            float: left;
            height: 100%;
            width: auto;
            font-size: 25px;
            line-height: 50px;
            margin-left: 15px;
        }

        .dialog__add .container .container__header .icon--x{
            float: right;
            height: 35px;
            width: 35px;
            background-color: #ffffff;
            display: flex;
            justify-content: center;
            align-items: center;
            cursor: pointer;
        }


    .dialog__add .container .container__content {
        width: calc(100% - 20px);
        height: calc(100% - 50px - 50px - 20px);
        display: flex;
        padding: 10px;
    }

        .dialog__add .container .container__content .content__left {
            flex: 2;
            padding: 10px;
        }

            .dialog__add .container .container__content .content__left #image {
                width: 160px;
                height: 160px;
                border: 1px solid #bbbbbb;
                border-radius: 50%;
                margin: auto;
                margin-bottom: 10px;
                background: url('../content/img/default-avatar.jpg') no-repeat center;
                background-size: contain;
                cursor: pointer;
            }

            .dialog__add .container .container__content .content__left .text {
                text-align: center;
            }

        .dialog__add .container .container__content .content__right {
            flex: 5;
        }

            .dialog__add .container .container__content .content__right table {
                border-collapse: collapse;
                width: 100%;
                height: 100%;
            }

                .dialog__add .container .container__content .content__right table td {
                    width: 50%;
                    padding: 0 5px 0 5px;
                }

                    .dialog__add .container .container__content .content__right table td label {
                        line-height: 1.5;
                    }


    .dialog__add .container .container__footer {
        width: 100%;
        height: 50px;
        background-color: #E5E5E5;
    }

        .dialog__add .container .container__footer button {
            float: right;
            margin-right: 15px;
            margin-top: 5px;
        }

            .dialog__add .container .container__footer button.button--cancel {
                background-color: #E5E5E5;
            }

                .dialog__add .container .container__footer button.button--cancel:hover {
                    background-color: #efefef;
                }  

.icon--save {
    background: url('../content/icon/add.png') no-repeat center;
    background-size: contain;
}

.icon-x {
    background: url('../content/icon/x.svg') no-repeat center;
    background-size: contain;
}

.red {
    color: #ff0000;
}

.requiredError, .requiredError:focus {
    border: 1px solid #ff0000 !important;
}

</style>