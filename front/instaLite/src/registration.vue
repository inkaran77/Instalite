<template>

    <transition name="slide-fade">
      <div>
  			<div class="connect">

  				<h4 style="margin-left: 200px; margin-right: 200px;">Connexion</h4>
          <input type="password" name="Kevin" placeholder="Mot de Passe">
  				<input type="password" name="Kevin" placeholder="Mot de Passe">
  			</div>
  			<center><button class="btn-success btn" style="margin-bottom: 20px; margin-top: 20px;">Connexion</button></center>

  			<div class="registre2">
  				--------------------- OU ---------------------
  				<h4 style="margin-left: 200px; margin-right: 200px;">Inscription</h4>
          <div class="barre"></div><div class="barre" style="background-color:#A4A4A4;"></div><div class="barre" style="background-color:#A4A4A4;"></div>
  				<input style="width: 375px;" type="text" name="Login" placeholder="Login">
  				<input  style="width: 375px;"type="text" name="Mail" placeholder="Mail">
  				<div class="st-pss">
  				<input type="password" name="pass" placeholder="Mot de Passe">
  				<input type="password" name="Kevin" placeholder="Confirme Mot de Passe">	</div>
  			</div>
    	<center><button v-on:click="next()" class="btn-primary btn" style="margin-bottom: 20px; margin-top: 20px;">Suivant</button></center>
</div>
    </transition>
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

         urlPhoto:'http://res.cloudinary.com/dvejva95o/image/upload/v1527154205/instaLite/wyn8yxonngrrbc4kxhv5.jpg',
         Myphotos2:null,
         titre:'titre de la photo',
         commentsList:null,
         description:'une description',
         author:'autheur'
  }
    },


    methods:{

      next:function(){
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

  .container-img{
  	position: absolute;
  	left: calc(50% - 90px);
  	top : -80px;
  }
  	.registre2{
  		display: flex;
  		justify-content: center;

  		flex-wrap: wrap;
  	}
  	input{
  		margin-left: 10px;
  		margin-top: 10px;
  		margin-right: 10px;
  	}
  	.connect{
  		margin-top: 100px;
  		display: flex;
  		justify-content: center;
  		flex-wrap: wrap;
  	}
  	.st-pss{
  		display: flex;
  		justify-content: flex-start;
  		flex-wrap: wrap;
  	}
    .barre{
      display: block;
      width: 20%;
      height: 1px;
      background-color: #2E9AFE;
      margin-left: 5px;
    }
  </style>
