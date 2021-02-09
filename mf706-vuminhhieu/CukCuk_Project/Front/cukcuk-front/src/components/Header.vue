<template>
     <nav class="main-header h-container-row">
            <select name="restaurantName" class="select-head">
                <option value="0">
                    --Chọn nhà hàng--
                </option>
                <option value="1">
                    --Nhà hàng Cao Cầu
                </option>
                <option value="2">
                    Nhà hàng Ngọc Bích
                </option>
                <option value="3">
                    Nhà hàng MySantad
                </option>
            </select>

            <ul class="nav user-head ml-auto">

                <li class="nav-item">
                    <img src="~@/content/icon/avatar-default.png" class="img-circle" height="40" />
                </li>
                <li class="text-one-line ">
                    Vũ Minh Hiếu
                </li>
                <li class="h-icon h-icon-option option-head">
                </li>

            </ul>

        </nav>
</template>

<script>
export default {
  name: 'Header',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.main-header {
    position:relative;
    margin-left: 201px;
    height:60px;
    width: calc(100% - 201px);
    background-color:#ffff;  
    box-sizing: border-box;
    padding:10px 5px 10px;
}


.user-head {
    height: 40px;    
    display: flex;   
    flex-direction: row;
    padding-left: 0;
    margin-bottom: 0;
    margin-top: 0px;
    list-style: none;
}
.option-head {
    margin: 10px 0;
    width: 40px;
}

.user-head li {
    line-height: 40px;    
    cursor:pointer;
}
.select-head {
    outline: none;
    border: none;
}


.text-one-line {
    white-space: nowrap;
    padding-left: .5rem;
}

</style>
