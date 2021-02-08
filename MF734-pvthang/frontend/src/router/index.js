import Vue from 'vue'   
import Router from 'vue-router'
import Employee from '../components/Employee'
import Customer from '../components/Customer'
import Dashboard from '../components/Dashboard'
import Report from '../components/Report'
import Buy from '../components/Buy'
import Setting from '../components/Setting'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: "/",
            component: Employee
        },
        {
            path: "/employee",
            component: Employee
        },
        {
            path: "/customer",
            component: Customer
        },
        {
            path: "/dashboard",
            component: Dashboard
        },
        {
            path: "/report",
            component: Report
        },
        {
            path: "/buy",
            component: Buy
        },
        {
            path: "/setting",
            component: Setting
        }
    ]
})