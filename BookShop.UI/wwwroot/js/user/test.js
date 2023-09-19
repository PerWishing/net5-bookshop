const app = Vue.createApp({
    data() {
        return {
            message: 'Hello0000 Vue 3!',
            c: 0
        }
    },
    mounted() {
        this.alert();
    },
    methods: {
        setMessage(event) {
            this.message = event.target.value;
        },
        alert() {
            alert(this.c);
        }
    }
});
app.mount('#app');