<!-- la dernier page d'inscription -->
<template>
    <transition name="slide-fade">
    <div>
    <div class="registre3">
      <h4 style="margin-left: 150px; margin-right: 150px;">Votre photo de profile</h4>
    <div class="barre"></div><div class="barre" ></div><div class="barre"></div>
    <picture-input
      ref="pictureInput"
      @change="onChanged"
      width="200"
      height="300"
      margin="16"
      accept="image/jpeg,image/png"
      size="10"
      buttonClass="btn"
      hideChangeButton="true"
      style="margin-top:20px;"
      :customStrings="{
        upload: '<h1>Bummer!</h1>',
        drag: 'Drag and Drop ou cliquer ici pour selectionner un fichier'
      }">
    </picture-input>
    <div class="registre3" style="margin-top: 0;">
    <button v-on:click="back()" class="btn-danger btn btn-reg">Retour</button>
    <button v-on:click="signup()" class="btn-success btn btn-reg">Valider</button>
      </div>
  </div>

</div>
</transition>
  </template>
  <script>
  import 'bootstrap/dist/css/bootstrap.css'
  import 'bootstrap-vue/dist/bootstrap-vue.css'
  import PictureInput from 'vue-picture-input'

  export default{
    components : {
PictureInput

  },
    props: {
      Login:{},
      Email:{},
      Pass:{},
      Ln:{},
      Fn:{},
      Bd:{},
      Ge:{},
      Co:{},
      Ci:{},
      dataBackgroundColor: {
        type: String,
        default: ''
      }
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
        My_photo:null,
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

   }
   else{alert('verifier votre connexion internet et réessayer')}
   return false;
  });

      },
      back:function(){
        this.$emit('changePage','registration2')
      },



      signup:function(){
        if(this.UrlPhoto!=''){
 var md5 = require('js-md5');
 var hachPass=md5(this.Pass)
            this.$http.post('http://localhost:5000/Instalite/Inscription',{

              UserId:this.Login,
              First_Name:this.Fn,
              Last_Name:this.Ln,
               Birth_date:this.Bd,
               Gender:this.Ge,
                Email:this.Email,
                Password:hachPass,
              UrlPhoto:this.UrlPhoto,
              City:this.Ci,
              Country:this.Co
            }).then(response => {
              alert('ok à changer ')
              this.$emit('changePage','registration')
              },(response) => {
              if(response.status==400){
                alert('Login déja utilisé, veuillez choisir un autre Login')
              }
             else{ alert('échec inscription, veuillez réessayer')}
          })
            return;
          }

}

        },

        mounted:function() {

        },

  }
  </script>
<style>
.slide-fade-enter-active {
  transition: all .8s ease;
}

.slide-fade-enter, .slide-fade-leave-to
/* .slide-fade-leave-active below version 2.1.8 */ {
  transform: translateX(10px);
  opacity: 0;
}

.registre3{
	margin-top: 100px;
	display: flex;
	justify-content: center;
	flex-wrap: wrap;
	flex-direction: row;
}

.btn-reg{
  margin-bottom: 20px;
   margin-top: 20px;
   margin-left: 10px;
   margin-right: 10px;
}
.barre{
  display: block;
  width: 20%;
  height: 1px;
  background-color: #2E9AFE;
  margin-left: 5px;
}
</style>
