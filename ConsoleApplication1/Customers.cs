using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace AssessmentTest
{
    public class Customer
    {
        public string Address { get; set; }
        public string CustomerType { get; set; }
        public string Name { get; set; }
    }
    public class Customers : List<Customer>
    {
        public void LoadByName(string name)
        {
            ExecuteReader("spGetCustomersByName", name);
        }

        public void LoadByAddress(string address)
        {
            ExecuteReader("spGetCustomersByAddress", address);
        }

        public void LoadAll()
        {
            ExecuteReader("spGetAllCustomers", "");
        }
        private void ExecuteReader(string storedProcName, string paramValue)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection("data source=MyServer;initial catalog=MyDB;" +
                                                        "persist security info=False;User ID = user1;Password = test");
                conn.Open();
                cmd = new SqlCommand(storedProcName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (!String.IsNullOrWhiteSpace(paramValue))
                {
                    cmd.Parameters.AddWithValue("@SearchForParameter", paramValue);
                }
                var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Add(new Customer()
                        {
                            Address = reader["Address"].ToString(),
                            CustomerType = reader["CustomerType"].ToString(),
                            Name = reader["CustomerType"].ToString() == "BUSINESS" ?
                                        string.Format("B-{0}", reader["Name"].ToString())
                                        : reader["Name"].ToString()
                        });
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
        }
    }
}
