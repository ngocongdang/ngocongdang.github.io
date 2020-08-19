using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_Final.Class
{
     public class Products
     {
          private int id;

          public int Id
          {
               get { return id; }
               set { id = value; }
          }
          private string name;

          public string Name
          {
               get { return name; }
               set { name = value; }
          }
          private float price;

          public float Price
          {
               get { return price; }
               set { price = value; }
          }
          private string image;

          public string Image
          {
               get { return image; }
               set { image = value; }
          }
          private float discount;

          public float Discount
          {
               get { return discount; }
               set { discount = value; }
          }
          private bool availiable;

          public bool Availiable
          {
               get { return availiable; }
               set { availiable = value; }
          }
          private string description;

          public string Description
          {
               get { return description; }
               set { description = value; }
          }
          private bool bestSeller;

          public bool BestSeller
          {
               get { return bestSeller; }
               set { bestSeller = value; }
          }
          private bool lastest;

          public bool Lastest
          {
               get { return lastest; }
               set { lastest = value; }
          }
          private string gift;

          public string Gift
          {
               get { return gift; }
               set { gift = value; }
          }
          private string cateName;

          public string CateName
          {
               get { return cateName; }
               set { cateName = value; }
          }
          private string supName;

          public string SupName
          {
               get { return supName; }
               set { supName = value; }
          }
          private string email;

          public string Email
          {
               get { return email; }
               set { email = value; }
          }
          private string logo;

          public string Logo
          {
               get { return logo; }
               set { logo = value; }
          }
          private string phone;

          public string Phone
          {
               get { return phone; }
               set { phone = value; }
          }
          public Products(DataRow row)
          {
               id = (int)row["Id"];
               name = row["Name"].ToString();
               price = float.Parse(row["Price"].ToString());
               image = row["Image"].ToString();
               availiable = bool.Parse(row["Availiable"].ToString());
               discount = float.Parse(row["Discount"].ToString());
               description = row["Description"].ToString();
               bestSeller = bool.Parse(row["Bestseller"].ToString());
               lastest = bool.Parse(row["Lastest"].ToString());
               gift = row["Gift"].ToString();
               cateName = row["cateName"].ToString();
               supName = row["supName"].ToString();
               email = row["Email"].ToString();
               logo = row["Logo"].ToString();
               phone = row["Phone"].ToString();

          }

     }
}