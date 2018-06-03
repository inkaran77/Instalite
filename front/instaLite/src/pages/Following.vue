
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


              <!-- list of followings -->
              <li class="following-id" v-for="(following, index) in followinglist">
                <div class="Picture">
                  <avatar :image='following.UrlPhoto' size ="100"></avatar>
                </div>

                 <div class="profile_name" >
                   <h3>{{following.UserId}}</h3>
                 </div>

                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload">
                        Following
                    </button>
                  <div>
                    <a v-on:click="unfollow(following.UserId)" href="#" style="color:#333333">Unfollow</a>
                  </div>
                  </div>
                </div>
              </li>


            </div>

           </md-card-content>
         </md-card>
       </div>
     </div>
   </div>
 </template>
<script>

import Avatar from 'vue-avatar-component'

export default{

  components: { Avatar },

  props: {
    dataBackgroundColor: {
      type: String,
      default: ''
    },
  },
  name: 'app',
  data () {
    return {
      followinglist:null
    }
  },

  methods:{


    unfollow : function(Id){

       this.$http.delete('http://localhost:5000/Instalite/UnFollow',{
        Id : this.UserId
      },{
        headers: {
          'Authorization': 'Bearer '+ localStorage.token
        }}).then(response =>{
          this.followinglist.slice(index, 1)
        console.log(response.status)
        })
    }

      },

mounted:function(){

      this.$http.get('http://localhost:5000/Instalite/GetAllMyFollowings',{
        headers: {
          'Authorization': 'Bearer '+ localStorage.token
        }
        }).then(response => {

       this.followinglist = response.data.MyFollowings
        console.log(response.status)
  })



      },
}
</script>
<style>
  .buttonload {
    border-radius: 5px;
    color : black;
    }
  .fa-spin {
    color : black;
    }


  .following-id{
    background:#FFFFFF;
    border:2px solid #CCCCCC;
    font-weight:bold;
    color:#FFFFFF;
    margin:auto;
  }
  .Picture{
    display: inline-block;
    vertical-align: middle;
    color:black;
    margin-top: 1%;
    margin-bottom: 1%;
    margin-left:1%
  }

  .profile_name{
    display: inline-block;
    margin-left: 1%;
    margin-right: 69%;
    margin-bottom: 1%;
    color:black;
  }

 .drop_container{
    display: inline-block;
    position:relative;
  }

  .dropdown1 button{
    border:none;
    padding:8px 20px;
    background-color:#DDDDDD;
    color:#333333;
    transition:.3s;
    cursor:pointer;
    display:inline-block;
    position:relative;

  }

  .dropdown1:hover button{
    background-color:#BBBBBB;
  }

  .dropdown1 div{
    background-color:#fff;
    box-shadow:0 4px 8px rgba(0,0,0,0.2);
    z-index:1;
    visibility:hidden;
    position:absolute;
    min-width:100%;
    opacity:0;
    transition:.3s;
  }

  .dropdown1:hover div{
    visibility:visible;
    opacity:1;
  }

  .dropdown1 div a{
    display:block;
    padding:8px;
    color:#000000;
    transition:.1s;
    white-space:nowrap;
  }

  .dropdown1 div a:hover{
    background-color:#DDDDDD;
    color:#333333;
  }

</style>
