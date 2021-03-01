import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/components/Home';
import Students from '@/components/Students';
import Instrutors from '@/components/Instrutors';

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: Home
    },
    {
      path: '/home',
      component: Home
    },
    {
      path: '/students',
      component: Students
    },
    {
      path: '/instrutors',
      component: Instrutors
    }
  ]
})
