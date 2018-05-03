<template>
<body class="body">
  <form @submit.prevent="signUp">
  <div class="bander">

    <div class="element element-3"></div>
    <center><h1>Inscription</h1></center>
    <div >
<fieldset>
      <div class="container-photo">
        <input type="file" name="fichier">
        <div class="photo">
        </div>
        <input  placeholder="Login" name="login" v-validate="'required|alpha'" class="{'input': true, 'is-danger': errors.has('login'),input-md sizinput2 } " required="" type="text" v-model="UserId">

      </div>

      <div class="container-inpute">

        <input  placeholder="Nom" name="Nom" v-validate="'required|alpha'" class="{'input': true, 'is-danger': errors.has('Nom'),input-md sizinput } " required="" type="text" v-model="First_name">
      <input  placeholder="Prénom" v-validate="'required|alpha'" class=" input-md sizinput" required="" type="text" v-model="Last_name">
      <input  placeholder="Date de naissance" v-validate="'required'" class=" input-group date sizinput" required="" type="date" v-model="Birth_date">
          <div class="togle">
            Femme <input style="color:black"type="radio" class="togle2"name="sexe"required="Sexe"value="Female">
            Homme <input type="radio" class="togle2"name="sexe"required="Sexe"value="Male">
          </div>

      <input name="ps1"placeholder="Mot de passe"  v-validate="'required'" class="input-md sizinput" required="" type="password" v-model="Password">
      <input  name="ps2"placeholder="Confirmation mot de passe" v-validate="'required|confirmed:ps1'"class=" input-md sizinput" required="" type="password">
      <span v-show="errors.has('ps2')" style="color:red;font-size:10px;" class="help ">Mot de passe de confirmation différent</span>
      <input  placeholder="Email" v-validate="'required|email'" class="{'input': true, 'is-danger': errors.has('email'),input-md sizinput2 } " required="" type="email" v-model="Email">
      <input  placeholder="Ville" v-validate="'required|alpha'" class="input-md sizinput" required="" type="text" v-model="City">
      <input  placeholder="Pays" v-validate="'required|alpha'"class=" input-md sizinput" required="" type="text" v-model="Country">
      <button  v-on:click="signUp()" class="btn btn-primary btn-touch">Inscription</button>



      </div>
    </fieldset>

  </div>

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
      UserId:'',
      First_name: '',
      Last_name:'',
      Birth_date: '',
      Gender:'',
      Email: '',
      Id:'',
      Password:'',
      My_photo:'',
      City: '',
      Country:''
    }
  },

  methods:{

     signUp:function(){

   this.$validator.validateAll().then((result) => {
         if (result) {
           console.log("click")


           this.$http.post('http://localhost:5000/Instalite/Inscription',{

             UserId:this.Id,
             Password:this.Password,
             First_Name:this.First_name,
             Last_Name:this.Last_name,
              Gender:this.Gender,
               Email:this.Email,
             Birth_date:this.Birth_date,
             //My_photo:this.My_photo,
             City:this.City,
             Country:this.Country
           }).then(function(response){
             if(response.status==200){
               alert('Inscription reussi')
               this.$emit('changeCompo','connexion')
               console.log(response.data);
             }
             if(response.status==401){
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
.container-photo{
  width: 100%;
  height: 200px;
  display: flex;
  justify-content: center;
  position: relative;
  top : -90px;
}
.photo{
  display: block;
  position: relative;
  min-width: 100px;
  max-width: 200px;
  min-height: 150px;
  max-height: 250px;
  background-color: black;
  top: -20px;
  left: 20px;


}
.sizinput{
  margin-left: 20px;
  margin-right: 20px;
  margin-bottom: 20px;
  display: flex;
  width: 200px;
  height: 40px;
  padding : 0 20px 0 20px;



}
.sizinput2{
  margin-left: 20px;
  margin-right: 20px;
  margin-bottom: 20px;
  display: flex;
  width: 440px;
  height: 40px;
  padding : 0 20px 0 20px;



}
.container-inpute{
  width: 100%;
  height: auto;
  display: flex;
  justify-content: center;
  flex-wrap: wrap;
  align-items: flex-start;
  position: relative;
  top: -90px;


}
.btn-touch{
  position: relative;
  top: 20px;
  width: 200px;
}
.togle{
  margin-left: 20px;
  margin-right: 20px;
  width: 200px;
  height: 50px;
  display: flex;
  color:black;
  align-items: center;
  justify-content: center;
  justify-content: space-between;
}
h1{
  margin: 10px;
  font-weight: bold;
}
.element-3 {
  top: 104px;
  z-index: 1;
  width: 129px;
  height: 138px;
  background: url('./assets/icon.png') rgba(222, 222, 222, 0);
  background-size: cover;
  background-position: left top;
}
</style>
