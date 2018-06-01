<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Fil d'actualité</h4>
            <p class="category">Vos photos et celles de vos amis</p>
          </md-card-header>
          <md-card-content>
            <div id="newsfeed">
              <div class="row">

  <div class="col-sm-4" v-for="Myphoto in Myphotos2">
<img :src='Myphoto.Lien' class="zoom" style=" height:250px; margin-top:20px;" v-on:click="getUrl(Myphoto.Lien)">

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
      UserId: '',
      Password:''
    }
  },
  mounted:function() {
    this.getAll()
  },
  methods:{
    getUrl:function(url){
      this.urlPhoto=url
      this.getAllComments()
      this.getPost()
    //  this.$modal.show('description');

    },
    getAll:function () {
      this.$http.get('http://localhost:5000/Instalite/GetMyProfile',{headers: {
       'Authorization': 'Bearer '+ localStorage.token
     }}).then(response => {


          var user=response.data
          localStorage.setItem('user2',JSON.stringify(user))
          console.log(localStorage.getItem('user2'));
          localStorage.user = response.data

        },(response) => {
      alert('une erreur est survenu')
    })
    }

  },

}
</script>
