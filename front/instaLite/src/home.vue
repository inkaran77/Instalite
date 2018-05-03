<template>
  <body>

       	<div class="menu">

            <div class="flexend">

            </div>
            <div class="flexend">
                 <button class=" btn btn-danger">Déconnexion</button>
            </div>

            </div>

            <div class="milieu">
            <img class="logo"src="./assets/icon.png">
            </div>

            <div id="profil">
                 <div class="containers">


                 </div>

                 <div class="container-profil">
                      <img class="photo2" src="profil2.png">
                      <div class="container-name">
                           <h2>Nom</h2><h2>Prenom</h2>
                      </div>
                      <div class="container-name">
                           <div class="box-follow">
                                <h5>Abonnée</h5><h5>500</h5>

                           </div>
                           <div class="box-follow ">
                                <h5>Abos</h5><h5>500</h5>
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
   position: fixed;
display: block;
height: 100%;
width: 350px;
background-color: rgb(7, 42, 71);



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
     background-color: rgb(7, 42, 71);
     border-color: rgb(7, 42, 71);
     border: 0;
     font-family: arial;
     color: white;
}
.btn-compte:hover{
  background-color: #FFFF;
  color:black;
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
