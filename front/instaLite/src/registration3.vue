<!-- la dernier page d'inscription -->
<template>
    <div>
    <div class="registre3">
      <div>
      <picture-input
        ref="pictureInput"
        @change="onChanged"
        width="200"
        height="300"
        margin="16"
        accept="image/jpeg,image/png"
        size="10"
        buttonClass="btn"
        :customStrings="{
          upload: '<h1>Bummer!</h1>',
          drag: 'Drag and Drop ou cliquer ici pour selectionner un fichier'
        }">
      </picture-input>
    </div>
    <div class="barre"></div><div class="barre" ></div><div class="barre"></div>

    <input style="margin-left: 200px; margin-right: 200px;" type="text" placeholder="kevin">
    <div class="registre3" style="margin-top: 0;">
    <button class="btn-danger btn-reg">Retour</button>
    <button class="btn-primary btn-reg">Suivant</button>
      </div>
  </div>

</div>
  </template>
  <script>
  import PictureInput from 'vue-picture-input'
  export default{
    components: {
        PictureInput
      },

  }
  </script>
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
.registre3{
	margin-top: 100px;
	display: flex;
	justify-content: center;
	flex-wrap: wrap;
	flex-direction: row;
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
