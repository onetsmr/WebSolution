Vue.component('roles', function (resolve, reject) {
    Vue.http.get('/api/application/template/' + 'roles').then(
        response => {
            resolve({
                template: response.body,
                data: function () {
                    return {
                        items: [],
                        showAddDialog: false
                    }
                },
                created() {
                    this.loadData()
                },
                methods: {
                    loadData() {
                        this.$http.get('/api/roles').then(response => {
                            this.items = response.body;
                        }, response => {
                            // load data error callback
                        });
                    },
                    openAddDialog() {
                        this.showAddDialog = true;
                    },
                    closeAddDialog() {
                        this.showAddDialog = false;
                        this.loadData();
                    },
                    openEditDialog(item) {
                        item.ShowEditDialog = true;
                    },
                    closeEditDialog(item) {
                        item.ShowEditDialog = false;
                        this.loadData();
                    },
                    remove(item) {
                        this.$http.delete('/api/roles/' + item.Id).then(response => {
                            this.loadData()
                        }, response => {
                            // remove error callback
                        });
                    }
                }
            })
        },
        response => {
            // resolve template error callback
        })
})