
<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Mes Abonnements</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>

            <div id="following">
              <!-- list of followings -->
              <div class="following-id" v-for="following in followinglist">
                <div class="Picture">
                  <avatar :image='following.UrlPhoto' :size ='100'></avatar>
                </div>

                 <div class="profile_name" >
                   <h3><a href="#" style="color:#000000" v-on:click="userinfo(following.UrlPhoto), show()">{{following.UserId}}</a></h3>
                    </div>
                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload">
                       &nbsp; Abonné &nbsp;
                    </button>
                    <div>
                      <a v-on:click="unfollow(following.UserId)" href="#" style="color:#333333">Se désabonner</a>
                    </div>
                  </div>
                </div>
              </div>
            </div>

               <modal :width="700" :height="300" name="UserInfo">
                 <div class="modaldisplay">
                 <div class="MPicture">
                  <avatar :image='UrlPhoto' :size ='170'></avatar>
                </div>
                   <div class="Mprofile_info" >
                   <h2>@{{UserName}}</h2>
                   <p class="info_nom">{{first_name}} {{last_name}}</p>
                   <p class="info_live">{{city}}, {{country}}</p>
                 </div>
                 <div class="Minfo_pff">
                   {{posts}} Poste(s) &emsp; &emsp; &emsp;  {{followers}} Abonnée(s) &emsp; &emsp; &emsp; {{followings}} Abonnement(s)
                </div>
                </div>
              </modal>



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
      followinglist:null,
      UserId:'',
      UrlPhoto:'',
      posts:'',
      followers:'',
      followings:'',
      first_name:'',
      last_name:'',
      city:'',
      country:'',
      UserName:''
    }
  },

  methods:{

    show : function(){
      this.$modal.show('UserInfo');;
    },


    unfollow : function(Id){
      this.UserId = Id
      console.log(this.UserId)
       this.$http.delete('http://localhost:5000/Instalite/UnFollow',{
       params: { UserId : this.UserId }
       ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{

          if(response.status==200){
          this.$notify(
                    {
                      message: 'Abonnement supprimé',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'success'
                    })
        } else if(response.status == 400) {
          this.$notify(
                    {
                      message: 'Abonnement déjà supprimé',
                      icon: 'add_alert',
                      horizontalAlign: 'right',
                      verticalAlign: 'bottom',
                      type: 'danger'
                    })
        }
         this.getmyfollowing()
        })
    },

    userinfo(urlphoto){

      this.UrlPhoto = urlphoto

      this.$http.get('http://localhost:5000/Instalite/GetUserProfile',{ params:{ UrlPhoto : this.UrlPhoto }
        ,
        headers: {'Authorization': 'Bearer '+ this.$cookies.get("token")}
        }).then(response =>{
           this.UserName = response.data.UserId
          this.followers = response.data.Followers.ListUsers.length
          this.followings = response.data.Followings.ListUsers.length
          this.posts = response.data.List_post.length
          this.first_name = response.data.First_name
          this.last_name = response.data.Last_name
          this.city = response.data.City
          this.country = response.data.Country
        console.log(response.data)
      })
    },

    getmyfollowing : function(){

      this.$http.get('http://localhost:5000/Instalite/GetAllMyFollowings',{
        headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }
        }).then(response => {

       this.followinglist = response.data.MyFollowings
        console.log(response.data)
  })
    }

      },

mounted:function(){

          this.getmyfollowing()

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


  .following-id{
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
    margin-left:1%;
  }

  .profile_name{
    display: inline-block;
    margin-left: 1%;
    width: 76%;
    margin-bottom: 1%;
    color:black;
    text-align: left;
  }

  /* Transition style*/

  .fade-enter-active, .fade-leave-active {
  transition: opacity .5s;
  }
  .fade-enter, .fade-leave-to {
    opacity: 0;
  }
  .UserInfo .name .location{
    color:#333333;
    font-style:italic;
    position: fixed;
    margin-left: 0.5%
  }


 .drop_container{
    display: inline-block;
    position:relative;
  }

  .dropdown1 button{
    border:none;
    padding: 8px 20px;
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
    text-align: center;
    border-radius: 10px;
    font-size: 15px;
  }

  .dropdown1 div a:hover{
    background-color:#EEEEEE;
    color:#333333;
    text-align: center;
    font-size: 15px;
  }
  /*Modal display*/

  .modaldisplay{
    background:#FFFFFF;
    border-bottom:1px solid #BBBBBB;
    font-weight:bold;
    margin:auto;
    margin-top: 5%;

    width:70%;
  }
  .MPicture{
    display: inline-block;

    color:black;
    margin-left:3%
  }

  .Mprofile_info{
    display: inline-block;
    margin-left: 3%;
    vertical-align: 30px;
    color:black;
    text-align: left;
    width:50%;


  }
  .info_nom{
    margin-left: 3%;
    font-size: 21px;
    font-weight: normal;
    font-style: italic;
    color:#444444
  }
  .info_live{
    margin-left: 3%;
    font-weight:normal;
    font-size: 21px;
    font-style: italic;
    color:#444444
  }
  .Minfo_pff{
    margin-top: 4%;
    margin-left: 7%;
    font-weight:500;
    font-size: 16px;


  }

</style>
