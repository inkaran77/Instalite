<template>
  <body>

       	<div class="menu">
                 <button onclick="profilbar()" class="btn-profil">Menu</button>
            <div class="flexend">

            </div>
            <div class="flexend">
                 <input type="text" name="Recherche">
            </div>

            </div>

            <div class="milieu">
            <img class="logo"src="./assets/icon.png">
            </div>

            <div id="profil">
                 <div class="containers">
                 <h1>Mon Compte</h1>

                 </div>

                 <div class="container-profil">
                      <img class="photo2" src="profil2.png">
                      <div class="container-name">
                           <h2>Nom</h2><h2>Prenom</h2>
                      </div>
                      <div class="container-name">
                           <div class="box-follow">
                                <h3>Abonnée</h3><h3>500</h3>

                           </div>
                           <div class="box-follow ">
                                <h3>Abos</h3><h3>500</h3>
                           </div>
                      </div>
                      <button class="btn-compte">Photo</button>
                      <button class="btn-compte">Modifier mon compte</button>
                 <div class="end">
                      <button class="btn-compte">Deconnecter</button>
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

    }
  },
  methods: {

  },

}

</script>
<style>
body{
     margin: auto;
}

.milieu {
display: flex;
justify-content: center;

}
.menu {
     position:fixed;
     margin: none;
     display: block;
     height: 60px;
     background-color: #00A7E0;
     width: 100%;
     display: flex;
     flex-direction: row;

}

h1 {
     font-family: arial;
     color : white;
     position: relative;
     left: 20px;

}
h3 {
     margin-left: 5px;
     font-family: arial;
}

.logo{
     min-width: 100px;
     min-height: 100px;
     max-width: 200px;
     max-height: 200px;
     position: fixed;
     top: -5px;
     margin-left: 1px;
     margin-top: -23px;

}
.btn-profil{
     display: block;
     width: 10%;
     height: 60px;
     background-color: #00A7E0;
     border-color: #00A7E0;
     font-size: 25px;
     color: white;
     min-width: 165px;
}
.btn-profil:hover{
     background-color: #006e93;
}
#droite {
     display: block;
     height: 2px;
     width: 100%;
     background-color: white;
     position: relative;
     top: -10px;
}
.containers{
     display: flex;
     flex-direction: row;
}
 #profil{
display: block;
height: 100%;
width: 350px;
background-color: #4E4E4E;
position: relative;
right: 350px;
display: flex;
align-items: center;


 }
 .flexend{
     width: 90%;
     display: flex;
     justify-content:  flex-end;
 }
button {
     display: block;
     height: 50px;
     width: 100px;
}
.container-profil{
     width: 100%;
     display: flex;
     align-items: center;
     flex-direction: column;

}
h2 {
     margin-left: 20px;
     color: white;
     font-family: arial;
}
.photo2{
     height: 200px;
     width: 200px;
     background-color: white;
     border-radius: 100px;
     margin-top: 20px;


}
.container-name{
     width: 100%;
     display: flex;
     align-items: center;
     justify-content: center;
     flex-direction: row;
}

.box-follow{
     display: block;
     width: 137px;
     height: 30px;
     margin-bottom: 10px;
     border-radius: 10px;
     border-width : 20px;
     border-color: white;
     background-color: white;
     margin-left: 20px;
     display: flex;
     align-items: center;
     justify-content: center;
     flex-direction: row;
}
.btn-compte{
     display: block;
     width: 100%;
     height: 40px;
     background-color: #4E4E4E;
     font-size: 20px;
     font-family: arial;
     color: white;
}
.end {
     height: 390px;
     width: 100%;
     display: flex;
     align-items: flex-end;
     justify-content: flex-end;

}
.main{
     width: 100%;
     height: 100%;
     background-color: red;

}
</style>
