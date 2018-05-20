<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Nouveau Post</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>
            <div id="post">

                <div>
                  <picture-input
                    ref="pictureInput"
                    @change="onChanged"
                    width="600"
                    height="400"
                    margin="16"
                    accept="image/jpeg,image/png"
                    size="10"
                    buttonClass="btn"
                    :customStrings="{
                      upload: '<h1>Bummer!</h1>',
                      drag: 'Drag and Drop ou cliquer ici pour selectionner un fichier'
                    }">
                  </picture-input>
                  <div class="flexcenter">
                    <input class="flexcenter" type="text" placeholder="Titre" v-model="title" required="" />
                    <b-form-textarea id="textarea1"
                    v-model="description"
                    placeholder="Description"
                    :rows="6"

                    :max-rows="6">
                  </b-form-textarea>
                  <button  v-on:click="vPost()" class="btn btn-success btn-touch ">Poster</button>

                  </div>
              </div>
            </div>
           </md-card-content>
         </md-card>
       </div>
     </div>
   </div>
 </template>
<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import PictureInput from 'vue-picture-input'
export default{
  props: {
    dataBackgroundColor: {
      type: String,
      default: ''
    }
  },
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
      My_photo:null,
      UrlPhoto:'',
      description:'',
      title:''

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
     return true;
    }, response => {
     // error callback
     alert('verifier votre connexion internet et réessayer')
     return false;
    });

    },
    upload:function() {

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
 return true;
}, response => {
 // error callback
 alert('verifier votre connexion internet et réessayer')
 return false;
});

},

  vPost:function(){

    if(this.upload()){
   this.$http.post('http://localhost:5000/Instalite/PostPhoto',{


     Title:this.title,
     Description:this.description,
     UrlPhoto:this.UrlPhoto

   }).then(response => {

       alert('Votre photo est en ligne')
      // this.$emit('changeCompo','connexion')
       console.log(response.data);
     },(response) => {

     alert('échec, veuillez réessayer')
 })
 }
}


      },
}
</script>
<style>
.flexcenter{
  display: flex;
  align-content: center;
  flex-direction : column;
}
button:nth-of-type(n){
  position: relative;
  margin: 20px;
  display: flex;
  justify-content: center;

}
</style>
