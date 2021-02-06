<template>
    <div id="app">
        <app-nav-bar></app-nav-bar>
        <app-header></app-header>
        <app-content></app-content>
    </div>
</template>

<script>
import NavBar from '@/components/layouts/NavBar.vue'
import Content from '@/components/layouts/Content.vue'
import Header from '@/components/layouts/Header.vue'

export default {
    name: 'App',
    components: {
        appHeader: Header,
        appNavBar: NavBar,
        appContent: Content,
    },
}
</script>

<style lang="scss">
@import '@/styles/index.scss';
</style>
