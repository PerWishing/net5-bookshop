const vueApp = Vue.createApp({
    data() {
        return {
            editingRecForCustomer: false,
            editingCanForCustomer: false,
            cancelingOrderForSeller: false
        }
    },
    mounted() {

    },
    methods: {

        receiveProductForCustomer() {
            this.editingRecForCustomer = true;
        },
        cancelRecForCustomer() {
            this.editingRecForCustomer = false;
        },

        cancelProductForCustomer() {
            this.editingCanForCustomer = true;
        },
        cancelCanForCustomer() {
            this.editingCanForCustomer = false;
        },


         setTrueCancelingOrderForSeller() {
             this.cancelingOrderForSeller = true;
        },
         setFalseCancelingOrderForSeller() {
             this.cancelingOrderForSeller = false;
        }

    },
    computed: {
    }
});
vueApp.mount('#appOrd');