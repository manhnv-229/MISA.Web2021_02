<template>
    <div class="menu">
        <div class="logo">
            <div class="icon-bar"></div>
            <div class="logo-page"></div>
        </div>
        <div class="menu__content">
            <router-link v-for="(tab, index) in tabs" :key="index" :to="'/' + tab.id">
                <div :class="{focus: tab.id === currentTab, menu__item: true}">
                    <div :class="'menu__icon ' + 'icon--' + tab.id"></div>
                    <div class="menu__text">{{ tab.text }}</div>
                </div>
            </router-link>
        </div>
    </div>
</template>
<script>
export default {
    data() {
        return {
            
        }
    },
    computed: {
        tabs() {
            return this.$store.state.tabs;
        },
        currentTab: {
            get() {
                return this.$store.state.currentTab;
            },
            set(tab_id) {
                this.$store.commit("setCurrentTab", tab_id);
            }
        }
    }
}
</script>
<style scoped>
.menu {
    background-color: #ffffff;
    width: 199px;
    height: 100vh;
    border-right: 1px solid #BBBBBB;
    overflow: hidden;
}

.menu .logo {
    display: flex;
    position: relative;
    width: 100%;
    height: 60px;
    align-items: center;
}

    .menu .logo .icon-bar {
        margin-left: 13px;
        margin-right: 10px;
        height: 24px;
        width: 24px;
        background: url('../content/img/toggle.png') no-repeat center;
        background-size: cover;
    }

    .menu .logo .logo-page {
        width: 140px;
        height: 50px;
        background: url('../content/img/cukcuk-logo.png') no-repeat center;
        background-size: contain; 
    }

.menu .menu__content {
    position: relative;
    width: 100%;
    height: calc(100vh - 60px);
}

    .menu .menu__content .menu__item {
        display: flex;
        width: calc(100% - 15px);
        height: 40px;
        align-items: center;
        padding-left: 15px;
        cursor: pointer;
    }

        .menu .menu__content .menu__item:hover {
            background-color: #e5e5e5;
        }

        .menu .menu__content .menu__item.focus {
            background-color: #019160;
            color: #ffffff;
        }

    .menu .menu__content .menu__icon {
        width: 26px;
        height: 26px;
    }

    .menu .menu__content .menu__text {
        padding-left: 10px;
    }

.icon--report {
    background: url('../content/icon/report.png') no-repeat center;
    background-size: contain;
}

.icon--dashboard, .icon--buy {
    background: url('../content/icon/dashboard.png') no-repeat center;
    background-size: contain;
}

.icon--employee, .icon--customer {
    background: url('../content/icon/dic-employee.png') no-repeat center;
    background-size: contain;
}

.icon--setting {
    background: url('../content/icon/setting.png') no-repeat center;
    background-size: contain;
}

a {
  text-decoration: none;
  color: #000000;
}

a:visited {
  color: #000000;
}
</style>