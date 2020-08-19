using BTL_Final.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Final
{
     public partial class index : System.Web.UI.Page
     {
          public static int i = 0;
          protected static string loadProductList(string cmdText, bool testDiscount)
          {
               DataTable tb = DataProvider.Instance.ExecuteQr(cmdText);
               string html = "";
               string availiable = "";
               foreach (DataRow row in tb.Rows)
               {
                    IndexPageProduct product = new IndexPageProduct(row);
                    if (product.Availiable)
                    {
                         availiable = "Còn hàng";
                    }
                    else
                    {
                         availiable = "Liên hệ";
                    }
                    html += "<a href=\"chi_tiet_san_pham.aspx?id=" + product.Id + "\" class=\"product\">";
                    html += "<div class=\"image\">";
                    html += "<img src=\"img/" + product.Image + ".jpg\">";
                    html += "</div>";
                    html += "<div class=\"product-content\">";
                    html += "<div class=\"title\">";
                    html += "<span class=\"name\">" + product.Name + "</span>";
                    html += "</div>";
                    html += "<div class=\"price\">";
                    html += "<span>" + string.Format("{0:0,0 đ}", product.Price) + "</span>";
                    html += "</div>";
                    html += "<div class=\"shop-name\">";
                    html += "<span>Tình trạng: " + availiable + "</span>";
                    html += "</div>";
                    html += "</div>";
                    html += "</a>";
                    i++;
               }
               return html;
          }
            
          protected void Page_Load(object sender, EventArgs e)
          {
               Title = "Trang chủ";
               new_products_list.InnerHtml = loadProductList("selectNewProducts", false);
               best_seller_list_products.InnerHtml = loadProductList("selectBestSellerProduct", false);
               discount_products_list.InnerHtml = loadProductList("selectDiscountProducts", true);

          }
     }
}