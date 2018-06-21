<template>
  <div class="sidebar" :data-color="activeColor" :data-image="backgroundImage" :style="sidebarStyle">
    <div class="logo">
      <a v-on:click="profil()" class="simple-text logo-mini">

  <avatar  :image="this.urlProfil" :size ="75"></avatar>
      </a>

      <h2  target="_blank" class="simple-text logo-normal">
        {{title}}
      </h2>
    </div>
    <div class="sidebar-wrapper">
      <slot name="content"></slot>
      <md-list class="nav">
        <!--By default vue-router adds an active class to each route link. This way the links are colored when clicked-->
        <slot>
          <sidebar-link v-for="(link,index) in sidebarLinks"
                        :key="link.name + index"
                        :to="link.path"
                        :link="link">
          </sidebar-link>
        </slot>
      </md-list>
    </div>
  </div>
</template>
<script>
import SidebarLink from './SidebarLink.vue'
import MobileMenu from '@/pages/Layout/MobileMenu.vue'
import Avatar from 'vue-avatar-component'
export default{
  components: {
    SidebarLink,
    MobileMenu,
    Avatar
  },
  props: {
    title: {
      type: String,
      default: 'Instalite'
    },
    backgroundImage: {
      type: String,
      default: require('@/assets/img/sidebar-2.jpg')
    },
    imgLogo: {
      type: String,
      default: require('@/assets/img/vue-logo.png')
    },
    activeColor: {
      type: String,
      default: 'blue',

    },
    sidebarLinks: {
      type: Array,
      default: () => []
    },
    autoClose: {
      type: Boolean,
      default: true
    }
  },
  data () {
    return {

            profile:JSON.parse(localStorage.getItem('user2'))
    }
  },

  provide () {
    return {
      autoClose: this.autoClose
    }
  },
  methods:{
    profil:function(){
      this.$router.push({
          name: 'Mon Profil'
      });
    }
  },
  computed: {
    sidebarStyle () {
      return {
        backgroundImage: `url(${this.backgroundImage})`
      }
    },
    urlProfil: function() {
      if(this.profile==null){return "http://res.cloudinary.com/dvejva95o/image/upload/v1529156655/icon.png"}
        return this.profile.UrlPhoto
      },
  }
}
</script>
<style>
  @media screen and (min-width: 991px) {
    .nav-mobile-menu{
      display: none;
    }

  }


</style>
