const vueAppMessForLay = Vue.createApp({
    data() {
        return {
            messages: 0
        }
    },
    mounted() {
        this.getMessages();
        console.log(this.messages);
    },
    methods: {
        getMessages() {
            axios.get("/messages")
                .then(res => {
                    console.log(res);
                    this.messages = res.data;
                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                });
        },
        
    },
    computed: {
    }
});
vueAppMessForLay.mount('#appMessForLay');