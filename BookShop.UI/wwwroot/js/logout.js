const vueApp = Vue.createApp({
    data() {
        return {
            
            }
        },

    methods: {
        logout() {
            this.loading = true;
            axios.get("/account")
                .then(res => {
                    console.log(res);
                    
                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
       } 
    
});
vueApp.mount('#appLogout');