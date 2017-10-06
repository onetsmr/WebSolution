Vue.component('Users', function (resolve, reject) {
    Vue.http.get('/api/application/template/' + 'users').then(
        response => {
            resolve({
                template: response.body,
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
                        this.$http.get('/api/users').then(response => {
                            this.items = response.body;
                        }, response => {
                            // load data error callback
                        });
                    }
                }
            })
        },
        response => {
            // resolve template error callback
        })
})