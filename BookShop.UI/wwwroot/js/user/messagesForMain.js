const vueAppMessForMain = Vue.createApp({
    data() {
        return {
            messages: 0,
            src: ""
        }
    },
    mounted() {
        this.getMessages();
        
        
    },
    methods: {
        getMessages() {
            axios.get("/messages")
                .then(res => {
                    console.log(res);
                    this.messages = res.data;
                    if (this.messages == 0) {
                        document.getElementById("userIcon").src = "/images/user-icon.png";
                    }
                    else {
                        document.getElementById("userIcon").src = "/images/icon-noty.png";
                    }
                    console.log(this.messages);
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
vueAppMessForMain.mount('#appMessForMain');