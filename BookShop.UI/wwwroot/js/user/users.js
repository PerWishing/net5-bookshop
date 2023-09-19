const vueApp = Vue.createApp({
    data() {
        return {
            users: [],
            indexModel: {
            userModel: {
                username: "",
                avatar:""
            },
            page:1,
            search:""
            },
            
        }
    },
    mounted() {
        this.page = 1;
        this.search = "";
        this.getUsers();
        
    },
    methods: {
        getUsers() {
            axios.get("/users/" + this.page)
                .then(res => {
                    console.log(res);
                    this.indexModel = res.data;
                    this.users = this.indexModel.usersPublic;
                    this.users.forEach(function (element) {
                        if (element.avatar != null) {
                            let a = "data:image/jpeg;base64," + element.avatar;
                            element.avatar = a;
                        }
                    });
                })
                .catch(err => {
                    console.error(err);
                    console.error(res.data);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getUsersBySearch() {
            axios.get("/users/" + this.page + "/" + this.search)
                .then(res => {
                    console.log(res);
                    this.indexModel = res.data;
                    this.users = this.indexModel.usersPublic;
                    this.users.forEach(function (element) {
                        if (element.avatar != null) {
                            let a = "data:image/jpeg;base64," + element.avatar;
                            element.avatar = a;
                        }
                    });
                })
                .catch(err => {
                    console.error(err);
                    console.error(res.data);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        incPage() {
            this.page++;
            console.log(this.page);
            this.getUsers();
        },
        decPage() {
            if (this.page !=1) {
            this.page--;
            console.log(this.page);
            this.getUsers();
            }
        },
        createUser() {
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
vueApp.mount('#usersApp');