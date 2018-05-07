<template>
    <body class="body">
      <form @submit.prevent="connexion">
      <div class="bander signflex ">
        <div class="icon"></div>
        <h3>Bienvenue sur InstaLite</h3>

                <input  placeholder="Login" v-validate="'required|alpha'" class="{'input': true, 'is-danger': errors.has('Nom'),input-md sizenput } " required="" type="text" v-model="UserId">
              <input  placeholder="Mot de passe"  class=" input-md sizenput" required="" type="password" v-model="Password">
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

  methods:{
    connexion:function(){
      this.$validator.validateAll().then((result) => {
            if (result) {
              console.log("click")

              this.$http.get('http://localhost:5000/Instalite/Connexion',{params:{


                UserId:this.UserId,
                Password:this.Password
              }}).then(function(response){
                if(response.status==200){
                  alert("Vous êtes connecté")
                  var token=response.data
                  this.$emit('changeCompo','home')
                  console.log(data);


                }

            })
            
            alert('Vérifier votre login/mot de passe')
              return;
            }


          });
        },

    getPassword:function(){
      this.$validator.validateAll().then((result) => {
            if (result) {
              this.$http.get('http://localhost:5001/api/values',{
                UserId:this.UserId,
              }).then(function(data){
                  if(data.status==200){
                    alert('Votre mot de passe vous à été envoyé par mail')
                  }
                  alert('Erreur,veuillez réessayer')
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
  }


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
  background: url('./assets/background.jpg')rgb(255, 255, 255);
  background-repeat: repeat, repeat;
  background-size: cover, cover;
  background-position: left top, left top;
  background-attachment: scroll, scroll;
  font: 400 1em/1.38 Helvetica;


}
.bander{
  display: block;
  min-width: 500px;
  min-height: 640px;
  max-width: 600px;
  max-height: 640px;
  background-color: white;
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
