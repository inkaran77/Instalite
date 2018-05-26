<template>
  <md-card class="md-card-profile">
    <div class="md-card-avatar">
      <picture-input
        ref="pictureInput"
        @change="onChanged"
        width="100"
        height="150"
        margin="16"
        accept="image/jpeg,image/png"
        size="10"
        buttonClass="btn"
        v-bind:prefill='UrlPhoto'
        :customStrings="{
          upload: '<h1>Bummer!</h1>',
          drag: 'Votre Photo',

        }">
      </picture-input>
    </div>
    <md-card-content>
          <h6 class="category text-gray">Cliquer sur la photo pour modifier</h6>
          <h4 class="card-title">Vos informations</h4>
    </md-card-content>
    <md-card-content>

      <div>
      <div class="md-layout">
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Login (disabled)</label>
            <md-input v-model="UserId" disabled ></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Mot de passe</label>
            <md-input v-model="Password" type="password" v-validate="'required'"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Email</label>
            <md-input v-model="Email" type="email" v-validate="'required'"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-50">
          <md-field>
            <label>Nom</label>
            <md-input v-model="Last_name" type="text" v-validate="'required'"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-50">
          <md-field>
            <label>Prénom</label>
            <md-input v-model="First_name" type="text" v-validate="'required'"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-100">
          <md-field>
            <label>Date de naissance</label>
            <md-input v-model="Birth_date"disabled type="text"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Ville</label>
            <md-input v-model="City" type="text" v-validate="'required'"></md-input>
          </md-field>
        </div>
        <div class="md-layout-item md-small-size-100 md-size-33">
          <md-field>
            <label>Pays</label>
            <md-input v-model="Country" type="text" v-validate="'required'"></md-input>
          </md-field>
        </div>
</div>
        <div class="md-layout-item md-size-100 text-right">
          <md-button v-on:click="updateProfil()" class="md-raised md-success">Mettre à jour</md-button>
        </div>
      </div>
  </md-card-content>
  </md-card>
</template>
<script>
import PictureInput from 'vue-picture-input'
export default {
  components: {
      PictureInput
    },
  name: 'user-card',
  props: {

  },
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
      Password: null,
      UserId: null,
      Email: null,
      Birth_date:null,
      Last_name: null,
      First_name: null,
      City: null,
      Country: null,
      UrlPhoto:null,
      profile:JSON.parse(localStorage.getItem('user2'))
    }
  },
  computed: {
      clUrl: function() {
          return `https://api.cloudinary.com/v1_1/${this.cloudinary.cloudName}/upload`
        },
          },
  mounted:function() {
    this.getAll();
    this.setprofil();
  },
  methods:{
    updateProfil:function(){

      this.$validator.validateAll().then((result) => {
            if (result) {
      this.$http.put('http://localhost:5000/Instalite/ModifyMyProfile',{
        First_name:this.First_name,
        Last_name:this.Last_name,
          Email:this.Email,
          Password:this.Password,
        UrlPhoto:this.UrlPhoto,
        City:this.City,
        Country:this.Country
      },{headers: {
       'Authorization': 'Bearer '+ localStorage.token
     }}).then(response => {
       this.getAll()

          alert('Mise à jour effectuée')


        },(response) => {

       alert('échec de la mise à jour')
    })
  }

     });
  },
  onChanged(image){
    this.image=image
    this.My_photo=image
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
  setprofil:function(){
    this.Password=this.profile.Password,
    this.UserId=this.profile.UserId,
    this.Email=this.profile.Email,
    this.Last_name=this.profile.Last_name,
    this.First_name=this.profile.First_name,
    this.City=this.profile.City,
    this.Country=this.profile.Country,
    this.UrlPhoto=this.profile.UrlPhoto,
    this.Birth_date=this.profile.Birth_date
  },

  getAll:function () {
    this.$http.get('http://localhost:5000/Instalite/GetMyProfile',{headers: {
     'Authorization': 'Bearer '+ localStorage.token
   }}).then(response => {


        var user=response.data
        localStorage.setItem('user2',JSON.stringify(user))
        console.log(localStorage.getItem('user2'));


      },(response) => {
    alert('une erreur est survenu')
  })
},
  }
}

</script>
<style>

</style>
