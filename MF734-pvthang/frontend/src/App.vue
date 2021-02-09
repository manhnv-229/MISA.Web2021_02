<template>
  <div id="app">
    <Menu />
    <Header />
    <Content />
  </div>
</template>

<script>
import Menu from './components/Menu'
import Header from './components/Header'
import Content from './components/Content'

export default {
  name: 'App',
  components: {
    Menu,
    Header,
    Content
  }
}
</script>

<style >
@import './css/main.css';
#app {
  position: fixed;
  margin: 0;
  width: 100%;
  height: 100vh;
  top: 0;
  left: 0;
}
</style>
