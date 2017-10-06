const routes = [
    { path: '/', component: Vue.component('dashboard') },
    { path: '/Roles', component: Vue.component('roles') },
    { path: '/Users', component: Vue.component('users') }
]

const router = new VueRouter({
    routes: routes
})