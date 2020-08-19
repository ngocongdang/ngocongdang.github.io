function addProduct() {
     var fullName = document.getElementById("fullName").value;
     var userName = document.getElementById("userName").value;
     var passWord = document.getElementById("passWord").value;
     var rePassword = document.getElementById("reinput-passWord").value;
     var email = document.getElementById("email-register").value;
     var phone = document.getElementById("phone-register").value;
     var message_TK = document.getElementById("message-TK");
     var message_phone = document.getElementById("message-phone");
     var message_email = document.getElementById("message-email");
     var at = email.indexOf("@");
     var dot = email.indexOf(".");
     alert(fullName + " " + userName + " " + passWord + " " + rePassword + " " + phone + " " + email);
     if (fullName == "" || userName == "" || passWord == "" || rePassword == "") {
          message_TK.innerHTML = "Hãy nhập thông tin phía trên để tiếp tục!";
          return false;
     } else if (passWord != rePassword) {
          message_TK.innerHTML = "Thông tin mật hẩu không trùng khớp";
          return false;
     } else if (phone == "") {
          message_phone.innerHTML = "Hãy nhập sớ điện thoại để để tiếp tục!";
          return false;
     } else if (email == "") {
          message_email.innerHTML = "Hãy nhập email để tiếp tục!";
          return false;
     } else if ((at == -1) && (at == 0) && (dot == -1) && (dot == 0)) {
          message_email.innerHTML("Email không đúng định dạng!");
          return false;
     }
    return true;
}

function Login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;
    if (username.trim() == "") {
        alert("vui lòng nhập username");
        document.getElementById("username").focus();
    }
    if (password.trim() == "" && username.trim()!="") {
        alert("vui lòng nhập password");
        document.getElementById("password").focus();
    }
}

