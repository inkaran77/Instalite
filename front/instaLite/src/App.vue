<template>

  <component v-bind:is="pageView" v-on:changeCompo="updateCompo($event)"></component>

</template>

<script>
import connexion from './connexion.vue'
import registration from './registration.vue'
import test from './test.vue'
import home from './home.vue'
export default {
  components : {
  'connexion':connexion,
  'registration':registration,
  'test':test,
  'home':home
},

  name: 'app',
  data () {
    return {
      pageView:'connexion'
    }
  },
  methods: {
    updateCompo:function(nouvoCompo){
      this.pageView=nouvoCompo;
    }
},


  }

</script>

<style>

</style>
