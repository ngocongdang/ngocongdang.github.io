using BTL_Final.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Final
{
     public partial class gio_hang : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               Response.Cache.SetCacheability(HttpCacheability.NoCache);
               Response.Cache.SetNoStore();
               Title = "Giỏ hàng";
               if (Session["cart"] != null)
               {
                    List<CartItems> cart = Session["cart"] as List<CartItems>;
                    if (Request.QueryString.Get("id") != null && Request.QueryString.Get("action") == "delete")
                    {
                         foreach (CartItems item in cart)
                         {
                              if (item.Id == int.Parse(Request.QueryString.Get("id")))
                              {
                                   cart.Remove(item);
                                   Session["cart"] = cart;
                                   Response.Redirect("gio_hang.aspx");
                              }
                         }
                    }
                    if ((Session["cart"] as List<CartItems>).Count == 0)
                    {
                         string html = "<div class=\"no_product\"";
                         html += "<p style=\"font-size:16pt; margin:0;padding:60px; text-align:center;\">Giỏ hàng của bạn hiện rỗng</p><br>";
                         html += "<a href=\"index.aspx\" class=\"buy_more\">MUA NGAY</a>";
                         html += "</div>";
                         bodycontent.InnerHtml = html;
                    }
                    else
                    {
                         string html = "";
                         float tongTien = 0;
                         foreach (CartItems item in cart)
                         {
                              html += "<div class=\"rows\">";
                              html += "	<img src=\"img/" + item.Image + ".jpg\" alt=\"image\"/>";
                              html += "	<a class=\"name\" href=\"chi_tiet_san_pham.aspx?id=" + item.Id + "\">" + item.Name + "</a>";
                              html += "	<label class=\"price\">" + String.Format("{0:0,0 đ}", (item.Price - item.Discount)) + "</label>";
                              html += "   <input type=\"number\" min=\"1\" max=\"99\" value=\"" + item.Number + "\" id=\"quantity_" + item.Id + "\" name=\"quantity_" + item.Id + "\" runat=\"server\" class=\"quantity\"/>";
                              html += "	<label  class=\"totalPrice\">" + String.Format("{0:0,0 đ}", item.Number * (item.Price - item.Discount)) + "</label>";
                              html += "	<a href=\"gio_hang.aspx?id=" + item.Id + "&action=delete\" class=\"remove\" onclick=\"return xacNhanXoa()\"><i class=\"fa fa-trash\"></i></a>";
                              html += "</div>";
                              tongTien += item.Number * (item.Price - item.Discount);
                         }
                         cartRowItem.Controls.Add(new Literal() { Text = html });
                         price_number.InnerHtml = string.Format("{0:0,0 đ}", tongTien);
                        }
                    if (Request.QueryString.Get("update_cart") != null)
                    {
                        cart = Session["cart"] as List<CartItems>;
                        foreach (CartItems item in cart)
                        {
                            item.Number = int.Parse(Request.QueryString.Get("quantity_" + item.Id.ToString()));
                        }
                        Session["cart"] = cart;
                        Response.Redirect("gio_hang.aspx");
                    }
                    if (Request.QueryString["payment"]!=null)
                    {
                        var hoten = Request.QueryString.Get("customer_name");
                        var sdt = Request.QueryString.Get("customer_phone");
                        var diaChi = Request.QueryString.Get("customer_address");
                        var email = Request.QueryString.Get("customer_email");
                        var ghiChu = Request.QueryString.Get("customer_note");
                        Session["cart"] = null;
                        Response.Redirect("gio_hang.aspx");
                    }
                }
               else //nếu session giỏ hàng = null
               {
                    string html = "<div class=\"no_product\"";
                    html += "<p style=\"font-size:16pt; margin:0;padding:60px; text-align:center;\">Giỏ hàng của bạn hiện rỗng</p><br>";
                    html += "<a href=\"index.aspx\" class=\"buy_more\">MUA NGAY</a>";
                    html += "</div>";
                    bodycontent.InnerHtml = html;
               }
          }
     }
}