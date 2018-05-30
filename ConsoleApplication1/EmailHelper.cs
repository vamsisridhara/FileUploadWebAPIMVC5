using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace ConsoleApplication1
{
    public class EmailHelper
    {
        public static DataSet getDataSet()
        {
            string cnString = ConfigurationManager.AppSettings["connection_string"];
            DataSet dataSet = null;
            using (SqlConnection sqlConnection = new SqlConnection(cnString))
            {
                string CommandText = "";
                SqlCommand sqlCommand = new SqlCommand(CommandText, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataSet = new DataSet();
                try
                {
                    sqlDataAdapter.Fill(dataSet, "header");
                    sqlConnection.Close();
                }
                catch (Exception exception)
                {
                    // log exception
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            return dataSet;
        }

        public static string getHtml(DataSet dataSet)
        {
            string messageBody = string.Empty;
            try
            {
                messageBody = "<font>The following are the records: </font><br><br>";
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + "Column1 " + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;

                foreach (DataRow Row in dataSet.Tables[0].Rows)
                {
                    messageBody = messageBody + htmlTrStart;
                    messageBody = messageBody + htmlTdStart + Row["fieldName"] + htmlTdEnd;
                    messageBody = messageBody + htmlTrEnd;
                }
                messageBody = messageBody + htmlTableEnd;
            }
            catch (Exception ex)
            {
                //log exception
            }
            return messageBody;
        }

        public static void sendEmail(string htmlString)
        {
            try
            {
                Int32 portNumber;
                string host = ConfigurationManager.AppSettings["host"].ToString();
                string subject = string.Empty;
                if (Int32.TryParse(ConfigurationManager.AppSettings["port"], out portNumber))
                {

                }
                MailMessage message = new MailMessage(ConfigurationManager.AppSettings["fromAddress"].ToString(),
                        ConfigurationManager.AppSettings["toAddress"].ToString());
                message.IsBodyHtml = true;
                message.Body = htmlString;
                message.Subject = subject;
                SmtpClient client = new SmtpClient(host, portNumber);
                client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSSL"].ToString());
                NetworkCredential AuthenticationDetails = new NetworkCredential(
                    ConfigurationManager.AppSettings["networkUserId"].ToString(),
                    ConfigurationManager.AppSettings["networkPassword"].ToString());
                client.Credentials = AuthenticationDetails;
                client.Send(message);
            }
            catch (Exception exception)
            {

            }

        }

    }
}
