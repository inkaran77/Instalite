import DashboardLayout from '@/pages/Layout/DashboardLayout.vue'


import UserProfile from '@/pages/UserProfile.vue'
import Typography from '@/pages/Typography.vue'
import Notifications from '@/pages/Notifications.vue'
import NewsFeed from '@/pages/NewsFeed.vue'
import Followers from '@/pages/Followers.vue'
import Following from '@/pages/Following.vue'
import Post from '@/pages/Post.vue'
import Myphoto from '@/pages/Myphoto.vue'

const routes = [
  {
    path: '/',
    component: DashboardLayout,
    redirect: '/newsfeed',
    children: [

      {
        path: 'user',
        name: 'Mon Profil',
        component: UserProfile
      },

      {
        path: 'typography',
        name: 'Typography',
        component: Typography
      },
      {
        path: 'newsfeed',
        name: 'Fil d actualité',
        component: NewsFeed
      },
      {
        path: 'followers',
        name: 'Mes Abonnés',
        component: Followers
      },
      {
        path: 'following',
        name: 'Mes Abonnemments',
        component: Following
      },
      {
        path: 'post',
        name: 'Poster',
        component: Post
      },
      {
        path: 'myphoto',
        name: 'Myphoto',
        component: Myphoto
      },


      {
        path: 'notifications',
        name: 'Notifications',
        component: Notifications
      }
    ]
  }
]

export default routes
