<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Mes Photos</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>
            <div id="myphoto">
              <div class="row">

  <div class="col-sm-4" v-for="Myphoto in Myphotos2">
<img :src='Myphoto.Lien'>

  </div>

</div>
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

       Myphotos2:null
}
  },


  methods:{


      },

      mounted:function() {
        this.$http.get('http://localhost:5000/Instalite/GetMyPhotos',{headers: {
         'Authorization': 'Bearer '+ localStorage.token
       }}).then(response => {

         console.log(response.data.MyPhotos)
      this.Myphotos2=response.data.MyPhotos

          //console.log(this.MyPhotos.Lien)
          })
      },

}
</script>
