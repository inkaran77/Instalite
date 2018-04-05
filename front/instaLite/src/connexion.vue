<template>
  <body class="body page-index clearfix">
    <input v-on:keyup.enter="connexion()" ref="password" id="password" class="_input _input-1" name="password" placeholder="Mot de passe" type="password">
    <input id="login" class="_input _input-2" ref="login" name="login" placeholder="Login" type="text">
    <div class="element element-1"></div>
    <div class="element element-2"></div>
    <button v-on:click="connexion()" id="bn-connexion" class="_button">Connexion</button>
    <a href=""
  </body>

</template>

<script>
export default {
  name: 'app',
  data () {
    return {
      login: '',
      password:''
    }
  },

  methods:{
    connexion:function(){
      this.login=this.$refs.login.value
      this.password=this.$refs.password.value
      
      this.$http.post('http://localhost:5001/api/values',{
        login:this.login,
        password:this.password
      }).then(function(data){
          console.log(data);
    })
          }


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

.element {
  position: absolute;
  left: 0;
  right: 0;
  margin: 0 auto;
}

._button {
  display: block;
  position: absolute;
  top: 360px;
  left: 0;
  right: 0;
  z-index: 4;
  width: 144px;
  height: 38px;
  margin: 0 auto;
  border-radius: 25px;
  background-color: rgb(7, 42, 71);
  font-size: 1em;
  text-align: center;
  color: rgb(255, 255, 255);
}

._button:hover {
  background-color: rgb(121, 159, 191);
}

._input {
  display: block;
  position: absolute;
  left: 0;
  right: 0;
  width: 167px;
  height: 15px;
  margin: 0 auto;
  padding: 10px;
  border-radius: 5px;
  background-color: rgb(242, 242, 242);
  font-size: 0.813em;
  text-align: center;
  color: rgb(0, 0, 0);
}

.element-1 {
  top: 104px;
  z-index: 1;
  width: 129px;
  height: 138px;
  background: url('./assets/icon.png') rgba(222, 222, 222, 0);
  background-size: cover;
  background-position: left top;
}

.element-2 {
  top: 50px;
  width: 435px;
  height: 489px;
  border-radius: 25px;
  background-color: rgb(255, 255, 255);
}

._input-1 {
  top: 300px;
  z-index: 3;
}

._input-2 {
  top: 240px;
  z-index: 2;
}
</style>
