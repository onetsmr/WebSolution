Vue.component('modules', function (resolve, reject) {
    Vue.http.get('/api/application/template/' + 'modules').then(
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
                        this.$http.get('/api/application/modules').then(response => {
                            this.items = response.body;
                        }, response => {
                            // error callback
                        });
                    }
                }
            })
        },
        response => {
            // resolve template error callback
        })
})