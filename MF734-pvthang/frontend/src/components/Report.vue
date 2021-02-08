<template lang="">
    <div class="report">
        report
    </div>
</template>
<script>
export default {
    mounted() {
        this.$store.commit("setCurrentTab", "report");
    }
}
</script>
<style scoped>
.report {
    width: 100%;
    height: 100%;
}
</style>