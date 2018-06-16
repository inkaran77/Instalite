
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


              <!-- list of all users -->
              <li class="users-id" v-for="(user, index) in userslist">
                <div class="Picture">
                  <avatar :image='user.UrlPhoto' :size ="100"></avatar>
                </div>

                 <div class="profile_name" >
                   <a v-on:click="getUserInfo(user.UrlPhoto)" href="#" style="color:#000000"><h3>{{user | fullNAme}}</h3></a>
                 </div>

                <div class="drop_container">
                  <div class="dropdown1">
                    <button class="buttonload" v-on:click="follow(user.UserId)">
                        Follow
                    </button>
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
      userslist:null,
      urlphoto :'',
      UserId:''

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
       this.$http.put('http://localhost:5000/Instalite/Follow',"",{
        params:{UserId : this.UserId}
      ,headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }}).then(response =>{
        this.userslist.slice(index, 1)
        console.log(response.status)
        })
    },

    getUserInfo(urlphoto){

      this.urlphoto = urlphoto

      this.$http.get('http://localhost:5000/Instalite/GetUserProfile',{ params:{ UrlPhoto : this.urlphoto }
        ,
        headers: {'Authorization': 'Bearer '+ this.$cookies.get("token")}
        }).then(response =>{

        console.log(response.data)
      })
    }

      },

mounted:function(){

        this.$http.get('http://localhost:5000/Instalite/GetAvailableUsers',{ headers: {
          'Authorization': 'Bearer '+ this.$cookies.get("token")
        }
        }).then(response=> {

       this.userslist = response.data.ListUsers
        console.log(response.data)
  });



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
    margin-bottom: 1%;
    color:black;
    width: 76%;
    margin:0;
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


</style>
