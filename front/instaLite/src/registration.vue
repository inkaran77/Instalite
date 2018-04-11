<template>
  <body class="body page-index clearfix">
    <button id="bn-connexion" class="_button">Connexion</button>
    <input id="password" class="_input _input-1" name="password" placeholder="Mo de passe" type="text">
    <input id="login" class="_input _input-2" name="login" placeholder="Login" type="text">
    <div class="container">
      <div class="element"></div>
    </div>
    <div class="element element-2"></div>
  </body>

</template>

<script>
export default {

  name: 'app',
  data () {
    return {

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

.container {
  position: absolute;
  top: 16px;
  right: 740px;
  z-index: 2;
  width: 114px;
  height: 106px;
}

.container .element {
  top: -15px;
  z-index: 1;
  width: 129px;
  height: 138px;
  background: url('./assets/icon.png') rgba(222, 222, 222, 0);
  background-size: cover;
  background-position: left top;
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
  top: 376px;
  left: 0;
  right: 0;
  z-index: 5;
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
  width: 163px;
  height: 34px;
  margin: 0 auto;
  padding: 10px;
  border-radius: 5px;
  background-color: rgb(242, 242, 242);
  font-size: 0.813em;
  text-align: center;
  color: rgb(0, 0, 0);
}

.element-2 {
  top: 50px;
  width: 435px;
  min-width: 200px;
  max-width: 435px;
  height: 489px;
  border-radius: 25px;
  background-color: rgb(255, 255, 255);
}

._input-1 {
  top: 312px;
  z-index: 4;
}

._input-2 {
  top: 264px;
  z-index: 3;
}
</style>
