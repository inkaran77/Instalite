
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
            <!-- Add icon library -->
          <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

            <div id="followers">


            <!-- waiting list -->
              <li class="follower-id" v-for="follower in waitinglist">
                <div class="Picture">
                  <avatar :image='follower.UrlPhoto' size ="100"></avatar>
                </div>

                 <div class="profile_name" >
                   <h3>{{follower.UserId}}</h3>
                 </div>

                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload">
                      <i class="fa fa-circle-o-notch fa-spin"></i>  Waiting
                    </button>
                  <div>
                    <a v-on:click="acceptF(follower.UserId)" href="#" style="color:#333333">Accept</a>
                    <a v-on:click="ignoreF(follower.UserId)" href="#" style="color:#333333">Ignore</a>
                  </div>
                  </div>
                </div>
              </li>

              <!-- list of followers -->
              <li class="follower-id" v-for="follower in followerlist">
                <div class="Picture">
                  <avatar :image='follower.UrlPhoto' :size ="100"></avatar>
                </div>

                 <div class="profile_name" >
                   <h3>{{follower.UserId}}</h3>
                 </div>

                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload">
                        Following
                    </button>
                  <div>
                    <a v-on:click="deleteF(follower.UserId)" href="#" style="color:#333333">Delete</a>
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
      followerlist:null,
      waitinglist :null,
      UserId:''
    }
  },

  methods:{

    acceptF : function(Id){
      this.UserId = Id
      this.$http.put('http://localhost:5000/Instalite/AcceptFollower',{},{
        params :{UserId : this.UserId}
       ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{
          this.getwaitinglist()
          this.getfollowers()
        console.log(response.status)
        })

    },

    ignoreF : function(Id){
      this.UserId = Id
       this.$http.delete('http://localhost:5000/Instalite/RefuseFollowRequest',{
       params:{ UserId : this.UserId }
       ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{
          this.getwaitinglist()
        console.log(response.status)
        })
    },

    deleteF : function(Id){
      this.UserId = Id
       this.$http.delete('http://localhost:5000/Instalite/DeleteFollower',{
        params:{UserId : this.UserId}
       ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{
          this.getfollowers()
        console.log(response.status)
        })
    },

    getwaitinglist : function(){
      this.$http.get('http://localhost:5000/Instalite/GetWaitingList',{ headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}
        ).then(response => {
       this.waitinglist = response.data.MyWaitingList
        console.log(response.data)
  });
    },
    getfollowers : function() {

      this.$http.get('http://localhost:5000/Instalite/GetAllMyFollowers',{ headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}
        ).then(response => {
       this.followerlist = response.data.MyFollowers
        console.log(response.data)
  })
    }

      },

mounted:function(){

      this.getwaitinglist()
      this.getfollowers()

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


  .follower-id{
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
    width: 76%;
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
