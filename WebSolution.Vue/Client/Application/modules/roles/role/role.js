Vue.component('role', function (resolve, reject) {
    Vue.http.get('/api/application/template/' + 'role').then(
        successResponse => {
            resolve(Vue.extend({
                mixins: [modalDialog],
                template: successResponse.body,
                data: function () {
                    return {
                        entity: this.emptyEntity()
                    }
                },
                watch: {
                    show: function (value) {
                        if (value) {
                            this.loadData();
                        }
                    }
                },
                methods: {
                    emptyEntity() {
                        return {
                            Id: 0,
                            Name: '',
                            RoleType: 0
                        }
                    },
                    loadData() {
                        if (this.entityId === 0) {
                            this.entity = this.emptyEntity();
                            return;
                        }

                        this.$http.get('/api/roles/' + this.entityId).then(
                            successResponse => {
                                this.entity = successResponse.body;
                            },
                            errorResponse => {
                                // load data error callback
                            });
                    },
                    close: function () {
                        this.baseClose();
                    },
                    save: function () {
                        this.$http.post('/api/roles/' + this.entityId, this.entity).then(
                            successResponse => {
                                this.close();
                            },
                            errorResponse => {
                                // save error callback
                            });
                    }
                }
            }),
        errorResponse => {
            // resolve template error callback
        })
    })
})