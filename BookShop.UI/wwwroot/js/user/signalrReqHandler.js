var connection = new signalR.HubConnectionBuilder()
    .withUrl("/User/CreateMessage")
    .build();

connection.on('receiveMessage', getMessages);

connection.start()
    .catch(error => {
        console.error(error.message);
    });

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message)
}
connection.start();