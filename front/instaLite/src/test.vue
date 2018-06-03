<template>

<div class="body">
  <form @submit.prevent="">
  <div class="bander">

    <div class="element element-3"></div>
    <center><h1>Inscription</h1></center>
    <div >
<fieldset>
  <div class="container-photo">

       <picture-input
         ref="pictureInput"
         @change="onChanged"
         width="100"
         height="150"
         margin="16"
         accept="image/jpeg,image/png"
         size="10"
         buttonClass="btn"
         :customStrings="{
           upload: '<h1>Bummer!</h1>',
           drag: 'Votre Photo'
         }">
       </picture-input>


   </div>

   <div class="container-inpute">
     <input  placeholder="Login" name="login" v-validate="'required|alpha'" class="{'input': true, 'is-danger': errors.has('login'),input-md sizinput2 } " required="" type="text" v-model="UserId">

     <input  placeholder="Nom" name="Nom" v-validate="'required|alpha'" class="{'input': true, 'is-danger': errors.has('Nom'),input-md sizinput } " required="" type="text" v-model="First_name">
   <input  placeholder="Prénom" v-validate="'required|alpha'" class=" input-md sizinput" required="" type="text" v-model="Last_name">
   <input  placeholder="Date de naissance" v-validate="'required'" class=" input-group date sizinput" required="" type="date" v-model="Birth_date">
       <div class="togle">
         Femme <input style="color:black"type="radio" class="togle2"name="sexe"required=""value="Female" v-model="Gender">
         Homme <input type="radio" class="togle2"name="sexe"required=""value="Male" v-model="Gender">
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
</div>

</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import PictureInput from 'vue-picture-input'
export default {
  components: {
      PictureInput
    },
  name: 'app',
  data () {
    return {
      cloudinary: {
   uploadPreset: 'nachrlb3',
   apiKey: '157225663566444',
   cloudName: 'dvejva95o'
 },
 thumb: {
     url: ''
   },
   thumbs:[],
      UserId:'',
      First_name: '',
      Last_name:'',
      Birth_date: '',
      Gender:'',
      Email: '',
      Id:'',
      Password:'',
      My_photo:null,
      City: '',
      Country:'',
      UrlPhoto:''
    }
  },
  computed: {
      clUrl: function() {
          return `https://api.cloudinary.com/v1_1/${this.cloudinary.cloudName}/upload`
        },
          },
  methods:{
    onChanged(image){
      this.image=image
      this.My_photo=image
      console.log('clikde')
  const formData = new FormData()
  formData.append('file', this.My_photo);
  formData.append('upload_preset', this.cloudinary.uploadPreset);
  formData.append('tags', 'gs-vue,gs-vue-uploaded');
  // For debug purpose only
  // Inspects the content of formData
  for(var pair of formData.entries()) {
    console.log(pair[0]+', '+pair[1]);
  }
  this.$http.post(this.clUrl, formData).then(response => {

    this.UrlPhoto=response.data.secure_url;
    console.log(this.UrlPhoto)

}, response => {
 // error callback
 if(response.status==400){
   alert('Ajouter une photo')
 }
 else{alert('verifier votre connexion internet et réessayer')}
 return false;
});

    },

     signUp:function(){

   this.$validator.validateAll().then((result) => {
         if (result) {
           if(this.UrlPhoto===''){
             alert('Ajouter photo')
             return
            }
console.log('click')
var md5 = require('js-md5');
var hachPass=md5(this.Password)
           this.$http.post('http://localhost:5000/Instalite/Inscription',{

             UserId:this.UserId,
             First_Name:this.First_name,
             Last_Name:this.Last_name,
              Birth_date:this.Birth_date,
              Gender:this.Gender,
               Email:this.Email,
               Password:hachPass,
             UrlPhoto:this.UrlPhoto,
             City:this.City,
             Country:this.Country
           }).then(response => {

               alert(response.data)
                 document.location.reload(true);
               console.log(response.data);
             },(response) => {
             if(response.status==400){
               alert('Login déja utilisé, veuillez choisir un autre Login')
             }
            else{ alert('échec inscription, veuillez réessayer')}
         })
           return;
         }

       });
     },

  },

}
</script>

<style>

body, html {
    height: 100%;
    margin: 0;
}

.bg {
    /* The image used */

    overflow: scroll;
    /* Full height */
    height: 100%;

    /* Center and scale the image nicely */
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
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
  min-height: 620px;
  max-width: 600px;
  max-height: 550px;
  background-color: rgba(255,255,255,0.6);

  position: relative;
  top: 10px;
  border-radius: 25px;

}
.container-photo{
  width: 100%;
  height: 200px;
  display: flex;
  justify-content: center;
  position: relative;
  top : -150px;
  left:420px;
}
.photo{
  display: block;
  position: relative;
  min-width: 100px;
  max-width: 300px;
  min-height: 150px;
  max-height: 250px;

  top: -50px;
  left: 190px;


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
  top: -170px;


}
.btn-touch{
  position: relative;
  top: 10px;
  width: 200px;
  border-radius: 20px;
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
