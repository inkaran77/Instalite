<template>
    <transition name="slide-fade">
      <form @submit.prevent="">
  <div>
    <div class="registre">
      <h4 style="margin-left: 110px; margin-right: 110px;">Vos données personnelles</h4>
      <div class="barre"></div><div class="barre" ></div><div class="barre" style="background-color:#A4A4A4;"></div>
      <input v-validate="'required|alpha'" required v-model="Last_name" type="text" placeholder="Nom">
      <input v-validate="'required|alpha'" required v-model="First_name" type="text" placeholder="Prenom">
      <input  v-validate="'required'" required v-model="Birth_date" style="height: 30px; width:180px;"type="date"  placeholder="Date de naissance">
      <div>
      <select placeholder="Sexe" v-validate="'required'"  required v-model="Gender" id="sexe">
        <option value="F" >Femme</option>
        <option value="H" >Homme</option>
        </select><br>
      </div>
      <input v-validate="'required|alpha'"  required v-model="Country" type="text" placeholder="Pays">
      <input v-validate="'required|alpha'"  required v-model="City" type="text"  placeholder="Ville">
    </div>
    <div class="registre" style="margin-top: 0;">
    <button v-on:click="back()" class="btn-danger btn btn-reg">Retour</button>
    <button v-on:click="next()" class="btn-primary btn btn-reg">Suivant</button>
      </div>
  </div>
</form>
</transition>
  </template>
  <script>
  import 'bootstrap/dist/css/bootstrap.css'
  import 'bootstrap-vue/dist/bootstrap-vue.css'
  import test from '@/test.vue'
  export default{
    components : {

    'test':test

  },
    props:{

      dataBackgroundColor: {
        type: String,
        default: ''
      },
      Login:{
        type:String
      }
    },
    name: 'app',
    data () {
      return {

         urlPhoto:'http://res.cloudinary.com/dvejva95o/image/upload/v1527154205/instaLite/wyn8yxonngrrbc4kxhv5.jpg',
         Myphotos2:null,
         titre:'titre de la photo',
         commentsList:null,
         description:'une description',
         author:'autheur',
         Last_name:'',
         First_name:'',
         Birth_date:'',
         Gender:'',
         Country:'',
         City:''

  }
    },


    methods:{

      back:function(){
        this.$emit('changePage','registration')
      },
      next:function(){
        this.$validator.validateAll().then((result) => {
              if (result) {
        this.$emit('changePage','registration3')
        }});
      },
      getUrl:function(url){
        this.urlPhoto=url
        this.getAllComments()
        this.getPost()
        this.$modal.show('description');

      },

      getAllComments:function(){
        this.$http.get('http://localhost:5000/Instalite/GetAllComments',{
          UrlPhoto:this.urlPhoto
        },{headers: {
         'Authorization': 'Bearer '+ localStorage.token
       }}).then(response => {
         this.commentsList=response.data.Comments
         console.log(response.data)


          //console.log(this.MyPhotos.Lien)
          })

      },

      getPost:function(){
        this.$http.get('http://localhost:5000/Instalite/GetPost',{
          UrlPhoto:this.urlPhoto
        },{headers: {
         'Authorization': 'Bearer '+ localStorage.token
       }}).then(response => {
         //this.commentsList=response.data.Comments
         console.log(response.data)


          //console.log(this.MyPhotos.Lien)
          })
      }

        },

        mounted:function() {
          console.log(this.Login)
          this.$http.get('http://localhost:5000/Instalite/GetMyPhotos',{headers: {
           'Authorization': 'Bearer '+ localStorage.token
         }}).then(response => {

           console.log(response.data.MyPhotos)
        this.Myphotos2=response.data.MyPhotos
this.getAllComments()
            //console.log(this.MyPhotos.Lien)
            })
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

.container-img{
	position: absolute;
	left: calc(50% - 90px);
	top : -80px;
}
.registre{
	margin-top: 100px;
	display: flex;
	justify-content: center;
	flex-wrap: wrap;
	flex-direction: row;
}
input{
		margin-left: 10px;
		margin-top: 10px;
		margin-right: 10px;
	}
	.homme{
		display: block;
		width: 5px;
		height: 10px;
		background-color: red;
	}
	#sexe{
		width:180px;
		height: 30px;
		margin-top: 10px;

		margin-left: 10px;
		margin-right: 10px;
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
