<template>
  <div>
    <div class="registre">
      <div class="barre"></div><div class="barre" ></div><div class="barre" style="background-color:#A4A4A4;"></div>
      <input type="text" name="name" placeholder="Nom">
      <input type="text" name="frist-name" placeholder="Prenom">
      <input style="height: 30px; width:180px;"type="date" name="birth-date" placeholder="Date de naissance">
      <div>
      <select id="sexe">
    <option value="" name="sexe">Sexe</option>
        <option value="F" name="sexe">Femme</option>
        <option value="H" name="sexe">Homme</option>
        </select><br>
      </div>
      <input type="text" name="country" placeholder="Pays">
      <input type="text" name="city" placeholder="Ville">
    </div>
    <div class="registre" style="margin-top: 0;">
    <button class="btn-danger btn-reg">Retour</button>
    <button class="btn-primary btn-reg">Suivant</button>
      </div>
  </div>

  </template>
<style>
.main{
	display: flex;
	justify-content: center;
}
.main2{
	border-style: solid;
	border-width: 1px;
	border-color: black;
	min-height: 450px;
	max-height: auto;
	width: 500px;
	position: relative;
	top: 60px;
}
.container-img{
	position: absolute;
	left: calc(50% - 90px);
	top : -80px;
}
.registre{
	margin-top: 100px;
	display: flex;
	justify-content: center;
	flex-wrap: wrap;
	flex-direction: row;
}
input{
		margin-left: 10px;
		margin-top: 10px;
		margin-right: 10px;
	}
	.homme{
		display: block;
		width: 5px;
		height: 10px;
		background-color: red;
	}
	#sexe{
		width:180px;
		height: 30px;
		margin-top: 10px;

		margin-left: 10px;
		margin-right: 10px;
	}
  .btn-reg{
    margin-bottom: 20px;
     margin-top: 20px;
     margin-left: 10px;
     margin-right: 10px;
  }
.barre{
  display: block;
  width: 20%;
  height: 1px;
  background-color: #2E9AFE;
  margin-left: 5px;
}

</style>
