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
