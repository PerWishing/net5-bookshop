const vueApp = Vue.createApp({
    data() {
        return {
            userModel: {
                username: "",
                password: "",
                email:""
            }
        }
    },
    mounted() {
        //TODO: get all users
    },
    methods: {
        createUser() {
            this.loading = true;
            axios.post("/users", this.userModel)
                .then(res => {
                    console.log(res);
                })
                .catch(err => {
                    console.error(err);
                });
        }
    }
});
vueApp.mount('#app');