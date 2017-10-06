Vue.component('dashboard', function (resolve, reject) {
    Vue.http.get('/api/application/template/' + 'dashboard').then(
        response => {
            resolve({
                template: response.body
            })
        },
        response => {
            // resolve template error callback
        })
})