const vueApp = Vue.createApp({
    data() {
        return {
            editing: false,
            
        }
    },
    mounted() {
        
    },
    methods: {
       
        deleteProduct() {
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        }
    },
    computed: {
    }
});
vueApp.mount('#appP');