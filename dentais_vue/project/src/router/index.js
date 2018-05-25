import Vue from 'vue'
import Router from 'vue-router'
import Axios from 'axios'
import Home from '@/pages/Home'
import Categoria from '@/pages/Categoria'
import Produto from '@/pages/Produto'
import Pesquisa from '@/pages/Pesquisa'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/categoria/:id',
      name: 'Categoria',
      component: Categoria
    },
    {
      path: '/produto/:id',
      name: 'Produto',
      component: Produto
    },
    {
      path: '/pesquisa/:algo',
      name: 'Pesquisa',
      component: Pesquisa
    }
  ]
})
