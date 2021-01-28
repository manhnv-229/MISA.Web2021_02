<template>
    <div class="menu-left">
        <div class="panel-left">
            <div class="logo">
                <div class="expend-icon" v-on:click="handleMenu"></div>
                <div class="logo-page"></div>

            </div>
            <div class="menu">
                <div class="menu_item" 
                    v-for="(item , index) in MenuBarCus"
                    v-bind:key="index"
                    >
                    <div class="menu_item-icon">
                        <img v-bind:src="`/public/content/icon/${item.src}`" width="24" height="24" />
                    </div>
                    <div class="menu_item-text">
                        {{ item.title }}
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name:'menu-left',
    props:{
        MenuBarCus:{
            type:Array,
            default:[],
        },
    },
    methods:{
        handleMenu(e){
            this.$emit('handleMenu');
        }
    }
}
</script>

<style>
.menu{
    width:100%;
    
}
.menu .menu_item {
        display: flex;
        height: 45px;
        align-items: center;
        padding-left:20px;       
        cursor:pointer;
}
.menu .menu_item:hover {
    background-color: #e5e5e5;
}
.menu .menu_item:focus {
    background-color: #019160;
    color:#ffffff;
}
.menu .menu_item .menu_item-icon {
        width: 24px;
        height: 24px;
    }
.menu .menu_item .menu_item-text {
    margin-left:10px;
    
    }
</style>