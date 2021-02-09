import Vue from 'vue'
import App from './App.vue'
import Store from './store/index.js'
import Router from './router/index.js'

Vue.config.productionTip = false

new Vue({
  store: Store,
  router: Router,
  render: h => h(App),
}).$mount('#app')
