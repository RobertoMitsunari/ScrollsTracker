import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/About',
      name: 'about',
      component: () => import('../views/MangaChat.vue')
    },
    {
      path: '/Cadastrar',
      name: 'cadastrar',
      component: () => import('../views/RegisterView.vue')
    }
  ]
})

export default router