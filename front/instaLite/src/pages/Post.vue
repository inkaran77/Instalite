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
                    <input  type="text" placeholder="Titre" v-model="title" required="" />
                    <b-form-textarea id="textarea1"
                    v-model="description"
                    placeholder="Description"
                    :rows="6"
                    style="height:100px;margin-top:15px;"
                    :min-rows="6">
                  </b-form-textarea>
                  <div class="flexcenter2">
                  <button style="width:50%;"  v-on:click="vPost()" class="btn btn-success  ">Poster</button>

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

  vPost:function(){
    if(this.UrlPhoto===''){
      alert('Ajouter photo')
      return
     }
   this.$http.post('http://localhost:5000/Instalite/PostPhoto',{

     Author:'fff',// localStorage.user.First_Name + localStorage.user.Last_Name
     Title:this.title,
     Description:this.description,
     UrlPhoto:this.UrlPhoto,
     Date:new Date()

   }, {headers: {
    'Authorization': 'Bearer '+ this.$cookies.get("token")
  }}).then(response => {
    this.$notify(
      {
      message: 'Votre photo est en ligne',
      icon: 'add_alert',
      horizontalAlign: 'right',
      verticalAlign: 'bottom',
      type: 'success'
    })
       this.$router.push({
           name: 'Mes Photos'
       });
      // this.$emit('changeCompo','connexion')
       console.log(response.data);
     },(response) => {
       this.$notify(
         {
         message: 'échec',
         icon: 'add_alert',
         horizontalAlign: 'right',
         verticalAlign: 'bottom',
         type: 'danger'
       })
 })
},
updated () {

}



      },
}
</script>
<style>
.flexcenter{
  display: flex;
  flex-direction : column;
  align-content: center;
}
.flexcenter2{
  display: flex;
  justify-content: center;
  margin-top: 15px;
}

</style>
