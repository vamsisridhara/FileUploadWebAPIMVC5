using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AssessmentTest
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new OrderDetails();
        }

        public void Save()
        {
            SqlConnection conn = new SqlConnection("data source=MyServer;initial catalog=MyDB;" +
                                                        "persist security info=False;User ID = user1;Password = test");

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "spOrderAddUpdate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            ID = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            foreach (OrderDetail order in OrderDetails)
            {
                order.OrderID = ID;
            }
            OrderDetails.Save();

        }

    }

    public class OrderDetails : List<OrderDetail>
    {
        public void Save()
        {
            foreach (var order in this)
            {
                order.Save();
            }
        }
    }
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }

        public void Save()
        {
            SqlConnection conn = new SqlConnection("data source=MyServer;initial catalog=MyDB;" +
                                                        "persist security info=False;User ID = user1;Password = test");

            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "spOrderDetailAddUpdate";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }



}
