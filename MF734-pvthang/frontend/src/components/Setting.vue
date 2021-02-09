<template lang="">
    <div class="setting">
        setting
    </div>
</template>
<script>
export default {
    mounted() {
        this.$store.commit("setCurrentTab", "setting");
    }
}
</script>
<style scoped>
.setting {
    width: 100%;
    height: 100%;
}
</style>