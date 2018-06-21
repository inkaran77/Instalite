<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Mes Photos  <button variant="success" class="btn btn-success"v-on:click="post()"><i class="material-icons">
add_a_photo
</i></button></h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>
            <div id="myphoto">
              <modal :width="700"
         :height="600" name="description" >

                <div class="containers">
                <h2>{{titre}}</h2>

                  <div class="container-photo">
    <img style="height:100%; width:auto;":src='urlPhoto'alt="" /></a>
  </div>


  <p>Description : {{description}}</p>
  <p>Like <i class="material-icons md-18">
thumb_up</i> : {{like_counter}}</p>


                <div class="container-comments">
                  <p><b>Commentaire:</b></p>
                  <div class="comments" v-for="Com in commentsList">
                    <p><b>{{Com.Author}} : </b>{{Com.Message}}</p>
                  </div>


                </div>
                <b-form-textarea
                v-model="comment"
                placeholder="Votre commentaire ici"
                :rows="2"
                style="min-height:50px;width:80%;margin-top:15px;"
                :min-rows="2">

              </b-form-textarea>
              <div>
                    <button style="margin-top:5px;margin-right:5px;margin-bottom:5px;"class="btn-danger btn" v-on:click="delet()">Effacer</button>
                    <button v-bind:disabled="comment === ''"style="margin-top:5px;margin-left:5px;margin-bottom:5px;"class="btn-primary btn" v-on:click="comments()">Commenter</button>
                  </div>
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
       like_counter:null,
       comment:""
}
  },


  methods:{
    comments:function(){
      if(this.comment!=''){
      this.$http.put('http://localhost:5000/Instalite/Comment',"",{params:{
        UrlPhoto:this.urlPhoto,
        Message:this.comment
      },headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {
       this.$notify(
         {
           message: 'Commentaire est en ligne',
           icon: 'add_alert',
           horizontalAlign: 'right',
           verticalAlign: 'bottom',
           type: 'success'
         })
         this.$modal.hide('description');
         this.$router.push({
             name: 'Mes Photos'
         });
        },(response) => {

    })
}

  },
    getUrl:function(url){
      this.urlPhoto=url
      this.getAllComments(url)
      this.getPost()
      this.comment=""
      this.$modal.show('description')

    },

    getAllComments:function(url){

      this.$http.get('http://localhost:5000/Instalite/GetAllComments',{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     },params:{
        UrlPhoto:url
      }}).then(response => {
       this.commentsList=response.data.Comments



        //console.log(this.MyPhotos.Lien)
        },(response) => {

    })

    },

    getPost:function(){
      this.$http.get('http://localhost:5000/Instalite/GetPost',{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     },params:{
        UrlPhoto:this.urlPhoto,
      }}).then(response => {
       //à coder format?
       this.description=response.data.Description
       this.titre=response.data.Title
       this.like_counter=response.data.Like_counter


        })
    },
    post:function(){
      this.$router.push({
          name: 'Poster'
      });
    },
    delet:function(){
      this.$http.delete('http://localhost:5000/Instalite/DeletePost',{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     },params:{
        UrlPhoto:this.urlPhoto
      }}).then(response => {
        this.$notify(
          {
            message: 'Le post est supprimé',
            icon: 'add_alert',
            horizontalAlign: 'right',
            verticalAlign: 'bottom',
            type: 'success'
          })
          this.$modal.hide('description')
          this.getMyphoto()

        //console.log(this.MyPhotos.Lien)
        })

    },

    getMyphoto:function(){
      this.$http.get('http://localhost:5000/Instalite/GetMyPhotos',{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {
    this.Myphotos2=response.data.MyPhotos

        //console.log(this.MyPhotos.Lien)
        })
    }

      },

      mounted:function() {
          this.getMyphoto()
      },

}
</script>
<style>
.material-icons.md-18 { font-size: 15px;
color: rgba(0, 0, 0, 0.54);  }
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
.btnGg {
  display:block;
  height: 20px;
  width: 20px;
  border-radius: 50%;
  border: 1px solid red;

}
</style>
