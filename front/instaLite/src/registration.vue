<template>
  <body>
    <form class="form-horizontal">
<fieldset>

<!-- Form Name -->
<legend>Inscription</legend>

<!-- Text input-->
<div class="form-group">
 <label class="col-md-4 control-label" for="nominput"></label>
 <div class="col-md-4">
 <input  placeholder="Nom" class="form-control input-md" required="" type="text" v-model="First_name">

 </div>


<!-- Text input-->

 <label class="col-md-4 control-label" for="prenominput"></label>
 <div class="col-md-4">
 <input  placeholder="Prénom" class="form-control input-md" required="" type="text" v-model="Last_name">

 </div>



 <label class="col-md-4 " for="dateinput"></label>
 <div class="col-md-4">
<input  placeholder="Date de naissance" class="form-control input-group date" required="" type="date" v-model="Birth_date">

 </div>


<!-- Multiple Radios (inline) -->

 <label class="col-md-4 control-label" for="radios">Sexe :</label>
 <div class="col-md-4">
   <label class="radio-inline" for="radios-0">
     <input  value="Male" checked="checked" type="radio" v-model="Gender">
     Homme
   </label>
   <label class="radio-inline" for="radios-1">
     <input  value="Female" type="radio" v-model="Gender">
     Femme
   </label>
 </div>


<!-- Text input-->

 <label class="col-md-4 control-label" for="emailinput"></label>
 <div class="col-md-4">
 <input  placeholder="Email" class="form-control input-md" required="" type="email" v-model="Email">

 </div>


<!-- Password input-->

 <label class="col-md-4 control-label" for="passwordinput"></label>
 <div class="col-md-2">
   <input placeholder="Mot de passe" class="form-control input-md" required="" type="password" v-model="Password">
   <input  placeholder="Confirmation mot de passe" class="form-control input-md" required="Password" type="password">

 </div>


<!-- Text input-->

 <label class="col-md-4 control-label" for="cityinput"></label>
 <div class="col-md-4">
 <input  placeholder="Ville" class="form-control input-md" required="" type="text" v-model="City">

 </div>


<!-- Text input-->

 <label class="col-md-4 control-label" for="countryinput"></label>
 <div class="col-md-4">
 <input  placeholder="Pays" class="form-control input-md" required="" type="text" v-model="Country">

 </div>


<!-- Button -->

 <label class="col-md-4 control-label" for="signbutton"></label>
 <div class="col-md-4">
   <button  v-on:click="signUp()" class="btn btn-primary">Inscription</button>
 </div>
</div>

</fieldset>
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
      this.Id=this.$refs.login.value
      this.Password=this.$refs.password.value
      this.$emit('changeCompo','registration')
      this.$http.post('http://localhost:5000/Instalite/Inscription/',{
        First_name:this.First_name,
        Last_name:this.Last_name,
        Birth_date:this.Birth_date,
        Gender:this.Gender,
        Email:this.Email,
        Id:this.Id,
        Password:this.Password,
        My_photo:this.My_photo,
        City:this.City,
        Country:this.Country
      }).then(function(data){
          console.log(data);
    })
  },
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
  color: rgb(255, 255, 255);
}

</style>
