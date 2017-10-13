var modalDialog = Vue.component('ModalDialog', {
    template:
    '<transition name="modal">' +
    '    <div :id="id" class="modal fade" role="dialog">' +
    '        <div class="modal-dialog" v-show="show">' +
    '           <div class="modal-content">' +
    '               <slot></slot>' +
    '           </div>' +
    '       </div>' +
    '    </div>' +
    '</transition>',
    props: ['id', 'show', 'entityId'],
    methods: {
        baseClose: function () {
            this.$emit('close');
        }
    },
    mounted: function () {
        document.addEventListener('keydown', (e) => {
            if (this.show && e.keyCode == 27) {
                this.close();
            }
        });
    }
})