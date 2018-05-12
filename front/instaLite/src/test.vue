<template>
  <div class="hello">
    <picture-input
      ref="pictureInput"
      @change="onChange"
      width="100"
      height="200"
      margin="16"
      accept="image/jpeg,image/png"
      size="10"
      buttonClass="btn"
      :customStrings="{
        upload: '<h1>Bummer!</h1>',
        drag: 'Drag a ðŸ˜º GIF or GTFO'
      }">
    </picture-input>
     <input type="file" name="fichier" @change="onFileChanged">
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
        UserId: '',
        Password:'',
        My_photo:null
      }
    },
    computed: {
        clUrl: function() {
            return `https://api.cloudinary.com/v1_1/${this.cloudinary.cloudName}/upload`
          },
            },
    methods:{

          onFileChanged (event) {
            onChange(event)
         this.My_photo = event.target.files[0]
         console.log(event);
       },


       onChanged(image){
         this.image=image
         this.My_photo=image
       },
       onChange (file) {
         console.log('clikde')
     const formData = new FormData()
     formData.append('file', file);
     formData.append('upload_preset', this.cloudinary.uploadPreset);
     formData.append('tags', 'gs-vue,gs-vue-uploaded');
     // For debug purpose only
     // Inspects the content of formData
     for(var pair of formData.entries()) {
       console.log(pair[0]+', '+pair[1]);
     }
     this.$http.post(this.clUrl, formData).then(response => {

  response.data.secure_url;

  }, response => {
    // error callback
  });

   }
        },
  }
  </script>
