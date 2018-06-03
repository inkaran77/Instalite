<template>
    <transition name="slide-fade">
      <form @submit.prevent="">
  <div>
    <div class="registre">
      <h4 style="margin-left: 110px; margin-right: 110px;">Vos données personnelles</h4>
      <div class="barre"></div><div class="barre" ></div><div class="barre" style="background-color:#A4A4A4;"></div>
      <input v-validate="'required|alpha'" required v-model="User2.Last_name" type="text" placeholder="Nom">
      <input v-validate="'required|alpha'" required v-model="User2.First_name" type="text" placeholder="Prenom">
      <input  v-validate="'required'" required v-model="User2.Birth_date" style="height: 30px; width:180px;"type="date"  placeholder="Date de naissance">
      <div>
      <select placeholder="Sexe" v-validate="'required'"  required v-model="User2.Gender" id="sexe">
        <option value="F" >Femme</option>
        <option value="H" >Homme</option>
        </select><br>
      </div>
      <input v-validate="'required|alpha'"  required v-model="User2.Country" type="text" placeholder="Pays">
      <input v-validate="'required|alpha'"  required v-model="User2.City" type="text"  placeholder="Ville">
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

    },
    name: 'app',
    data () {
      return {

         User2:{
         Last_name:'',
         First_name:'',
         Birth_date:'',
         Gender:'',
         Country:'',
         City:''
}
  }
    },


    methods:{

      back:function(){
        this.$emit('changePage','registration')
      },
      next:function(){

        this.$validator.validateAll().then((result) => {
              if (result) {

        this.$emit('call2',this.User2)
        this.$emit('changePage','registration3')
        }});
      },


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
