<template>

    <transition name="slide-fade">
      <div>
        <form @submit.prevent="">
  			<div class="connect">

  				<h4 style="margin-left: 200px; margin-right: 200px;">Connexion</h4>
          <input  required v-model="Login"type="text" placeholder="Login">
  				<input  required v-model="Password" type="password" placeholder="Mot de Passe">
  			</div>

  			<center><button v-on:click="connexion()" class="btn-success btn" style="margin-bottom: 20px; margin-top: 20px;">Connexion</button></center>
</form>
<form @submit.prevent="">
  			<div class="registre2">
  				--------------------- OU ---------------------
  				<h4 style="margin-left: 200px; margin-right: 200px;">Inscription</h4>
          <div class="barre"></div><div class="barre" style="background-color:#A4A4A4;"></div><div class="barre" style="background-color:#A4A4A4;"></div>

  				<input required v-validate="'required|alpha'"  v-model="Login2" style="width: 375px;" type="text" placeholder="Login">
  				<input required v-validate="'required|alpha'"  v-model="Email"style="width: 375px;"type="text" placeholder="Mail">
  				<div class="st-pss">
  				<input required name="ps1" v-validate="'required'"  v-model="Password2" type="password"  placeholder="Mot de Passe">
          <input required name="ps2" v-validate="'required|confirmed:ps1'"  type="password"  placeholder="Confirme Mot de Passe">	</div>
          <span v-show="errors.has('ps2')" style="color:red;font-size:10px;" class="help ">Mot de passe de confirmation différent</span>

        </div>
    	<center><button v-on:click="next()" class="btn-primary btn" style="margin-bottom: 20px; margin-top: 20px;">Suivant</button></center>
      </form>
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
         author:'autheur',
         Login2:'',
         Email:'',
         Password2:'',
         Login:'',
         Password:''
  }
    },


    methods:{
      connexion:function(){

              if (this.Login !='' && this.Password!='') {
              //  console.log("click")
              var md5 = require('js-md5');
              var hachPass=md5(this.Password)

                this.$http.get('http://localhost:5000/Instalite/Connexion',{params:{


                  UserId:this.Login,
                  Password:hachPass
                }}).then(response => {
                  this.$notify(
                    {
                      message: 'Connexion réussie',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'success'
                    })

                    var token=response.data.token
                    localStorage.setItem('token2',JSON.stringify(token))
                    console.log(localStorage.getItem('token2'));
                    localStorage.token = response.data.token
                    this.getAll()
                    this.error = false
                    this.$emit('changeCompo','home')

                  },(response) => {
                  if(response.status==400){
                    alert('Mot de pass erroné')
                  }
                  else if(response.status==404){
                  alert('L utilisateur existe pas')
                }
                else{alert('Vérifier votre login/mot de passe')}
              })


                return;
              }



          },
      next:function(){
        this.$validator.validateAll().then((result) => {
              if (result) {
                this.$emit('call1',this.Login2,this.Email,this.Password2)
        this.$emit('changePage','registration2')
      }});

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
