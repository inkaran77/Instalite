<template>
    <body class="body">
      <form @submit.prevent="">
      <div class="bander signflex ">
        <div class="icon"></div>
        <h3>Bienvenue sur InstaLite</h3>
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Identifiant</label>
            <md-input v-model="UserId"v-validate="'required|alpha'" required="" type="text"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Mot de passe </label>
            <md-input v-model="Password" required="" type="password"></md-input>
          </md-field>
        </div>
              <a href="#" v-on:click="getPassword()">Mot de passe oublié</a>
              <button  v-on:click="connexion()" class="btn btn-success btn-touch">Connexion</button>
              <button  v-on:click="signUp()" class="btn btn-primary btn-touch">Inscription</button>


      </div>
</form>
  </body>

</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
export default {

  name: 'app',
  data () {
    return {
      UserId: '',
      Password:''
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
    connexion:function(){
      this.$validator.validateAll().then((result) => {
            if (result) {
            //  console.log("click")

              this.$http.get('http://localhost:5000/Instalite/Connexion',{params:{


                UserId:this.UserId,
                Password:this.Password
              }}).then(response => {

                  alert('Connexion reussi')
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
    this.$emit('changeCompo','registration')
  },


      },


}
</script>

<style>
.body{
  display: flex;
  justify-content: center;
}

body {
  height: 100%;
  background: url('./assets/background17.jpg')rgb(255, 255, 255);
  background-repeat: repeat, repeat;
  background-size: cover, cover;
  background-position: left top, left top;
  background-attachment: scroll, scroll;
  font: 400 1em/1.38 Helvetica;


}
.bander{
  display: block;
  min-width: 500px;
  min-height: 550px;
  max-width: 600px;
  max-height: 600px;
  background-color: rgba(0,0,0,0.4);

  position: relative;
  top: 50px;
  border-radius: 25px;

}
.signflex{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.sizenput{
  margin-bottom: 20px;
}
.icon{
  height: 200px;
  width: 200px;
  background-image: url(assets/icon.png);
  background-repeat: no-repeat;


}
button{
  margin-bottom: 10px;
}
a:only-of-type{
  margin-bottom: 10px;
}

</style>
