using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_Final.Class
{
     public class DataProvider
     {

          private static string conStr = @"Data Source=DESKTOP-78BBT0S;Initial Catalog=dbBTL_Web;Integrated Security=True";
          private static DataProvider instance;

          public static DataProvider Instance
          {
               get
               {
                    if (instance == null)
                         instance = new DataProvider();
                    return instance;
               }
               private set
               {
                    instance = value;
               }
          }

          public static object ConfigurationManager { get; private set; }

          private DataProvider() { }

          public DataTable ExecuteQr(string query, object[] parameter = null, object[] lisPara = null)
          {
               DataTable tb;
               using (SqlConnection cnn = new SqlConnection(conStr))
               {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                         cmd.CommandType = CommandType.StoredProcedure;
                         if (parameter != null)
                         {
                              int j = 0;
                              foreach (string item in parameter)
                              {
                                   cmd.Parameters.AddWithValue(item,lisPara[j]);
                                   j++;
                              }
                         }
                         using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                         {
                              tb = new DataTable();
                              adap.Fill(tb);
                         }
                         cnn.Close();
                    }
               }
               return tb;
          }
          public int ExecuteNonQr(string query, object[] parameter = null, object[] lisPara = null)
          {
                int i=0;
               using (SqlConnection cnn = new SqlConnection(conStr))
               {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                         cmd.CommandType = CommandType.StoredProcedure;
                        cnn.Open();
                        if (parameter != null)
                         {
                                 int j = 0;
                               foreach (string item in parameter)
                              {
                                   cmd.Parameters.AddWithValue(item,lisPara[j]);
                                    j++;
                              }
                         }
                        i = cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
               }
               return i;
          }
     }
}