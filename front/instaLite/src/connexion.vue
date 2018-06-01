<template>
  <div class="bg">
  <div class="main">
		<div class="main2">
			<div class="container-img">
			<img src="./assets/icon.png">
			</div>

            <component v-bind:is="pageView" v-on:changePage="updateCompo($event)"></component>

        </div>
	</div>
</div>
</template>

<script>
import registration2 from './registration2.vue'
import registration3 from './registration3.vue'
import registration from './registration.vue'
import test from './test.vue'
import home from './home.vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
export default {
  components : {
    'registration3':registration3,
  'registration2':registration2,
  'registration':registration,
  'test':test,
  'home':home
},
  name: 'app',
  data () {
    return {
      UserId: '',
      Password:'',
      pageView:'registration'
    }
  },
  mounted:function() {
    this.$http.get('http://localhost:5000/Instalite/GetMyPhotos',{headers: {
     'Authorization': 'Bearer '+ localStorage.token
   }}).then(response => {
     this.$emit('changeCompo','home')
      //console.log(this.MyPhotos.Lien)
      })
  },
  methods:{
    updateCompo:function(nouvoCompo){
      this.pageView=nouvoCompo;
    },
    connexion:function(){
      this.$validator.validateAll().then((result) => {
            if (result) {
            //  console.log("click")
            var md5 = require('js-md5');
            var hachPass=md5(this.Password)

              this.$http.get('http://localhost:5000/Instalite/Connexion',{params:{


                UserId:this.UserId,
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


          });
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
      },

    getPassword:function(){
// document.location.reload(true); a changer de place
      this.$validator.validateAll().then((result) => {
            if (result) {
              this.$http.get('http://localhost:5000/Instalite/GetMyPassword',{params:{
                UserId:this.UserId,
              }}).then(response => {

                    alert('Votre mot de passe vous à été envoyé par mail')
                  },(response) => {
                  alert('Erreur serveur,veuillez réessayer')
            })
            return;
            }
            if(!result){
            alert('Entrer votre login puis cliquer sur mot de passe oublié')
}
          });

  },

  signUp:function(){
    this.$router.push({
        name: 'Registration'
    });
  },


      },


}
</script>

<style>
body {
    height: 100%;
}
.bg {
    /* The image used */
    background-image: url("./assets/bg3.jpg");

    /* Full height */
    height: 100%;
    overflow: scroll;
    /* Center and scale the image nicely */
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
}

.main{
	display: flex;
	justify-content: center;

}
.main2{
	border-style: solid;
	border-width: 1px;
	border-color: #A4A4A4;
	min-height: 450px;
	max-height: auto;
	min-width: 200px;
	max-width: 500px;
	position: relative;
	top: 60px;
  background-color:white;

}
.container-img{
	position: absolute;
	left: calc(50% - 90px);
	top : -80px;
}
</style>
