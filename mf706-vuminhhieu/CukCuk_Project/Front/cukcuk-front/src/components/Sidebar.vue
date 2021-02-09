<template>
    <aside class="main-sidebar">
            <ul class="logo">
                <li>
                    <a class="expend-icon" href="#">
                    </a>
                </li>
                <li>
                    <a class="logo-page" href="#">
                    </a>
                </li>
            </ul>
            <div class="sidebar">
                <nav class="mt-2">
                    <ul class="h-container-column">
                        <li class="h-item">
                            <a href="#" class="h-item-link">
                                <i class="h-icon h-icon-dashboard"></i>
                                <p class="h-item-text">
                                    Tổng quan
                                </p>
                            </a>
                        </li>
                        <li class="h-item">
                            <a href="#" class="h-item-link">
                                <i class="h-icon h-icon-report"></i>
                                <p class="h-item-text">
                                    Báo cáo
                                </p>
                            </a>
                        </li>
                        <li class="h-item">
                            <a href="#" class="h-item-link">
                                <i class="h-icon h-icon-dashboard"></i>
                                <p class="h-item-text">
                                    Mua hàng
                                </p>
                            </a>
                        </li>
                        <li class="h-item">
                            <a href="#" class="h-item-link">
                                <i class="h-icon h-icon-dic-employee"></i>
                                <p class="h-item-text">
                                    Danh mục nhân viên
                                </p>
                            </a>
                        </li>
                        <li class="h-item">
                            <a href="#" class="h-item-link">
                                <i class="h-icon h-icon-setting"></i>
                                <p class="h-item-text">
                                    Thiết lập hệ thống
                                </p>
                            </a>
                        </li>
                    </ul>
                </nav>
            </div>
        </aside>
</template>

<script>
export default {
  name: 'Sidebar',
  props: {
    msg: String
  }
}
</script >

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>


.Wapper, body, html {
    min-height: 100%;
}

.wapper {
    position: relative;
}

.main-sidebar {
    position: fixed;
    top: 0;
    left: 0;
    width: 200px;
    height: 100vh;
    background-color: #ffff;
    border-right: 1px solid #e5e5e5;
    box-sizing: border-box;
}

    /*.main-sidebar:hover {
        transition: 0.25s;
        width: 50px;
    }*/
    .main-sidebar .logo {
        width: 100%;
        height: 60px;
        padding: 10px 10px 10px;
       
        box-sizing: border-box;
        margin: 0 auto;        
    }

        .main-sidebar .logo .expend-icon {
            position:relative;
            float:left;
            width: 30px;
            height: 30px;
            margin: 5px auto;
            background-image: url('../content/img/toggle.png');
            background-size: cover;
            background-position: center center;
            background-repeat: no-repeat;
        }

        .main-sidebar .logo .logo-page {
            position: relative;
            float: left;
            width: 100px;
            height: 40px;
            margin-left: 1rem;
           background-image: url('../content/img/cukcuk-logo.png');
            background-size: contain;
            background-position: center center;
            background-repeat: no-repeat;
        }

.h-container-column{
padding: 0;
}

</style>
