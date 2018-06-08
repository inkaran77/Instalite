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
              <modal :width="700"
              :height="600" name="descriptionFeed" >

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

                <b-form-textarea
                v-model="comments"
                placeholder="Votre commentaire ici"

                style="height:190px; width:80%;"
                >
              </b-form-textarea>
              <div class="row">
                    <button class="btn-success btn" style="margin-right:15px;margin-top:5px;margin-bottom:5px;"v-on:click="comments()">Commenter</button>
                      <button class="btn-primary btn"style="margin-top:5px;margin-bottom:5px;" v-on:click="like()">Like</button>
              </div>
            </div>


              </modal>
              <div class="row">

              <div class="col-sm-4" v-for="feed in MyFeed">
              <div class="container-img">
              <img :src='feed.Lien' v-on:click="getUrl(feed.Lien)">
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
      MyFeed:null,
      urlPhoto:'',
      titre:'titre de la photo',
      commentsList:null,
      description:'une description',
      author:'autheur',
      comments:'',
      like_counter:null
    }
  },
  mounted:function() {
    this.getAll()
    this.getNews()
  

  },
  methods:{
    like:function(){
      this.$http.put('http://localhost:5000/Instalite/Like',{
        UrlPhoto:this.urlPhoto
      },{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {

       this.$notify(
         {
           message: 'Like pris en compte',
           icon: 'add_alert',
           horizontalAlign: 'right',
           verticalAlign: 'bottom',
           type: 'success'
         })
         this.getPost()
        },(response) => {

    })
  },
    comments:function(){
      if(this.comments!=''){
      this.$http.put('http://localhost:5000/Instalite/Comment',{
        UrlPhoto:this.urlPhoto,
        Message:this.comments
      },{headers: {
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
         this.$router.push({
             name: 'Fil d actualité'
         });
        },(response) => {

    })
}
else(this.$notify(
  {
    message: 'Rédiger un commentaire',
    icon: 'add_alert',
    horizontalAlign: 'right',
    verticalAlign: 'bottom',
    type: 'danger'
  }))
  },
    getUrl:function(url){
      this.urlPhoto=url
      this.getAllComments(url)
      this.getPost()
     this.$modal.show('descriptionFeed');

    },
    getNews:function(){
      this.$http.get('http://localhost:5000/Instalite/GetMyNewsFeed',{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {
       console.log(response.data.NewsFeed)
    this.MyFeed=response.data.NewsFeed
        },(response) => {

    })


  },
  getAllComments:function(url){

    this.$http.get('http://localhost:5000/Instalite/GetAllComments',{
      UrlPhoto:url,
    },{headers: {
     'Authorization': 'Bearer '+ this.$cookies.get("token")
   }}).then(response => {
     this.commentsList=response.data.Comments
     console.log(response.data)

   },(response) => {

})

  },

  getPost:function(){
    this.$http.get('http://localhost:5000/Instalite/GetPost',{
      UrlPhoto:this.urlPhoto
    },{headers: {
     'Authorization': 'Bearer '+ this.$cookies.get("token")
   }}).then(response => {
     this.description=response.data.Description
     this.titre=response.data.Title
     this.like_counter=response.data.Like_counter
     console.log(response.data)

      })
  },
    getAll:function () {
      this.$http.get('http://localhost:5000/Instalite/GetMyProfile',{headers: {
       'Authorization': 'Bearer '+ this.$cookies.get("token")
     }}).then(response => {


          var user=response.data
          localStorage.setItem('user2',JSON.stringify(user))
          console.log(localStorage.getItem('user2'));


        },(response) => {
      alert('une erreur est survenu')
    })
    }

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
