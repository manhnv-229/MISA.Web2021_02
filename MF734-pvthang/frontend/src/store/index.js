import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        account: {
            name: "Phạm Việt Thắng"
        },
        tabs: [
            {
                id: 'dashboard',
                text: "Tổng quan"
            },
            {
                id: 'report',
                text: "Báo cáo"
            },
            {
                id: 'buy',
                text: "Mua hàng"
            },
            {
                id: 'customer',
                text: "Danh mục khách hàng"
            },
            {
                id: 'employee',
                text: "Danh mục nhân viên"
            },
            {
                id: 'setting',
                text: "Thiết lập hệ thống"
            }
        ],
        currentTab: "dashboard"
    },
    mutations: {
        setCurrentTab(state, tab_id) {
            state.currentTab = tab_id;
        }
    }
})