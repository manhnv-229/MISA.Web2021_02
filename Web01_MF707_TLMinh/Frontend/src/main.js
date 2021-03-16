import Vue from 'vue'
import App from './App.vue'
import VueMaterial from 'vue-material'
import { MdButton, MdContent, MdTabs , MdDialog, MdDialogAlert, MdDialogConfirm} from 'vue-material/dist/components'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import Vuelidate from 'vuelidate'

Vue.config.productionTip = false

Vue.use(Vuelidate)
Vue.use(VueMaterial)
Vue.use(MdDialogAlert)
Vue.use(MdButton)
Vue.use(MdContent)
Vue.use(MdTabs)
Vue.use(MdDialog)
Vue.use(MdDialogConfirm)


new Vue({
  render: h => h(App),
}).$mount('#app')

