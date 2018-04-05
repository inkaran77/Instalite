import Vue from 'vue'
import App from './App.vue'
import VueRessource from'vue-resource'

Vue.use(VueRessource);
new Vue({
  el: '#app',
  render: h => h(App)
})
