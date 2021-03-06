import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/Home.vue'
import Login from '../components/Login.vue'
import Logout from '../components/Logout.vue'
import Register from '../components/Register.vue'
import store from '../store/index'
import ForumSearch from '../components/ForumSearch.vue'
import PlaydatePage from '../components/PlaydatePage.vue'
import Profile from '@/components/Profile.vue'
import CreateProfile from '@/components/CreateProfile.vue'
import PetRegistration from '@/components/PetRegistration.vue'
import ForumMessage from '@/components/ForumMessage.vue'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/forum",
      name: "forum-search",
      component: ForumSearch,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/playdate",
      name: "playdate",
      component: PlaydatePage,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/profile",
      name: "profile",
      component: Profile,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/createprofile",
      name: "create-profile",
      component: CreateProfile,
      meta: {
        requiresAuth: false
      }
    },
{
  path: "/petregistration",
  name: "pet-registration",
  component: PetRegistration, 
  meta: {
    requiresAuth: false
  }
},
    {
      path: "/message/:messageID",
      name: "forum-message",
      component: ForumMessage,
      meta: {
        requiresAuth: false
      }

    }

  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
