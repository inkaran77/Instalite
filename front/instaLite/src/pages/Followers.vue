<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Mes Abonnés</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>
            <div id="followers">
           <div class="container-followers">
             <!-- scrool-->
             <div class="follower">
               <div class="onfollow">
               <div class="avatar">
                 <img src= "https://c.wallhere.com/photos/2a/89/mountains_sky_snow_stars_night_space_winter_lights-258309.jpg!d">
               </div>
                <h4 class="name"style="margin-left:10px;"> User Nnnnnaaaaaannname </h4>
              </div>
                  <button class="btnn btn-danger">Se desabonner</button>

           </div>
           <!-- scrool -->
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
}
</script>
<style>
.container-followers{
  max-width:100%;
  max-height: 500px;
  overflow: scroll;
  display: flex;
  flex-direction: column;
}
.follower{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  flex-wrap: wrap;
  height: auto;
  background-color: white;
  border-style: solid;
  border-width: 2px;
  border-color: #A4A4A4;
  border-radius: 5px;
  margin-top: 5px;
  margin-bottom: 5px;
}
.avatar{
  display: flex;
  justify-content: center;
  align-items: center;
  min-width: 50px;
  min-height: 50px;
  max-width: 50px;
  max-height: 50px;
  margin-bottom: 5px;
  margin-top: 5px;
  border-radius: 25px;
  background-color: black;
  margin-left: 5px;
  overflow: hidden;
  border-style: solid;
  border-width: 1px;
  border-color: #A4A4A4;

}
.onfollow{
  display: flex;
  overflow: hidden;
  text-overflow: ellipsis;
  align-items: center;
  flex-direction: row;
}
.name{
margin-left:10px;
white-space: wrap;
min-width: 100px;
overflow: hidden;
text-overflow: ellipsis;
}
.btnn{
  border-radius: 5px;
  height: 30px;
  display: block;
  border: none;
  position: relative;
  margin-bottom:5px;
  margin-right: 5px;
  margin-left: 5px;
  margin-top:5px;
}
</style>
