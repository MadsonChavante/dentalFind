import Vue from 'vue'
import Router from 'vue-router'
import Axios from 'axios'
import Home from '@/pages/Home'
import Categorias from '@/pages/Categorias'
import Produto from '@/pages/Produto'

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
    },
    {
      path: '/produto/:id',
      name: 'Produto',
      component: Produto
    }
  ]
})
