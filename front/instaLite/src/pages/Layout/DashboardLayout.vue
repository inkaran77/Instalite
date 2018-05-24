<template>
  <div class="wrapper">
    <notifications></notifications>

    <side-bar>
      <mobile-menu slot="content"></mobile-menu>
      <sidebar-link to="/newsfeed">
        <md-icon>bubble_chart</md-icon>
        <p>Fil d'actualité</p>
      </sidebar-link>
      <sidebar-link to="/user">
        <md-icon>person</md-icon>
        <p>Mon Profil</p>
      </sidebar-link>
      <sidebar-link to="/myphoto">
        <md-icon>person</md-icon>
        <p>Mes Photos</p>
      </sidebar-link>
      <sidebar-link to="/post">
        <md-icon>content_paste</md-icon>
        <p>Poster</p>
      </sidebar-link>
      <sidebar-link to="/followers">
        <md-icon>content_paste</md-icon>
        <p>Mes abonnés</p>
      </sidebar-link>
      <sidebar-link to="/following">
        <md-icon>library_books</md-icon>
        <p>Mes abonnements</p>
      </sidebar-link>


      <sidebar-link to="/notifications">
        <md-icon>notifications</md-icon>
        <p>Notifications</p>
      </sidebar-link>
    </side-bar>

    <div class="main-panel">
      <top-navbar></top-navbar>

      <dashboard-content>

      </dashboard-content>

      <content-footer v-if="!$route.meta.hideFooter"></content-footer>
    </div>
  </div>
</template>
<style lang="scss">

</style>
<script>
import TopNavbar from './TopNavbar.vue'
import ContentFooter from './ContentFooter.vue'
import DashboardContent from './Content.vue'
import MobileMenu from '@/pages/Layout/MobileMenu.vue'

export default {
  components: {
    TopNavbar,
    DashboardContent,
    ContentFooter,
    MobileMenu
  }
}
</script>
