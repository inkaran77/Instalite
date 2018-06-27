
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
              <div class="follower-id" v-for="follower in waitinglist">
                <div class="UserDisplay">
                <div class="Picture">
                  <avatar :image='follower.UrlPhoto' :size ='100'></avatar>
                </div>

                 <div class="profile_name" >
                   <h3>{{follower.UserId}}</h3>
                 </div>

                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload">
                      <i class="fa fa-circle-o-notch fa-spin"></i> Waiting
                    </button>
                  <div>
                    <a v-on:click="acceptF(follower.UserId)" href="#" style="color:#333333">Accepter</a>
                    <a v-on:click="ignoreF(follower.UserId)" href="#" style="color:#333333">Ignorer</a>
                  </div>
                  </div>
                </div>
              </div>

              </div>
              <!-- list of followers -->
              <div class="follower-id" v-for="follower in followerlist">
                <div class="UserDisplay">
                <div class="Picture">
                  <avatar :image='follower.UrlPhoto' :size ='100'></avatar>
                </div>

                 <div class="profile_name" >
                   <h3>{{follower.UserId}}</h3>
                 </div>

                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload">
                       &nbsp; Abonné &nbsp;
                    </button>
                  <div>
                    <a v-on:click="deleteF(follower.UserId)" href="#" style="color:#333333">Supprimer</a>
                  </div>
                  </div>
                </div>
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
        if(response.status==200){
          this.$notify(
                    {
                      message: 'Abonnée accepté',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'success'
                    })
        } else if(response.status == 400) {
          this.$notify(
                    {
                      message: 'Abonnée déjà accepté',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'danger'
                    })
        }
          this.getwaitinglist()
          this.getfollowers()

        })

    },

    ignoreF : function(Id){
      this.UserId = Id
       this.$http.delete('http://localhost:5000/Instalite/RefuseFollowRequest',{
       params:{ UserId : this.UserId }
       ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{

        if(response.status==200){
          this.$notify(
                    {
                      message: 'Demande abonnée ingorée',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'success'
                    })
        } else if(response.status == 400) {
          this.$notify(
                    {
                      message: 'Demande abonnée déjà ignoré',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'danger'
                    })
        }
        this.getwaitinglist()
        })
    },

    deleteF : function(Id){
      this.UserId = Id
       this.$http.delete('http://localhost:5000/Instalite/DeleteFollower',{
        params:{UserId : this.UserId}
       ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{

        if(response.status==200){
          this.$notify(
                    {
                      message: 'Abonnée supprimé',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'success'
                    })
        } else if(response.status == 400) {
          this.$notify(
                    {
                      message: 'Abonnée déjà supprimé',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'danger'
                    })
        }
        this.getfollowers()
        })
    },

    getwaitinglist : function(){
      this.$http.get('http://localhost:5000/Instalite/GetWaitingList',{ headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}
        ).then(response => {
       this.waitinglist = response.data.MyWaitingList


  });
    },
    getfollowers : function() {

      this.$http.get('http://localhost:5000/Instalite/GetAllMyFollowers',{ headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}
        ).then(response => {
       this.followerlist = response.data.MyFollowers

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
    border-radius: 20px;
    font-size: 17px;
    }
  .fa-spin {
    color : black;
    }


  .follower-id{
    background:#FFFFFF;
    border-bottom:1px solid #BBBBBB;
    font-weight:bold;
    color:#FFFFFF;
    margin:auto;
    text-align: center;
    width:88%;
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
    text-align: left;

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
    border-radius: 10px;
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
    border-radius: 10px;
    text-align: center;
    font-size: 15px;
  }

  .dropdown1 div a:hover{
    background-color:#EEEEEE;
    color:#333333;
    text-align: center;
    font-size: 15px;
  }

</style>
