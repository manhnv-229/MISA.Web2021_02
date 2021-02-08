<template>
  <div class="header-page">
                <div class="dropdown1">
                    <select>
                        <option v-for="(item, index) in Department"
                        v-bind:key="index"
                        >{{ item.name }}</option>
                        
                    </select>
                </div>
                <div class="account">
                    <div class="avatar1">
                    </div>
                    <div class="name">Vũ Hữu Thắng</div>
                    <div class="option1">
                        <img src="/public/content/icon/option.png" /> 
                    </div>
                </div>
 </div>
</template>

<script>
export default {
    name:'EmployeeHeader',
    props:{
        Department:{
            type:Array,
            default:[],
        }
    }
}
</script>

<style>
.panel-right .header-page {
    height:60px;
    display:flex;
    border-bottom:1px solid black;
}

.dropdown1 {
    height: 60px;
    text-align: center;
}

select {
    border: none;
    font-size: 13px;
    margin: 20px 0px 10px 30px;
    font-family: GoogleSans-Regular;
}

.account {
    position:absolute;
    display: flex;
    height: 60px;
    right:20px;
    padding-top:12px;
}

    .account .avatar1 {
        width: 30px;
        height: 30px;
        
        background-image: url('/public/content/icon/avatar-default.png');
        background-size: contain;
        margin-right:10px;
    }

.account .name {
    margin-top:5px;
    margin-right:10px;
}
.account .option1 {
        margin-top: 5px;
} 

</style>