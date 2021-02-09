<template lang="">
    <div class="buy">
        buy
    </div>
</template>

<script>
export default {
    name: 'Buy',
    mounted() {
        this.$store.commit("setCurrentTab", "buy");
    }
}
</script>

<style scoped>
.buy {
    width: 100%;
    height: 100%;
}
</style>