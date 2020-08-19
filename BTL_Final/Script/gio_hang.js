function xacNhanXoa() {
     var result = confirm("Bạn có chắc muốn xóa sản phẩm này?");
     if (!result) {
          return false;
     } else
          return true;
}
var btn;
function kiemTraBtnSubmit(i) {
     btn = i;
}
function kiemTraForm() {
     var hoten = document.getElementById("customer_name").value;
     var sdt = document.getElementById("customer_phone").value;
     var diaChi = document.getElementById("customer_address").value;
    console.log(btn);
     if (btn != '3') { //Nếu nút submit ko phải là nút update_cart 
          if (hoten == "" || sdt == "" || diaChi == "") {
               alert("Bạn phải nhập đầy đủ thông tin");
               return false;
          }
    }
}