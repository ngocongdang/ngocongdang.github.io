using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BTL_Final
{
     public class Categories
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
          public Categories(DataRow row)
          {
               id = (int)row["Id"];
               name = row["cateName"].ToString();
          }
     }
}