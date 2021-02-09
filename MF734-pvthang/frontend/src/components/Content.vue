<template>
    <div class="content">
        <router-view></router-view>
    </div>
</template>
<script>
export default {
    
}
</script>
<style scoped>
.content {
    position: absolute;
    top: 60px;
    left: 200px;
    width: calc(100% - 200px - 20px);
    height: calc(100vh - 60px - 20px);
    background-color: #ffffff;
    margin: 10px;
    overflow: hidden;
}
</style>