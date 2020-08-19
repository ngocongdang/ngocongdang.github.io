using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_Final.Class
{
     public class CartItems
     {
          private int id;
          private string name;
          private string image;
          private float price;
          private float discount;
          private int number;
          public string Image
          {
               get { return image; }
               set { image = value; }
          }

          public float Price
          {
               get { return price; }
               set { price = value; }
          }

          public float Discount
          {
               get { return discount; }
               set { discount = value; }
          }

          public int Number
          {
               get { return number; }
               set { number = value; }
          }

          public int Id
          {
               get { return id; }
               set { id = value; }
          }

          public string Name
          {
               get { return name; }
               set { name = value; }
          }
     }


}