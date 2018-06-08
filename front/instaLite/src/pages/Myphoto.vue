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
              <modal :width="700"
         :height="600" name="description" >

                <div class="containers">
                <h1>{{titre}}</h1>

                  <div class="container-photo">
    <img style="height:100%; width:auto;":src='urlPhoto'alt="" /></a>
  </div>


  <p>Description : {{description}}</p>
  <p>Like : {{like_counter}}</p>


                <div class="container-comments">
                  <p><b>Commentaire:</b></p>
                  <div class="comments" v-for="Com in commentsList">
                    <p><b>{{Com.Author}} : </b>{{Com.Message}}</p>
                  </div>


                </div>
                    <button style="margin-top:5px;margin-bottom:5px;"class="btn-danger btn" v-on:click="delet()">Effacer</button>

              </div>


              </modal>
              <div class="row">

  <div class="col-sm-4" v-for="Myphoto in Myphotos2">
    <div class="container-img">
<img :src='Myphoto.Lien' v-on:click="getUrl(Myphoto.Lien)">
</div>

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
import test from '@/test.vue'
export default{
  components : {

  'test':test

},
  props: {
    dataBackgroundColor: {
      type: String,
      default: ''
    }
  },
  name: 'app',
  data () {
    return {

       urlPhoto:'',
       Myphotos2:null,
       titre:'titre de la photo',
       commentsList:null,
       description:'une description',
       author:'autheur',
       like_counter:null
}
  },


  methods:{
    getUrl:function(url){
      this.urlPhoto=url
      this.getAllComments(url)
      this.getPost()
      this.$modal.show('description')

    },

    getAllComments:function(url){

      this.$http.get('http://localhost:5000/Instalite/GetAllComments',{
        UrlPhoto:url,
      },{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {
       this.commentsList=response.data.Comments
       console.log(response.data)


        //console.log(this.MyPhotos.Lien)
        },(response) => {

    })

    },

    getPost:function(){
      this.$http.get('http://localhost:5000/Instalite/GetPost',{
        UrlPhoto:this.urlPhoto
      },{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {
       //à coder format?
       this.description=response.data.Description
       this.titre=response.data.Title
       this.like_counter=response.data.Like_counter
       console.log(response.data)

        })
    },

    delet:function(){
      this.$http.delete('http://localhost:5000/Instalite/DeletePost',{
        UrlPhoto:this.urlPhoto
      },{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
      }}).then(response => {
        this.$notify(
          {
            message: 'Le post est supprimé',
            icon: 'add_alert',
            horizontalAlign: 'right',
            verticalAlign: 'bottom',
            type: 'success'
          })
       this.$router.push({
           name: 'Myphoto'
       });

        //console.log(this.MyPhotos.Lien)
        })

    },

      },

      mounted:function() {
        this.$http.get('http://localhost:5000/Instalite/GetMyPhotos',{headers: {
         'Authorization': 'Bearer '+ this.$cookies.get("token")
       }}).then(response => {

         console.log(response.data.MyPhotos)
      this.Myphotos2=response.data.MyPhotos

          //console.log(this.MyPhotos.Lien)
          })
      },

}
</script>
<style>

.containers{
  width: 700px;
  height: 600px;
  display: flex;
  align-items: center;
  flex-direction: column;
  overflow: scroll;


}

.gallerie {
    width: 550px;
height: 400px;
overflow: hidden;
}
.gallerie img{

position: relative;
left: -10px;
top: -10px;
}
.container-comments{
  width: 550px;
  min-height: 200px;
  overflow: scroll;

}
.comments{

  height: auto;
  margin-bottom: 10px;
  margin-top: 10px;
  margin-left: 10px;
  margin-right: 10px;
  background-color: #CEE3F6;
  overflow: hidden;


}
.zoom:hover {
    opacity: 0.9;

}
.container-img{
  max-width: 350px;
  height: 200px;
  background-color: black;
  display: flex;
  justify-content: center;
  align-items: center;
  overflow: hidden;
}
.container-photo{
  width: 700px;
  height: 400px;
  display: flex;
  justify-content: center;

}
</style>
