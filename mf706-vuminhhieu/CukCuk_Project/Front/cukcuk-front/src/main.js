import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false
import VueToastr from "vue-toastr";

Vue.use(VueToastr, {
  /* OverWrite Plugin Options if you need */
});

new Vue({
  render: h => h(App),
  
}).$mount('#app')
