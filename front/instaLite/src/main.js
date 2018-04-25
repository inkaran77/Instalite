import Vue from 'vue'
import App from './App.vue'
import VueRessource from'vue-resource'
import BootstrapVue from 'bootstrap-vue'

Vue.use(BootstrapVue);

Vue.use(VueRessource);
new Vue({
  el: '#app',
  render: h => h(App)
})
