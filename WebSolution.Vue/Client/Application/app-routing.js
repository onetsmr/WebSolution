const routes = [
    { path: '/', component: Vue.component('Dashboard') },
    { path: '/Roles', component: Vue.component('Roles') },
    { path: '/Users', component: Vue.component('Users') }
]

const router = new VueRouter({
    routes: routes
})