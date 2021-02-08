<template lang="">
    <div class="header">
        <div class="header__title">
            <div class="title__text title2">Nhà hàng biển đông</div>
            <div class="title__icon"></div>
        </div>
        <div class="account">
            <div class="account__image"></div>
            <div class="account__name">{{ account.name }}</div>
            <div class="account__icon"></div>
        </div>
    </div>
</template>
<script>
export default {
    name: 'Header',
    computed: {
        account() {
            return this.$store.state.account;
        }
    }
}
</script>
<style scoped>
.header {
    position: fixed;
    width: calc(100% - 200px);
    height: 59px;
    background-color: #ffffff;
    left: 200px;
    top: 0px;
    align-items: center;
    overflow: hidden;
    border-bottom: 1px solid #BBBBBB;
}


    .header .header__title {
        float: left;
        display: flex;
        height: 100%;
        align-items: center;
        justify-content: center;
        background-color: #ffffff;
        overflow: hidden;
    }

        .header .header__title .title__text {
            margin-left: 16px;
        }

        .header .header__title .title__icon {
            width: 16px;
            height: 16px;
            background: url('../content/icon/arrow-down.svg') no-repeat center;
            background-size: contain;
            cursor: pointer;
            margin-left: 10px;
        }

.header .account {
    float: right;
    display: flex;
    right: 0;
    height: 100%;
    align-items: center;
    justify-content: center;
    background-color: #ffffff;
    overflow: hidden;
}

    .header .account .account__image {
        width: 35px;
        min-width: 35px;
        height: 35px;
        background: url('../content/icon/avatar-default.png') no-repeat center;
        background-size: contain;
        margin-right: 16px;
    }

    .header .account .account__name {
        margin-right: 16px;
    }

    .header .account .account__icon {
        width: 20px;
        height: 20px;
        background: url('../content/icon/option.png') no-repeat center;
        background-size: contain;
        margin-right: 16px;
        cursor: pointer;
    }
</style>