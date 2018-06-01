<!-- la dernier page d'inscription -->
<template>
    <transition name="slide-fade">
    <div>
    <div class="registre3">
      <h4 style="margin-left: 150px; margin-right: 150px;">Votre photo de profile</h4>
    <div class="barre"></div><div class="barre" ></div><div class="barre"></div>
    <picture-input
      ref="pictureInput"
      @change="onChanged"
      width="200"
      height="300"
      margin="16"
      accept="image/jpeg,image/png"
      size="10"
      buttonClass="btn"
      hideChangeButton="true"
      style="margin-top:20px;"
      :customStrings="{
        upload: '<h1>Bummer!</h1>',
        drag: 'Drag and Drop ou cliquer ici pour selectionner un fichier'
      }">
    </picture-input>
    <div class="registre3" style="margin-top: 0;">
    <button v-on:click="back()" class="btn-danger btn btn-reg">Retour</button>
    <button v-on:click="signup()" class="btn-success btn btn-reg">Valider</button>
      </div>
  </div>

</div>
</transition>
  </template>
  <script>
  import 'bootstrap/dist/css/bootstrap.css'
  import 'bootstrap-vue/dist/bootstrap-vue.css'
  import PictureInput from 'vue-picture-input'
  import test from '@/test.vue'
  export default{
    components : {
PictureInput,
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

         urlPhoto:'http://res.cloudinary.com/dvejva95o/image/upload/v1527154205/instaLite/wyn8yxonngrrbc4kxhv5.jpg',
         Myphotos2:null,
         titre:'titre de la photo',
         commentsList:null,
         description:'une description',
         author:'autheur'
  }
    },


    methods:{

      back:function(){
        this.$emit('changePage','registration2')
      },

      getUrl:function(url){
        this.urlPhoto=url
        this.getAllComments()
        this.getPost()
        this.$modal.show('description');

      },

      getAllComments:function(){
        this.$http.get('http://localhost:5000/Instalite/GetAllComments',{
          UrlPhoto:this.urlPhoto
        },{headers: {
         'Authorization': 'Bearer '+ localStorage.token
       }}).then(response => {
         this.commentsList=response.data.Comments
         console.log(response.data)


          //console.log(this.MyPhotos.Lien)
          })

      },

      getPost:function(){
        this.$http.get('http://localhost:5000/Instalite/GetPost',{
          UrlPhoto:this.urlPhoto
        },{headers: {
         'Authorization': 'Bearer '+ localStorage.token
       }}).then(response => {
         //this.commentsList=response.data.Comments
         console.log(response.data)


          //console.log(this.MyPhotos.Lien)
          })
      }

        },

        mounted:function() {
          this.$http.get('http://localhost:5000/Instalite/GetMyPhotos',{headers: {
           'Authorization': 'Bearer '+ localStorage.token
         }}).then(response => {

           console.log(response.data.MyPhotos)
        this.Myphotos2=response.data.MyPhotos
this.getAllComments()
            //console.log(this.MyPhotos.Lien)
            })
        },

  }
  </script>
<style>
.slide-fade-enter-active {
  transition: all .8s ease;
}

.slide-fade-enter, .slide-fade-leave-to
/* .slide-fade-leave-active below version 2.1.8 */ {
  transform: translateX(10px);
  opacity: 0;
}

.registre3{
	margin-top: 100px;
	display: flex;
	justify-content: center;
	flex-wrap: wrap;
	flex-direction: row;
}

.btn-reg{
  margin-bottom: 20px;
   margin-top: 20px;
   margin-left: 10px;
   margin-right: 10px;
}
.barre{
  display: block;
  width: 20%;
  height: 1px;
  background-color: #2E9AFE;
  margin-left: 5px;
}
</style>
