using BTL_Final.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Final
{
     public partial class Header_Footer : System.Web.UI.MasterPage
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               DataTable tb = DataProvider.Instance.ExecuteQr("selectCategories");
               string html = "";
               foreach (DataRow row in tb.Rows)
               {
                    Categories category = new Categories(row);
                    html += "<ul>";
                    html += "<li class=\"item-category\">";
                    html += "<a href=\"danh_sach_san_pham.aspx?loaihang=" + category.Name + "\" class=\"items\">" + category.Name + "</a>";
                    html += "</li>";
                    html += "<ul/>";
               }
               this.Page.ClientScript.GetPostBackEventReference(this, string.Empty);
               list_categories.InnerHtml = html;
               if (Session["cart"] != null)
               {
                    List<CartItems> item = Session["cart"] as List<CartItems>;
                    NumberProductCart.InnerHtml = "" + item.Count;
               }
               else
               {
                    NumberProductCart.InnerHtml = "0";
               }

               if (Request.QueryString["userName"] != null) SignUp();
               if (Request["usernamelogin"] != null) SignIn();
          }
          public void SignUp()
          {
               DataTable tbCustomers = DataProvider.Instance.ExecuteQr("selectCustomers");
               bool existed = false;
               foreach (DataRow row in tbCustomers.Rows)
               {
                    Customers customer = new Customers(row);
                    if (Request.QueryString["userName"] == customer.Username)
                    {
                         Response.Write("<script>alert(\"Username đã tồn tại vui lòng Đăng nhập với Username" + customer.Username + " hoặc đăng ký với Username khác\");window.location.href='index.aspx'</script>");
                         return;
                    }
               }
               if (!existed)
               {
                    string[] parameters = { "@fullname", "@username", "@password", "@Phone", "@email","@address" };
                    string[] values = { Request["fullName"], Request["userName"], Request["passWord"], Request["phone-register"], Request["email-register"],Request["adress-register"] };
                    DataProvider.Instance.ExecuteNonQr("dangki", parameters, values);
                    Response.Write("<script>alert('Đăng ký thành công!');window.location.replace(\"index.aspx\");</script>");
               }
          }
          private void SignIn()
          {
               DataTable tbCustomers = DataProvider.Instance.ExecuteQr("selectCustomers");
               foreach (DataRow row in tbCustomers.Rows)
               {
                    Customers customer = new Customers(row);
                    if (Request.QueryString["usernamelogin"] == customer.Username && Request.QueryString["passwordlogin"] == customer.Password)
                    {
                         customer.Password = "";
                         string html = "<script>" +
                             "alert('Đăng nhập thành công');" +
                             "sessionStorage.setItem(\"CustomerInfo\",'" + JsonConvert.SerializeObject(customer) + "');" +
                             "window.location.href=window.location.pathname;" +
                             "</script>";
                         Response.Write(html);
                         return;
                    }
               }
          }

          private void dangnhap()
          {
               DataTable tb = null;
               object[] parameter = new object[2];
               object[] listPr = new object[2];
               parameter[0] = "@ten";
               parameter[1] = "@mk";
               for (int i = 0; i < 3; i++)
               {
                   
                    listPr[0] = Request["username"];
                    listPr[1] = Request["passWord"];
                    tb = DataProvider.Instance.ExecuteQr("dangnhap", parameter, listPr);
                    if (tb.Rows.Count == 0)
                    {
                         string html = "<script>" +
                         "alert('bạn đã đăng nhập sai" + (i+1) + " lần!'); </script>";
                         Response.Write(html);
                         return;
                    }
                    else
                    {
                         string html = "<script>" +
                             "alert('Đăng nhập thành công');" +
                              //  "sessionStorage.setItem(\"CustomerInfo\",'" + JsonConvert.SerializeObject(customer) + "');" +
                              "window.location.href=window.location.pathname;" +
                             "</script>";
                         Response.Write(html);
                         break;
                    }
               }

          }
     }
}