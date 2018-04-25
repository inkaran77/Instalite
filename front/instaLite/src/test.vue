<template>
<body class="body">
      <div class="row container center">
          <div class="">
              <div class="form-login ">
              <h4>Bienvenu</h4>
              <input type="text" id="userName" class="form-control input-sm chat-input" placeholder="username" />
              </br>
              <input type="text" id="userPassword" class="form-control input-sm chat-input" placeholder="password" />
              </br>
              <div class="wrapper">
              <span class="group-btn">
                  <a href="#" class="btn btn-primary btn-md">login <i class="fa fa-sign-in"></i></a>
              </span>
              </div>
              </div>

          </div>
      </div>
</body>
</template>

<script>
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
export default {

  name: 'app',
  data () {
    return {
      Id: '',
      Password:''
    }
  },

  methods:{



  },
}
</script>

<style>

body {
  height: 100%;
  background: url('./assets/background.jpg')rgb(255, 255, 255);
  background-repeat: repeat, repeat;
  background-size: cover, cover;
  background-position: left top, left top;
  background-attachment: scroll, scroll;
  font: 400 1em/1.38 Helvetica;
  color: rgb(255, 255, 255);
}
.center{
  display:flex;
  justify-content: center;
}
.container {

    padding: 25px;
    position: fixed;
}

.form-login {
    background-color: #EDEDED;
    padding-top: 10px;
    padding-bottom: 20px;
    padding-left: 20px;
    padding-right: 20px;
    border-radius: 15px;
    border-color:#d2d2d2;
    border-width: 5px;
    box-shadow:0 1px 0 #cfcfcf;
}

h4 {
 border:0 solid #fff;
 border-bottom-width:1px;
 padding-bottom:10px;
 text-align: center;
}

.form-control {
    border-radius: 10px;
}

.wrapper {
    text-align: center;
}

</style>
