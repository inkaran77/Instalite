<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Mes Photos</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>
            <div id="myphoto">
              
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
export default{
  props: {
    dataBackgroundColor: {
      type: String,
      default: ''
    }
  },
  name: 'app',
  data () {
    return {
      UserId: '',
      Password:''
    }
  },

  methods:{


      },
      updated () {
        this.$http.get('http://localhost:5000/Instalite/GetMyProfile',{headers: {
         'Authorization': 'Bearer '+ localStorage.token
       }}).then(response => {


            var user=response.data
            localStorage.setItem('user2',JSON.stringify(user))
            console.log(localStorage.getItem('user2'));
            localStorage.user = response.data

          },(response) => {
        alert('une erreur est survenu')
      })
      }
}
</script>
