
<template>
  <div class="content">
    <div class="md-layout">
      <div class="md-layout-item">
        <md-card>
          <md-card-header data-background-color="blue">
            <h4 class="title">Discovery</h4>
            <p class="category"></p>
          </md-card-header>
          <md-card-content>

             <!-- Add icon library -->
          <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

            <div id="discovery">
              <!-- search module -->

              <div class="searchfield" >
              <input type="text" v-model="search" placeholder=" Look for Users " id="s"/>
              </div>

              <!-- list of all users -->
              <div class="users-id" v-for="user in filterusers">
                <div class="UserDisplay">
                <div class="Picture">
                  <avatar :image='user.UrlPhoto' :size ="100"></avatar>
                </div>

                 <div class="profile_name" >
                   <a v-on:click="getUserInfo(user.UrlPhoto), toggle(user.UserId)" href="#" style="color:#000000"><h3>{{user | fullNAme}}</h3></a>
                  <div>
                 <transition name="fade">
                  <p class="UserInfo" v-if="UserId2==user.UserId&&show" >Posts: {{posts}} &emsp; Followers: {{followers}} &emsp; Followings : {{followings}} </p>
                 </transition>
                  </div>
                 </div>
                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload" v-on:click="follow(user.UserId)">
                        Follow
                    </button>
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
      userslist:[],
      urlphoto :'',
      UserId:'',
      followers:null,
      followings :null ,
      posts : null,
      show:false,
      UserId2 : null,
      search:''

    }
  },

  filters: {
    fullNAme(data){
      return `${data.First_Name} ${data.Last_Name}`;
    }

  },

  methods:{


    follow : function(Id){
      this.UserId = Id
       this.$http.put('http://localhost:5000/Instalite/Follow',{},{
        params:{UserId : this.UserId}
      ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{
          this.getavailableusers()
        console.log(response.status)
        })
    },

    getUserInfo(urlphoto){

      this.urlphoto = urlphoto

      this.$http.get('http://localhost:5000/Instalite/GetUserProfile',{ params:{ UrlPhoto : this.urlphoto }
        ,
        headers: {'Authorization': 'Bearer '+ this.$cookies.get("token")}
        }).then(response =>{
          this.followers = response.data.Followers.ListUsers.length
          this.followings = response.data.Followings.ListUsers.length
          this.posts = response.data.List_post.length
        console.log(response.data)
      })
    },
    getavailableusers: function(){
      this.$http.get('http://localhost:5000/Instalite/GetAvailableUsers',{ headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }
        }).then(response=> {

       this.userslist = response.data.ListUsers
        console.log(response.data)
  });
    },

    toggle : function(Id){

      this.UserId2= Id;
      this.show = !this.show;
    }

      },

    computed : {

      filterusers : function(){

        return this.userslist.filter((user)=> {

        return user.UserId.match(this.search);
        });
      }

    },

mounted:function(){

    this.getavailableusers()

      },
}
</script>
<style >
  .buttonload {
    border-radius: 5px;
    color : black;
    }
  .fa-spin {
    color : black;
    }


  .users-id{
    background:#FFFFFF;
    border-bottom:1px solid #BBBBBB;
    font-weight:bold;
    color:#FFFFFF;
    margin:auto;
    text-align: center;
    width:89%;

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
    position: relative;
    margin-left: 1%;
    margin-bottom: 1%;
    color:black;
    width: 76%;
    margin:0;
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
    transition:.5s;
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

  .fade-enter-active, .fade-leave-active {
  transition: opacity .5s;
  }
  .fade-enter, .fade-leave-to {
    opacity: 0;
  }
  .UserInfo{
    color:#333333;
    font-style:italic;
    position: absolute;
    margin-left: 0.5%
  }


/* Search styles */

#s { background: rgba(3, 175, 255, 0.7)
url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAAUCAYAAABvVQZ0AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAQBJREFUeNqslI0RgyAMhdENWIEVWMEVXIGO0BW6Ah2hHcGOoCPYEewINFzBe9IA9id37w4kfEZesHHOCSYUqSPJML+RJlELDwN1pMHxMZNMkr8RTgyz2YPH5LmtwXpIHkOFmKhIlxowDmYAycKnHAHYcTCsSpXOJCie6YWDnXKLGeHLN2stGaqDsXXrX3GFcYcLrfhjtKEhffQ792gYT2nT6pJDjCw4z7ZGdGipOIqNbXIwFUARmCbKpMfYxsWJBmCEDoW7+gYUTAU2s3HJrK3AJvMLkqGHFLgWXTckm+SfSQexs+tLRqwVfgvjgMsvMAT689S5M/sk/I14kO5PAQYAuk6L1q+EdHMAAAAASUVORK5CYII=)
no-repeat 14px 14px;
text-indent: 1em; display: inline-block; border: 0 none; width: 0; height: 3em;
border-radius: 3em; -webkit-transition: .5s; transition: .5s; outline: none; padding: 1em 1.5em; cursor: pointer;
-webkit-appearance: none; font-weight: inherit; font-size: inherit; font-family: inherit; color: #000;
vertical-align: baseline;}

input[type=search]::-webkit-search-cancel-button { -webkit-appearance: none;}

#s:hover, #s:focus { background: #fff url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABMAAAAUCAYAAABvVQZ0AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAT5JREFUeNqsVLtOw0AQtIMlRJHCEhUVMg398QEUSZnSfILzCXxDPsFu6XAJHWnTcS1lWsprKdmLxtKwvjVBYaTV7cm+udnX5fPb+yyBSmwhVmK/FfPZLyjUPhI8YtXYi23EOovs7PzyevAbsWeoGg5HNUHsCipX8F9TZDOstVgLPxIsxW6w3sHv6dJ2StkLbh6IPtR/AWRfSIET20H9D2U1hfaAgxY2KMagcBSmg9/rmwx0lBqTzGfHoVfVHxXgXzCjHNRHnnHke4vMGc2q0RBR0GSeCLlpLaJGFWKUszVuib32nih7iTFrjXAPyGnQ48c3Gu5AOVlMtMk6NZuf+FiC+AIhV0T+pBQ5ntXceIJKqKko2duJ2TwoLAz5QTVnagJaXWEO8y/wSMuKH9RTJoCTHyNZFidOUEfNu/8WYAAOXUT04MOtlwAAAABJRU5ErkJggg==)
14px 14px no-repeat;}

#s:focus { width: 25%; cursor: text; }

.searchfield {
text-align: right;
position: relative;
}

</style>
