﻿const app = Vue.createApp({
    data() {
        return {
            url: null,
        }
    },
    methods: {
        onFileChange(e) {
            const file = e.target.files[0];
            this.url = URL.createObjectURL(file);
        }
    }
});
app.mount('#app');

