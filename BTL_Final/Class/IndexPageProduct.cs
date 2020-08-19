using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_Final
{
     public class IndexPageProduct
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

          public IndexPageProduct(DataRow row)
          {
               id = (int)row["Id"];
               name = row["Name"].ToString();
               price = float.Parse(row["Price"].ToString());
               image = row["Image"].ToString();
               availiable = bool.Parse(row["Availiable"].ToString());
               discount = float.Parse(row["Discount"].ToString());
          }
     }
}