const vueAppMess = Vue.createApp({
    data() {
        return {
            editing: false,
            messages: [],
            messageModel: {
                id: 0,
                text: "",
                status: 0
            },
            messageModelLast: {
                sender: "",
                status: 0
            },
            userModel: {
               
            },
            userName:""
        }
    },
    mounted() {
        userName = document.getElementById('name').value;
        console.log(userName);
        this.messageModelLast.status = 1;
        this.messageModelLast.sender = userName;
       
        this.updateMessageStatus();
        this.getMessages();
        document.getElementById("userIcon").src = "/images/user-icon.png";
        this.scrollToBottom();
        
    },
    methods: {
        getMessages() {
            axios.get("/messages/" + userName)
                .then(res => {
                    console.log(res);
                    
                    this.messages = res.data;
                    this.userName = document.getElementById('name').value;
                    this.messages.forEach(function (element) {
                        if (element.avatar != null) {
                            let a = "data:image/jpeg;base64," + element.avatar;
                            element.avatar = a;
                        }
                    });
                    this.scrollToBottom();
                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                });
        },
        createMessage() {
            axios.post("/messages/" + userName, this.messageModel)
                .then(res => {
                    console.log(res.data);
                    var message = "update page";
                    sendMessageToHub(message, userName);
                    this.getMessages();
                })
                .catch(err => {
                    console.error(err);
                    console.error(res.data);
                })
                .then(() => {

                });
        },
        updateMessageStatus() {
            axios.put("/messages/", this.messageModelLast)
                .then(res => {
                    console.log(res);

                })
                .catch(err => {
                    console.error(err);
                })
                .then(() => {
                });
        },
        
        formatDate(dateString) {
            const date = new Date(dateString);
            // Then specify how you want your dates to be formatted
            return new Intl.DateTimeFormat('default', { dateStyle: 'short' }).format(date);
        },
        deleteProduct() {
        },
        cancel() {
        },
        scrollToBottom() {
            const container = this.$el.querySelector("#messageBody");
            container.scrollTop = container.scrollHeight;
        }
    },
    computed: {
    }
});
vueAppMess.mount('#appMess');