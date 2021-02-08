<template lang="">
    <div class="dashboard">
        dashboard
    </div>
</template>

<script>
export default {
    name: 'Employee',
    mounted() {
        this.$store.commit("setCurrentTab", "dashboard");
    }
}
</script>

<style scoped>
.dashboard {
    width: 100%;
    height: 100%;
}
</style>