<template >
    <div class="employee">
        <div class="content__title">
            <div class="title__text heading">Danh sách nhân viên</div>
            <div class="title__button">
                <button class="button--icon add--employee" @click="btnAddOnClick()">
                    <div class="icon icon--add--employee"></div>
                    <div class="text">Thêm nhân viên</div>
                </button>
            </div><div class="title__button">
                <button class="button--second delete--employee" @click="setDialogDelete(true)" :disabled="employeeId===null">Xóa</button>
            </div>
        </div>
        <div class="option">
            <div class="option__filter">
                <div class="input--icon">
                    <div class="icon icon--search" 
                        @click="loadData()">
                    </div>
                    <input type="text" v-model="filterText" maxlength="100" placeholder="Tìm kiếm theo mã, tên, số điện thoại"
                        @keyup.enter="loadData()">
                </div>
            </div>
            <div class="option__filter">
                <div class="drop--down filter__department">
                    <select v-model="departmentId" @change="currentPage = 1; loadData()">
                        <option value=" ">Tất cả phòng ban</option>
                        <option v-for="(department, index) in departments" :value="department.DepartmentId" :key="index">{{ department.DepartmentName }}</option>
                    </select>
                </div>
            </div>
            <div class="option__filter">
                <div class="drop--down filter__position">
                    <select v-model="positionId" @change="currentPage = 1; loadData()">
                        <option value=" ">Tất cả vị trí</option>
                        <option v-for="(position, index) in positions" :value="position.PositionId" :key="index">{{ position.PositionName }}</option>
                    </select>
                </div>
            </div>
            <div class="option__button">
                <button class="btn icon--refresh" @click="loadData()"></button>
            </div>
        </div>
        <div class="table">
            <table border="0">
                <thead>
                    <tr>
                        <th v-for="(info, index) in infoDisplay" :key="index">{{info.title}}</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(employee, index) in employees" :key="employee.EmployeeId" 
                        @click="employeeId = employeeId===employee.EmployeeId? null:employee.EmployeeId"
                        @dblclick="trOnDblclick(employee.EmployeeId)" 
                        :class="{rowSelected: employee.EmployeeId===employeeId, rowOdd: index%2===0}">
                        <td v-for="(info, indexTr) in infoDisplay" :key="indexTr">{{ employee[info.key] }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="footer">
            <div class="footer__center__container">
                <div class="footer__center">
                    <button class="btn--first first--page icon--first" @click="changePage(1)" :disabled="currentPage===1"></button>
                    <button class="btn--first prev--page icon--previous" @click="changePage(currentPage - 1)" :disabled="currentPage===1"></button>
                    <but id="list--page">
                        <button class="btn--second number--page" v-if="currentPage-2>0" @click="changePage(currentPage-2)">{{ currentPage - 2 }}</button>
                        <button class="btn--second number--page" v-if="currentPage-1>0" @click="changePage(currentPage-1)">{{ currentPage - 1 }}</button>
                        <button class="btn--second number--page current--page">{{ currentPage }}</button>
                        <button class="btn--second number--page" v-if="currentPage+1<=totalPages" @click="changePage(currentPage+1)">{{ currentPage + 1 }}</button>
                        <button class="btn--second number--page" v-if="currentPage+2<=totalPages" @click="changePage(currentPage+2)">{{ currentPage + 2 }}</button>
                    </but>
                    <button class="btn--first next--page icon--next" @click="changePage(currentPage + 1)" :disabled="currentPage>=totalPages"></button>
                    <button class="btn--first last--page icon--last" @click="changePage(totalPages)" :disabled="currentPage>=totalPages"></button>
                </div>
            </div>
            <div class="footer__left">Hiển thị {{(currentPage - 1) * employeesPerPage + 1}}
                -{{ (currentPage - 1) * employeesPerPage + employees.length }}
                /{{totalEmployees}} nhân viên
            </div>
            <div class="footer__right">
                <div class="drop--down">
                    <select v-model="employeesPerPage"
                        @change="currentPage = 1; loadData()">
                        <option value="10">10 nhân viên/trang</option>
                        <option value="15">15 nhân viên/trang</option>
                        <option value="20">20 nhân viên/trang</option>
                    </select>
                </div>
            </div>
        </div>
        
        <DialogAdd v-if="dialogAdd" :setDisplay="setDialogAdd" :loadData="loadData" :departments="departments" :positions="positions" :dialogMode="dialogMode" :employeeId="employeeId"/>
        <DialogDelete v-if="dialogDelete" :setDisplay="setDialogDelete" :loadData="loadData" :id="employeeId"
            :name="'employee'" 
            :message="'Bạn có muốn xóa nhân viên này không?'"/>
    </div>
</template>
<script>
import axios from 'axios'
import DialogAdd from './DialogAddEmployee'
import DialogDelete from './DialogDelete'

export default {
    name: "Employee",
    data() {
        return {
            infoDisplay: [
                {
                    key: "EmployeeCode",
                    title: "Mã nhân viên"
                },
                {
                    key: "FullName",
                    title: "Họ và tên"
                },
                {
                    key: "GenderName",
                    title: "Giới tính"
                },
                {
                    key: "DateOfBirth",
                    title: "Ngày sinh"
                },
                {
                    key: "PhoneNumber",
                    title: "Điện thoại"
                },
                {
                    key: "Email",
                    title: "Email"
                },
                {
                    key: "PositionName",
                    title: "Chức vụ"
                },
                {
                    key: "DepartmentName",
                    title: "Phòng ban"
                },
                {
                    key: "Salary",
                    title: "Mức lương cơ bản"
                },
                {
                    key: "JobStatusName",
                    title: "Tình trạng công việc"
                },
            ],
            employees: [],
            departments: [],
            positions: [],
            totalPages: 0,
            currentPage: 1,
            totalEmployees: 0,
            employeesPerPage: 15,
            dialogAdd: false,
            dialogDelete: false,
            dialogMode: null,
            employeeId: null,
            positionId: ' ',
            departmentId: ' ',
            filterText: ''
        }
    },
    components: {
        DialogAdd,
        DialogDelete
    },
    mounted() {
        this.$store.commit("setCurrentTab", "employee");
        axios.get('http://localhost:49779/api/Departments')
            .then(res => {
                if (res.data.Data != null && res.data.Code === 200) {
                    this.departments = res.data.Data;
                }
            })
            .catch(res => {
                console.log(res);
            })
        axios.get('http://localhost:49779/api/Positions')
            .then(res => {
                if (res.data.Data != null  && res.data.Code === 200) {
                    this.positions = res.data.Data;
                }
            })
            .catch(res => {
                console.log(res);
            })
        this.loadData();
    },
    methods: {
        loadData() {
            axios.get('http://localhost:49779/api/Employees/count/'+ this.departmentId + '&' + this.positionId + '&' + (this.filterText===''? '%20':this.filterText))
                .then(res => {
                    if (res.data.Data != null && res.data.Code === 200) {
                        this.totalEmployees = res.data.Data;
                    }
                    this.totalPages = Math.ceil(this.totalEmployees/this.employeesPerPage);
                })
                .catch(res => {
                    console.log(res);
                })
            axios.get('http://localhost:49779/api/employees/' + this.currentPage + '&' + this.employeesPerPage + '&' + this.departmentId + '&' + this.positionId + '&' + (this.filterText===''?'%20':this.filterText))
                .then(res => {
                    if (res.data.Data != null && res.data.Code === 200) {
                        this.employees = res.data.Data;
                    }
                    this.employees = this.employees.map(employee => {
                        employee.DateOfBirth = this.formatDate(employee.DateOfBirth);
                        employee.Salary = this.formatMoney(employee.Salary);
                        return employee;
                    })
                })
                .catch(error => {
                    console.log(error)
                }) 
        },
        changePage(number) {
            if (number > this.totalPages) number = this.totalPages;
            if (number < 1) number = 1;
            this.employeeId = null;
            this.currentPage = number;
            this.loadData();
        },
        setDialogAdd(bool) {
            this.dialogAdd = bool;
            if (bool === false) {
                this.dialogMode = null;
                this.employeeId = null;
            }
        },
        setDialogDelete(bool) {
            this.dialogDelete = bool;
            if (bool === false) {
                this.employeeId = null;
            }
        },
        btnAddOnClick() {
            this.dialogMode = 'ADD';
            this.dialogAdd = true;
        },
        trOnDblclick(employeeId) {
            this.employeeId = employeeId;
            this.dialogMode = 'EDIT';
            this.dialogAdd = true;
        },
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
            return day + '/' + month + '/' + year;
        },
        formatMoney(money) {
            var ret = "";
            var count = 0;
            while (money > 0) {
                ++count;
                ret = (money % 10) + "" + ret;
                money = Math.floor(money / 10);
                if (count === 3 && money>0) {
                    ret = '.' + ret;
                    count = 0;
                }
            }
            if (ret.length == 0) ret = "0";
            return ret;
        }
    },
}
</script>
<style scoped>
.employee {
    widows: 100%;
    height: 100%;
}
     .content__title {
        width: 100%;
        height: 50px;
        align-items: center;
        overflow: hidden;
    }

         .content__title .title__text {
            float: left;
            height: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
        }

         .content__title .title__button {
            float: right;
            display: flex;
            right: 0;
            background-color: #ffffff;
            height: 100%;
            overflow: hidden;
            justify-content: center;
            align-items: center;
            margin-left: 10px;
        }

     .option {
        width: 100%;
        height: 50px;
        background-color: #ffffff;
        overflow: hidden;
    }

         .option .option__filter {
            float: left;
            display: flex;
            background-color: #ffffff;
            justify-content: center;
            align-items: center;
            height: 100%;
            margin-right: 10px;
        }

         .option .option__button {
            float: right;
            display: flex;
            background-color: #ffffff;
            justify-content: center;
            align-items: center;
            height: 50px;
            margin-left: 10px;
        }

             .option .option__button .btn {
                width: 35px;
                height: 35px;
                border: 1px solid #bbbbbb;
                cursor: pointer;
                border-radius: 4px;
                padding: 5px;
            }

     .table {
        width: 100%;
        height: calc(100% - 50px - 50px - 50px);
        overflow-x: auto;
        overflow-y: hidden;
    }

         .table::-webkit-scrollbar {
            width: 6px;
            height: 8px;
            background-color: #E9EBEE;
        }

         .table::-webkit-scrollbar-thumb {
            width: 6px;
            height: 8px;
            background-color: #bbbbbb;
        }

         .table table {
            width: 1700px;
            height: 100%;
            min-width: 100%;
            border-collapse: collapse;
        }

             .table table thead{
                width: 100%;
                height: 45px;
            }

             .table table tbody {
                display: block;
                height: calc(100% - 10px);
                overflow: auto;
            }

                 .table table tbody::-webkit-scrollbar {
                    width: 6px;
                    height: 8px;
                    background-color: #E9EBEE;
                }

                 .table table tbody::-webkit-scrollbar-thumb {
                    width: 6px;
                    height: 8px;
                    background-color: #bbbbbb;
                }

             .table table tr {
                width: 100%;
                height: 45px;
                max-height: 45px;
                border-bottom: 1px solid #bbbbbb;
                cursor: pointer;
                text-align: left;
                display: table;
                table-layout: fixed;
            }

                 .table table tbody tr:hover {
                    background-color: #E5E5E5;
                }

                 .table table tr th {
                    padding: 5px 10px 5px 10px;
                }

                 .table table tr td {
                    padding: 5px 10px 5px 10px;
                    overflow: hidden;
                    text-overflow: ellipsis;
                }

     .footer {
        width: 100%;
        height: 50px;
        overflow: hidden;
        text-align: center;
    }

         .footer .footer__left{
            float: left;
            display: flex;
            height: 100%;
            align-items: center;
            margin-left: 10px;
        }

         .footer .footer__center__container {
            display: inline-block;
            height: 100%;
        }

         .footer .footer__center {
            display: flex;
            height: 100%;
            align-items: center;
        }

             .footer .footer__center .prev--page {
                margin-left: 5px;
                margin-right: 5px;
            }

             .footer .footer__center #list--page {
                display: flex;
                align-items: center;
                justify-content: center;
            }

                 .footer .footer__center #list--page .number--page {
                    margin-left: 5px;
                    margin-right: 5px;
                }

             .footer .footer__center .next--page {
                margin-left: 5px;
                margin-right: 5px;
            }

         .footer .footer__right {
            float: right;
            display: flex;
            height: 100%;
            align-items: center;
            margin-right: 10px;
        }

             .footer .footer__right .drop--down{
                height: 30px;
            }

.icon--add--employee {
    background: url('../content/icon/add.png') no-repeat center;
    background-size: contain;
}

.icon--refresh {
    background: url('../content/icon/refresh.png') no-repeat center;
}

.icon--previous {
    background-image: url('../content/icon/btn-prev-page.svg');
    background-size: contain;
}

.icon--next {
    background-image: url('../content/icon/btn-next-page.svg');
    background-size: contain;
}

.icon--first {
    background-image: url('../content/icon/btn-firstpage.svg');
}

.icon--last {
    background-image: url('../content/icon/btn-lastpage.svg');
}

.icon--search {
    background: url('../content/icon/search.png') no-repeat center;
}

.current--page {
    background-color: #019160;
    color: #ffffff;
}

.rowOdd {
    background-color: #f8f8f8;
}

.rowSelected {
    background-color: #bbbbbb;
}
</style>