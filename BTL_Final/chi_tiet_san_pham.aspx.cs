using BTL_Final.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Final
{
     public partial class chi_tiet_san_pham : System.Web.UI.Page
     {
          protected void LoadProduct()
          {

               string id = Request.QueryString.Get("id");
               DataTable tb;
               object[] parameter = new object[1];
               object[] listPr = new object[1];
               parameter[0] = "@id";
               listPr[0] = id;
               tb = DataProvider.Instance.ExecuteQr("selectProductById", parameter, listPr);
               Session["id"] = id;
               Products product = new Products(tb.Rows[0]);
               string html = "<div class=\"main_image\">";
               html += "<img src=\"img/" + product.Image + ".jpg\">";
               html += "</div>";
               Title = product.Name;
               product_detail.InnerHtml = html;
               product_name_asp.InnerHtml = product.Name.ToUpper();
               price_asp.InnerHtml = string.Format("{0:0,0 đ}", product.Price);
               discount_price.InnerHtml = string.Format("{0:0,0 đ}", (product.Price - product.Discount));
               row_thuongHieu.InnerHtml = product.SupName.ToUpper();
               row_discount.InnerHtml = string.Format("{0:0,0 đ}", product.Discount);
               string availiable;
               if (product.Availiable)
               {
                    availiable = "Có sẵn";
               }
               else
               {
                    availiable = "Liên hệ";
               }
               row_availiable.InnerHtml = availiable;

               string isNew;
               if (product.Lastest)
               {
                    isNew = "Hàng mới";
               }
               else
               {
                    isNew = "Không";
               }
               row_isNewProduct.InnerHtml = isNew;

               string isBest;
               if (product.BestSeller)
               {
                    isBest = "Hàng bán chạy";
               }
               else
               {
                    isBest = "Không";
               }

               row_isSellerProduct.InnerHtml = isBest;
               row_gift.InnerHtml = product.Gift;
               row_category.InnerHtml = product.CateName;
               row_description.InnerHtml = product.Description;
               addtocart.HRef = "chi_tiet_san_pham.aspx?id=" + product.Id + "&action=add";
               buynow.HRef = "chi_tiet_san_pham.aspx?id=" + product.Id + "&action=add&redirect=true";

               if (Session["id"] != null && Request.QueryString.Get("action") == "add")
               {
                    List<CartItems> cart = new List<CartItems>();
                    if (Session["cart"] == null)
                    {
                         Session["cart"] = cart;
                    }
                    else
                    {
                         cart = Session["cart"] as List<CartItems>;
                    }
                    CartItems demo = new CartItems();
                    Boolean isExist = false;
                    foreach (CartItems item in cart)
                    {
                         if (item.Id == product.Id)
                         {
                              item.Number++;
                              isExist = true;
                              break;
                         }
                    }
                    if (!isExist)
                    {
                         demo.Id = product.Id;
                         demo.Name = product.Name;
                         demo.Image = product.Image;
                         demo.Price = product.Price;
                         demo.Discount = product.Discount;
                         demo.Number = 1;
                         cart.Add(demo);
                    }
                    Session["cart"] = cart;
                    if (Request.QueryString.Get("redirect") == "true")
                    {
                         Response.Redirect("gio_hang.aspx");
                    }
                    else
                    {
                         Response.Redirect("chi_tiet_san_pham.aspx?id=" + product.Id);
                    }
               }
          }

          protected void Page_Load(object sender, EventArgs e)
          {
               LoadProduct();
          }
     }
}