import Vue from 'vue'
import Router from 'vue-router'
import Axios from 'axios'
import Home from '@/pages/Home'
import Categorias from '@/pages/Categorias'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/cat',
      name: 'Categorias',
      component: Categorias
    }
  ]
})
