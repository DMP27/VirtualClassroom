"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



//let input = document.querySelector(".messageInput");
//let button = document.querySelector(".sendButton");

//button.disabled = true;

//input.addEventListener("change", stateHandle);

//function stateHandle() {
//    if (document.querySelector(".messageInput").value === "") {
//        button.disabled = true;
//    } else {
//        button.disabled = false;
//    }
//}





//if (document.getElementById('messageInput').value === "") {
//    //document.getElementById('sendButton').disabled = true;
//    document.getElementById('sendButton').setAttribute("disabled", "disabled");
//} else {
//    //document.getElementById('sendButton').disabled = false;
//    document.getElementById('sendButton').removeAttribute("disabled");
//    //Disable send button until connection is established
//    //document.getElementById("sendButton").disabled = true;

//    connection.on("ReceiveMessage", function (user, message) {
//        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
//        var encodedMsg = user + " says " + msg;
//        var li = document.createElement("li");
//        li.textContent = encodedMsg;
//        document.getElementById("messagesList").appendChild(li);
//        document.getElementById('messageInput').value = '';
//    });

//    connection.start().then(function () {
//        document.getElementById("sendButton").disabled = false;
//    }).catch(function (err) {
//        return console.error(err.toString());
//    });

//    document.getElementById("sendButton").addEventListener("click", function (event) {
//        var user = document.getElementById("userInput").value;
//        var message = document.getElementById("messageInput").value;
//        connection.invoke("SendMessage", user, message).catch(function (err) {
//            return console.error(err.toString());
//        });
//        event.preventDefault();
//    });
//}




//if (someCondition == true) {
//    document.getElementById('btn1').setAttribute("disabled", "disabled");
//} else {
//    document.getElementById('btn1').removeAttribute("disabled");
//}







//"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();



////if (document.getElementById("messageInput").value === "") {
////    document.getElementById('sendButton').disabled = true;
////} else {
////    document.getElementById('sendButton').disabled = false;
////}

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;


var audio = new Audio('https://soundspunos.com/uploads/files/2019-01/1547561419_note.mp3');
var audio2 = new Audio('https://media1.vocaroo.com/mp3/1gX15OincmOo');
var audio3 = new Audio('https://notificationsounds.com/storage/sounds/file-sounds-1151-swiftly.mp3');
var aux = document.getElementById("messagesList").lastChild;
var user1 = userInput.value;

connection.on("ReceiveMessage", function (user, message) {
    //if (document.getElementById('messageInput').value != "" ) {
    //    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //    var encodedMsg = user + " says " + msg;
    //    var li = document.createElement("li");
    //    li.textContent = encodedMsg;
    //    document.getElementById("messagesList").appendChild(li);
    //    if (document.getElementById("messagesList").lastChild != aux && user1 != user) {
    //        audio.play()
    //    }
    //    if (document.getElementById("messagesList").lastChild != aux && user1 == user) {
    //        audio2.play()
    //    }
    //    //document.getElementById('messageInput').value = '';

    //}
    //else {

    //    audio3.play()



    //}


    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
    if (document.getElementById("messagesList").lastChild != aux && user1 != user) {
        audio.play()
    }
    if (document.getElementById("messagesList").lastChild != aux && user1 == user) {
        audio2.play()
    }
    if ( user1 == user) {
        document.getElementById('messageInput').value = '';
    }



    
    //if (document.getElementById('messageInput').value == "" && user1 == user) {
    //    audio3.play()

    //} 
    //else {
      


    //        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //        var encodedMsg = user + " says " + msg;
    //        var li = document.createElement("li");
    //        li.textContent = encodedMsg;
    //        document.getElementById("messagesList").appendChild(li);
    //        if (document.getElementById("messagesList").lastChild != aux && user1 != user) {
    //            audio.play()
    //        }
    //        if (document.getElementById("messagesList").lastChild != aux && user1 == user) {
    //            audio2.play()
    //        }
    //        document.getElementById('messageInput').value = '';
        

    //}
    

    
    //    //document.getElementById('sendButton').disabled = true;
    //    //button.disabled = true;
    //} else {
    //    //document.getElementById('sendButton').disabled = false;
    //    //button.disabled = false;
    //    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //    var encodedMsg = user + " says " + msg;
    //    var li = document.createElement("li");
    //    li.textContent = encodedMsg;
    //    document.getElementById("messagesList").appendChild(li);
    //    document.getElementById('messageInput').value = '';
    //    audio.play()
    //}
 
        ////document.getElementById('sendButton').disabled = false;
        ////button.disabled = false;
    //    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //    var encodedMsg = user + " says " + msg;
    //    var li = document.createElement("li");
    //    li.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(li);
    //if (document.getElementById("messagesList").lastChild != aux && user1 != user) {
    //    audio.play()
    //}
    //if (document.getElementById("messagesList").lastChild != aux && user1 == user) {
    //    audio2.play()
    //}
    //    document.getElementById('messageInput').value = '';
 
   

});

connection.start().then(function () {
    
        document.getElementById("sendButton").disabled = false;
    
   
    
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {

    if (document.getElementById('messageInput').value != "") {
        var user = document.getElementById("userInput").value;
        var message = document.getElementById("messageInput").value;
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    }


});
 
