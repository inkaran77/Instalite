<template>
  
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
                  if(reponse.status==200){
                    alert('Connexion reussi')
                    var token=response.data
                    this.$emit('changeCompo','home')
                    console.log(data);
                  }
                  if(response.status==401){
                    alert('Mot de pass erroné')
                  }
                  alert('Vérifier votre login/mot de passe')
              })
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
<<<<<<< HEAD
    connexion:function(){
      this.$validator.validateAll().then((result) => {
            if (result) {
              console.log("click")

              this.$http.get('http://localhost:5000/Instalite/Connexion',{params:{


                UserId:this.UserId,
                Password:this.Password
              }}).then(function(response){
                if(reponse.status==200){
                  alert('Connexion reussi')
                  var token=response.data
                  this.$emit('changeCompo','home')
                  console.log(data);
                }
                if(response.status==401){
                  alert('Mot de pass erroné')
                }
                alert('Vérifier votre login/mot de passe')
            })
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
=======
    getMe:function(){
       this.$http.get('https://jsonplaceholder.typicode.com/posts').then(function(data){
         console.log(data);
       })
     },

     signUp:function(){

   this.$validator.validateAll().then((result) => {
         if (result) {
           this.$http.post('http://localhost:5000/Instalite/Inscription',{
             UserId:this.Id,
             Password:this.Password,
             First_name:this.First_name,
             Last_name:this.Last_name,
              Gender:this.Gender,
               Email:this.Email,
             Birth_date:this.Birth_date,
             //My_photo:this.My_photo,
             City:this.City,
             Country:this.Country
           }).then(function(data){
             if(data.status==200){
               alert('Inscription reussi')
               this.$emit('changeCompo','connexion')
               console.log(data);
             }
             if(data.status==401){
               alert('Login déja utilisé, veuillez choisir un autre Login')
             }
             alert('échec inscription, veuillez réessayer')
         })
           return;
         }


       });
     }


  },

}
</script>

<style>

body {
  height: 100%;
  background: url('./assets/background.jpg')rgb(255, 255, 255);
  background-repeat: repeat, repeat;
  background-size: cover, cover;
  background-position: left top, left top;
  background-attachment: scroll, scroll;
  font: 400 1em/1.38 Helvetica;


}
.is-danger{
  border:1px solid red;
}
.body{
  display: flex;
  justify-content: center;

}
div:first-child{
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  align-items: center;
  flex-grow:

>>>>>>> 0a91bd1eaddb3c407d99224e6adfaa9e798fd3a9
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
</style>
