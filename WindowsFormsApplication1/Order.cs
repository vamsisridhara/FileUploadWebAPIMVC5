using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public interface IOrderRepository
    {
        void SaveOrder(Order order);
    }
    public class OrderRepository : IOrderRepository
    {
        public const string connectionString = "data source=MyServer;initial catalog=MyDB;" +
                                                            "persist security info=False;User ID = user1;Password = test";
        void IOrderRepository.SaveOrder(Order order)
        {
            saveorder(order);
        }
        private void saveorder(Order order)
        {
            int orderId;
            try
            {
                using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spOrderAddUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", order.ID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    orderId = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                    saveOrderDetails(order.orderDetails, orderId);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {

            }
        }
        private void saveOrderDetails(List<OrderDetail> orderDetails, int orderId)
        {
            if (orderDetails != null && orderDetails.Count > 0) {
                foreach (var orderDetail in orderDetails)
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spOrderDetailAddUpdate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@ID", orderDetail.ID);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);
                    cmd.Parameters.AddWithValue("@Description", orderDetail.Description);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
        public Order()
        {
            orderDetails = new List<OrderDetail>();
        }
    }

    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
    }

}
