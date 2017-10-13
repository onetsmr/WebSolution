Vue.component('role', function (resolve, reject) {
    Vue.http.get('/api/application/template/' + 'role').then(
        successResponse => {
            resolve(Vue.extend({
                mixins: [modalDialog],
                template: successResponse.body,
                data: function () {
                    return {
                        entity: {
                            Id: 0,
                            Name: ''
                        }
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
                    loadData() {
                        this.$http.get('/api/roles/' + this.entityId).then(
                            successResponse => {
                                this.entity = successResponse.body;
                            },
                            errorResponse => {

                            });
                    },
                    close: function () {
                        this.baseClose();
                    },
                    save: function () {
                        this.$http.post('/api/roles/' + this.entityId, this.entity).then(
                            successResponse => {
                                
                            },
                            errorResponse => {

                            });

                        this.close();
                    }
                }
            }),
        errorResponse => {

        })
    })
})