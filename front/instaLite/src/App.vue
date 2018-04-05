<template>
  <component v-bind:is="pageView"></component>

</template>

<script>
import connexion from './connexion.vue'
export default {
  components : {
  'connexion':connexion
},

  name: 'app',
  data () {
    return {
      pageView:'connexion'
    }
  },
  methods: {

  }


  }

</script>

<style>

</style>
