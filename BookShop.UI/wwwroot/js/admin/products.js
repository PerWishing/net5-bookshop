const vueApp = Vue.createApp({
    data() {
        return {
            editing: false,
            loading: false,
            objectIndex: 0,
            products: [],
            productModel: {
                id: 0,
                name: "Product Name",
                description: "Product Description",
                value: 1.99
            }
        }
    },
    mounted() {
        this.getProducts();
    },
    methods: {

        getProduct(id) {
            this.loading = true;
            axios.get("/products/" + id)
                .then(res => {
                    console.log(res);
                    var product = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        description: product.description,
                        value: product.value
                    };
                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getProducts() {
            this.loading = true;
            axios.get("/products")
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        createProduct(event) {
            if (event) {

                this.loading = true;
                axios.post("/products", this.productModel)
                    .then(res => {
                        console.log(res.data);
                        this.products.push(res.data);
                    })
                    .catch(err => {
                        console.error(err);
                    })
                    .then(() => {
                        this.loading = false;
                        this.editing = false;
                    });
            }
        },
        updateProduct(event) {
            if (event) {

                this.loading = true;
                axios.put("/products", this.productModel)
                    .then(res => {
                        console.log(res.data);
                        this.products.splice(this.objectIndex, 1, res.data);
                    })
                    .catch(err => {
                        console.error(err);
                    })
                    .then(() => {
                        this.loading = false;
                        this.editing = false;
                    });
            }
        },
        deleteProduct(id, index) {
            this.loading = true;
            axios.delete("/products/" + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1);
                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0;
        },
        editProduct(id, index) {
            this.objectIndex = index;
            this.getProduct(id);
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        }
    },
    computed: {
    }
});
vueApp.mount('#app');