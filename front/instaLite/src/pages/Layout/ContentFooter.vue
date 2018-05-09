<template>
  <footer class="footer">
    <div class="container">
        <nav>
            <ul>
              <li>
                <router-link :to="{path:'/icons'}">Home</router-link>
              </li>

            </ul>
        </nav>
        <div class="copyright text-center">
          &copy; {{ new Date().getFullYear() }} <a >Instalite</a>, partager vos photos <i class="fa fa-heart heart"></i>
        </div>
    </div>
  </footer>

</template>
<script>
export default {}

</script>
<style>

</style>
