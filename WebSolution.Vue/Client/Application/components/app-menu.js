Vue.component('app-menu', {
    template: '<ul class="nav nav-sidebar"><li v-for="item in items"><router-link v-bind:to="item.Url">{{ item.Name }}</router-link></li></ul>',
    data: function () {
        return {
            items: []
        }
    },
    created() {
        this.loadData()
    },
    methods: {
        loadData() {
            this.$http.get('/api/application/modules').then(response => {
                this.items = response.body;
            }, response => {
                // error callback
            });
        }
    }
})