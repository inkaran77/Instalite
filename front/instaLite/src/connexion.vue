<template>

  <div class="bg">
    <notifications></notifications>
  <div class="main">
		<div class="main2">
			<div v-on:click="load()" class="container-img">
			<img src="./assets/icon.png">
			</div>

            <component  :Login="Login2":Email="Email":Pass="Password2":Ln="Last_name":Fn="First_name" :Bd="Birth_date" :Ge="Gender" :Co="Country" :Ci="City" v-bind:is="pageView" v-on:call2="callTwo($event)" v-on:call1="callOne($event)" v-on:changePage="updateCompo($event)"></component>

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

            Login2:'',
            First_name:'',
            Last_name:'',
            Birth_date:'',
            Gender:'',
            Email:'',
            Password2:'',
            City:'',
            Country:'',


      pageView:'registration'
    }
  },
  mounted:function() {

  },
  methods:{
    load:function(){
      document.location.reload(true);
    },
    callOne:function(l){

      this.Login2=l.Login2
      this.Email=l.Email
      this.Password2=l.Password2
      console.log(l.Email)

    },
    callTwo:function(l){
      this.Last_name=l.Last_name
      this.First_name=l.First_name
      this.Birth_date=l.Birth_date
      this.Gender=l.Gender
      this.Country=l.Country
      this.City=l.City

    },
    updateCompo:function(nouvoCompo){
      this.pageView=nouvoCompo;
    },
    connexion:function(){
      this.$validator.validateAll().then((result) => {
            if (result) {

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



      },


}
</script>

<style>
body,html {
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
