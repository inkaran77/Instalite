<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Mes Abonnés</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>
            <div id="followers">
            </div>
           </md-card-content>
         </md-card>
       </div>
     </div>
   </div>
 </template>
<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
export default{
  props: {
    dataBackgroundColor: {
      type: String,
      default: ''
    }
  },
  name: 'app',
  data () {
    return {
      UserId: '',
      Password:''
    }
  },

  methods:{


      },
}
</script>
