﻿Vue.component('Dashboard', {
    template: '<div>Dashboard</div>'
})

Vue.component('Roles', {
    template: '<div>Roles</div>'
})

Vue.component('Users', {
    template: '<div>Users</div>'
})

const routes = [
    { path: '/', component: Vue.component('Dashboard') },
    { path: '/Roles', component: Vue.component('Roles') },
    { path: '/Users', component: Vue.component('Users') }
]

const router = new VueRouter({
    routes: routes
})