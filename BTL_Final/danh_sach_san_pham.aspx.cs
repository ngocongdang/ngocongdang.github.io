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
     public partial class danh_sach_san_pham : System.Web.UI.Page
     {

          protected void LoadSearchProduct(string text, object[] parameter , object[] listPara, string Query)
          {

          }
          protected void Page_Load(object sender, EventArgs e)
          {
               string search = Request.QueryString.Get("search");
               string seeMore = Request.QueryString.Get("seeMore");
               string kieudang = Request.QueryString.Get("loaihang");
                    DataTable tb = null;
                    object[] parameter = new object[1];
                    object[] listPr = new object[1];
               if (search != null)
               {
                    parameter[0] = "@text";
                    listPr[0] = search;
                    tb = DataProvider.Instance.ExecuteQr("SearchBtn", parameter, listPr);

               }
               else if (kieudang != null)
               {
                    parameter[0] = "@loaihang";
                    listPr[0] = kieudang;
                    tb = DataProvider.Instance.ExecuteQr("selectKieuDang", parameter, listPr);

               }
               else if (seeMore != null && String.Compare(seeMore, "new", true) == 0)
               {
                    tb = DataProvider.Instance.ExecuteQr("seeMoreNew");
               }
               else if (seeMore != null && String.Compare(seeMore, "sell", true) == 0)
               {
                    tb = DataProvider.Instance.ExecuteQr("seeMoreSell");
               }
               else if (seeMore != null && String.Compare(seeMore, "dis", true) == 0)
               {
                    tb = DataProvider.Instance.ExecuteQr("seeMoreDis");
               }
               string availiable = "", html = "";
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
               }
               productList.InnerHtml = html;

          }
     }
}