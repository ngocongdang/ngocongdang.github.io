<%@ Page Title="" Language="C#" MasterPageFile="~/Header_Footer.Master" AutoEventWireup="true" CodeBehind="chi_tiet_san_pham.aspx.cs" Inherits="BTL_Final.chi_tiet_san_pham" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="CSS/chi_tiet_san_pham.css" rel="stylesheet" />
     <script src="Script/chi_tiet_san_pham.js"></script>
     <div class="content-detail">
           <div class="container">
          <div class="bodycontent"  >
               <div class="image_detail" runat="server" id="image_detail_asp">
                    <div class="main_image" runat="server" id="product_detail">
                         <img src="img/1001.jpg">
                    </div>
               </div>
               <div class="product_detail" runat="server">
                    <p style="text-align: center;" runat="server" id="product_name_asp">Đồng hồ ABCDEF</p>
                    <hr style="margin-top: 10px;" />
                    <p style="text-align: left;">Giá niêm yết: <span class="price" runat="server" id="price_asp">69.000 đ</span></p>
                    <p style="text-align: left;">Giá bán: <span class="price" runat="server" id="discount_price">69.000 đ</span></p>
                    <p style="text-align: left;">Thông số kỹ thuật</p>
                    <table class="detail" runat="server" id="table_detail">
                         <tr>
                              <td>Thương hiệu:</td>
                              <td style="text-align: left !important;" id="row_thuongHieu" runat="server">Thụy Sĩ</td>
                         </tr>
                         <tr>
                              <td>Giảm giá:</td>
                              <td style="text-align: left !important;" id="row_discount" runat="server">Thụy Sĩ</td>
                         </tr>
                         <tr>
                              <td>Tình trạng:</td>
                              <td style="text-align: left !important;" id="row_availiable" runat="server">Đồng hồ nam</td>
                         </tr>
                         <tr>
                              <td>Sản phẩm mới:</td>
                              <td style="text-align: left !important;" id="row_isNewProduct" runat="server">Automatic (cơ tự động)</td>
                         </tr>
                         <tr>
                              <td>Sản phẩm bán chạy:</td>
                              <td style="text-align: left !important;" id="row_isSellerProduct" runat="server">5 ATM</td>
                         </tr>
                         <tr>
                              <td>Quà tặng:</td>
                              <td style="text-align: left !important;" id="row_gift" runat="server">Sapphire</td>
                         </tr>
                         <tr>
                              <td>Loại hàng:</td>
                              <td style="text-align: left !important;" id="row_category" runat="server">43.5mm</td>
                         </tr>
                         <tr>
                              <td>Mô tả:</td>
                              <td style="text-align: left !important;" id="row_description" runat="server">Dây là đăng đẹp trai </td>
                         </tr>
                    </table>
                    <a class="add_to_cart_btn" title="Thêm vào giỏ hàng" id="addtocart" runat="server" onclick="return themThanhCong()"><i class="fa fa-shopping-basket"></i>&emsp;THÊM VÀO GIỎ HÀNG</a>
                    <a class="buy_now" title="Mua ngay" id="buynow" runat="server"><i class="fa fa-shopping-cart"></i>&emsp;MUA NGAY</a>
                    <p style="text-align: center;">Hoặc đặt hàng trực tiếp <span class="phone_number">033-423-6169</span></p>
               </div>
               <div style="clear: both; border: 0px;"></div>
               <!--Vì 2 thẻ div trên dùng float nên để cho bố cục trang về ban đầu thì phải clear float đi-->
          </div>
     </div>
     </div>
</asp:Content>
