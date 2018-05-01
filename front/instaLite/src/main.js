import Vue from 'vue'
import App from './App.vue'
import VueRessource from'vue-resource'
import VeeValidate from 'vee-validate';
import BootstrapVue from 'bootstrap-vue'

Vue.use(BootstrapVue);
Vue.use(VeeValidate);
Vue.use(VueRessource);
new Vue({
  el: '#app',
  render: h => h(App)
})
