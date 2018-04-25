<template>
  <component v-bind:is="pageView" v-on:changeCompo="updateCompo($event)"></component>

</template>

<script>
import connexion from './connexion.vue'
import registration from './registration.vue'
export default {
  components : {
  'connexion':connexion,
  'registration':registration

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
