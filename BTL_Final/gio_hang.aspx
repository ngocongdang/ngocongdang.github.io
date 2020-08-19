<%@ Page Title="" Language="C#" MasterPageFile="~/Header_Footer.Master" AutoEventWireup="true" CodeBehind="gio_hang.aspx.cs" Inherits="BTL_Final.gio_hang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="Script/gio_hang.js"></script>
     <link href="CSS/style.css" rel="stylesheet" />
     <link href="CSS/gio_hang.css" rel="stylesheet" />
     <div class="main_cart">
          <div class="container">
               <div class="bodycontent" id ="bodycontent" runat ="server">
                    <form method="get" id="cart_form" onsubmit="kiemTraForm()">
                             <div class="cart_product">
                                  <p class="title">THÔNG TIN GIỎ HÀNG</p>
                                  <div class="header_rows">
                                       <label style="width: 230px; padding-left: 100px">SẢN PHẨM</label>
                                       <label style="width: 80px;">GIÁ</label>
                                       <label style="width: 100px;">SỐ LƯỢNG</label>
                                       <label style="width: 120px;">THÀNH TIỀN</label>
                                  </div>
                                  <div class="cart_row" runat="server" id="cartRowItem">
                                  </div>
                                  <div class="updateCart_totalPrice">
                                       <button type="submit" value="3" id="update_cart" name="update_cart" onclick="kiemTraBtnSubmit(3)">CẬP NHẬT GIỎ HÀNG</button>
                                       <p>Tổng tiền: <span id="price_number" runat="server">0 đ</span></p>
                                  </div>
                                  <a href="index.aspx" class="buy_more">MUA THÊM</a>
                              </div>
                              <div class="bill_info">
                                  <p class="title">THÔNG TIN ĐẶT HÀNG</p>
                                  <table>
                                       <tr>
                                            <td></td>
                                            <td>Lưu ý: Mục <span class="red">(*)</span> là bắt buộc phải ghi
                                            </td>
                                       </tr>
                                       <tr>
                                            <td>Họ và tên <span class="red">(*)</span>:</td>
                                            <td>
                                                 <input type="text" id="customer_name" name="customer_name"></td>
                                       </tr>
                                       <tr>
                                            <td>Điện thoại <span class="red">(*)</span>:</td>
                                            <td>
                                                 <input type="text" id="customer_phone" name="customer_phone"></td>
                                       </tr>
                                       <tr>
                                            <td>Địa chỉ <span class="red">(*)</span>:</td>
                                            <td>
                                                 <input type="text" id="customer_address" name="customer_address"></td>
                                       </tr>
                                       <tr>
                                            <td>Email:</td>
                                            <td>
                                                 <input type="text" id="customer_email" name="customer_email"></td>
                                       </tr>
                                       <tr>
                                            <td>Ghi chú:</td>
                                            <td>
                                                 <textarea name="customer_note"></textarea></td>
                                       </tr>
                                        <tr>
                                            <td><input type="hidden" name="custID" id="custID"/></td>
                                        </tr>
                                  </table>
                                  <script>
                                      var customerinfo = JSON.parse(sessionStorage.getItem('CustomerInfo'));
                                      if (customerinfo != null) {
                                          document.getElementById('customer_name').value = customerinfo.Fullname;
                                          document.getElementById('customer_phone').value = customerinfo.Phone;
                                          document.getElementById('customer_email').value = customerinfo.Email;
                                          document.getElementById('custID').value = customerinfo.Username;
                                      } else {
                                          alert('Hãy đăng nhập để chúng tôi biết bạn là ai');
                                      }
                                  </script>
                                  <div class="css-bt">
                                       <button class="CODpayment" name="payment" value="1" type="submit" onclick="kiemTraBtnSubmit(1)">THANH TOÁN KHI NHẬN HÀNG</button>
                                       <button class="ONLpayment" name="payment" value="2" type="submit" onclick="kiemTraBtnSubmit(2)">THANH TOÁN ONLINE</button>
                                  </div>
                             </div>
                    </form>
               </div>
          </div>
     </div>
</asp:Content>
