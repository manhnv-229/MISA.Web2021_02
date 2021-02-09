<template>
    <div class="wrapper">
    
    <Sidebar msg="Welcome to Your Vue.js App"/>
    <Header msg="Welcome to Your Vue.js App"/>
    <Content msg="Welcome to Your Vue.js App"/>
    
  </div>
</template>

<script>
import Content from './components/Content.vue'
import Header from './components/Header.vue'

import Sidebar from './components/Sidebar.vue'


export default {
  name: 'App',
  components: {
    Sidebar,
    Header,
    Content,   
  }
}
</script>

<style src="./styles/app.scss" lang="scss" />
