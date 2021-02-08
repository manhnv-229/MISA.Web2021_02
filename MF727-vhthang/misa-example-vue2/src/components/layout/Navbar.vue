<template>
    <div class="navbar">
        <div class="logo-site">
            <div class="logo-box">
                <div class="toggle-icon"></div>
                <div class="amis-logo"></div>
            </div>
        </div>
        <div class="navbar-content">
            <a class="nav-item">
                <div class="nav-item-icon nav-item-dashboard"></div>
                <div class="nav-item-text">Tổng quan</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-report"></div>
                <div class="nav-item-text">Báo cáo</div>
            </a>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-dashboard"></div>
                <div class="nav-item-text">Mua hàng</div>
            </a>
            <!-- <a class="nav-item" :href="customer">
                <div class="nav-item-icon nav-item-dic"></div>
                <div class="nav-item-text">Danh mục khách hàng</div>
            </a> -->
            <router-link class="nav-item" to="/dictionary/customer">
                <div class="nav-item-icon nav-item-dic"></div>
                <div class="nav-item-text">Danh mục khách hàng</div>
            </router-link>
             <router-link class="nav-item" to="/dictionary/employee">
                <div class="nav-item-icon nav-item-dic"></div>
                <div class="nav-item-text">Danh mục nhân viên</div>
            </router-link>
            <a class="nav-item">
                <div class="nav-item-icon nav-item-setting"></div>
                <div class="nav-item-text">Thiết lập hệ thống</div>
            </a>

        </div>
    </div>
</template>
<script>
export default {
  name: 'MenuBarLinks',
  data () {
    return {
      customer: '/dictionary/customer',
      employee: '/dictionary/employee'
    };
  }
};
</script>
