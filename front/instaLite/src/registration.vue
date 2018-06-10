<template>

    <transition name="slide-fade">
      <div>
        <form @submit.prevent="">
  			<div class="connect">

  				<h4 style="margin-left: 200px; margin-right: 200px;">Connexion</h4>
          <input  required v-model="Login"type="text" placeholder="Login">
  				<input  required v-model="Password" type="password" placeholder="Mot de passe">
  			</div>

  			<center><button v-on:click="connexion()" class="btn-success btn" style="margin-bottom: 20px; margin-top: 20px;">Connexion</button></center>
</form>
<form @submit.prevent="">
  			<div class="registre2">
  				--------------------- OU ---------------------
  				<h4 style="margin-left: 200px; margin-right: 200px;">Inscription</h4>
          <div class="barre"></div><div class="barre" style="background-color:#A4A4A4;"></div><div class="barre" style="background-color:#A4A4A4;"></div>

  				<input required v-validate="'required'"  v-model="User1.Login2" style="width: 375px;" type="text" placeholder="Login">
  				<input required v-validate="'required|email'"  v-model="User1.Email"style="width: 375px;"type="email" placeholder="email">
  				<div class="st-pss">
  				<input required name="ps1" v-validate="'required'"  v-model="User1.Password2" type="password"  placeholder="Mot de passe">
          <input required name="ps2" v-validate="'required|confirmed:ps1'"  type="password"  placeholder="Confirmation Mot de passe">	</div>
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
        User1:{
          Login2:'',
          Email:'',
          Password2:''

        },
        Login:'',
        Password:''


  }
    },


    methods:{
      autoRedi:function(){
        if(this.$cookies.isKey("token")){
          this.$router.push({
              name: 'Fil d actualité'
          });
        }
      },

      connexion:function(){

              if (this.Login !='' && this.Password!='') {
              //  console.log("click")
              var md5 = require('js-md5');
              var hachPass=md5(this.Password)

                this.$http.get('http://localhost:5000/Instalite/Connexion',{params:{


                  UserId:this.Login,
                  Password:hachPass
                }}).then(response => {


                    this.$cookies.set("token",response.data.token,60*60*3)
                  
                    this.$router.push({
                        name: 'Fil d actualité'
                    });

                  },(response) => {
                  if(response.status==400){
                    this.$notify(
                      {
                        message: 'Mot de passe erroné',
                        icon: 'add_alert',
                        horizontalAlign: 'right',
                        verticalAlign: 'bottom',
                        type: 'danger'
                      })
                  }
                  else if(response.status==404){
                    this.$notify(
                      {
                        message: 'Login incorrect',
                        icon: 'add_alert',
                        horizontalAlign: 'right',
                        verticalAlign: 'bottom',
                        type: 'danger'
                      })
                }
                else{  this.$notify(
                    {
                      message: 'Vérifier votre Login/Mot de passe',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'danger'
                    })}
              })


                return;
              }



          },

      next:function(){
        this.$validator.validateAll().then((result) => {
              if (result) {
                this.$emit('call1',this.User1)
        this.$emit('changePage','registration2')
      }});

  },


        },

        mounted:function() {
  this.autoRedi()
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

  .containers-imgs{
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
