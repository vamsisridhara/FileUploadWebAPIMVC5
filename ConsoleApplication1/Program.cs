﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using AssessmentTest;
using Newtonsoft.Json;

namespace custommetadata
{
    public enum pri { high, medium, low }

}

namespace n1
{
    public class cl1 { }
    class class2
    {
        class class3 { }

    }
}
namespace n2
{
    class cl4 { }
}
namespace ConsoleApplication1
{


    class Pet
    {
        public virtual void speak() { Console.WriteLine("not impl"); }
    }
    class cat : Pet
    {
        public override void speak()
        {
            Console.WriteLine("moe");
        }

    }
    class dog : Pet { public new void speak() { Console.WriteLine("woff"); } }
    class bird : Pet { public void speak() { Console.WriteLine("tww"); } }
    //public static class teeee
    //{
    //    internal static bool Equals<T>(this T first, T second)
    //    {
    //        return first == second;
    //    }
    //}
    public class LCRRun
    {
        public ExportSetups[] exportSetups { get; set; }
    }
    public class ExportSetups
    {
        public string sql { get; set; }
        public string comment { get; set; }
    }
    class Program
    {
        static void A()
        {
            try
            {
                B();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static void B()
        {
            try
            {
                c();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void c()
        {
            throw new InvalidOperationException();
        }
        //public static string ToUpper(this string s)
        //{
        //    return s;
        //}
        static object Eval(int a)
        {
            var param = Expression.Parameter(typeof(int), "param");
            Expression body = Expression.Add(param, Expression.Constant(a));
            var lambda = Expression.Lambda(body, param);
            return lambda.Compile().DynamicInvoke(3);
        }
        static ManualResetEvent myevent;

        static void worker()
        {
            while (true)
            {

                Thread.Sleep(1000);
                Console.WriteLine("wrokig");
                myevent.WaitOne();
            }

        }
        static string reverseWords(string input)
        {
            string output = string.Empty;
            if (!string.IsNullOrWhiteSpace(input) && input.Contains(" "))
            {
                output = string.Join(" ", input.Split(' ').Reverse());
            }
            return output;
        }
        static void DoSomeWork()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                conn = new SqlConnection(
                     @"Persist Security Info=False;Integrated Security=true;Initial Catalog=Northwind;server=VAMSISRIDHARA\SQLEXPRESS");
                conn.Open();
                cmd = new SqlCommand("spGetCustomers", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format(
                            "{0},{1}", reader["LastName"].ToString(), reader["FirstName"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
                if (conn != null) { conn.Close(); }
            }
        }
        static int MonthDifference(DateTime lValue, DateTime rValue)
        {
            return Math.Abs((lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year));
        }
        static void calcuatetax(DateTime dtax, DateTime paydate, double taxamount, int months)
        {
            double intrate = 0.05;
            double payment = 0;
            double maxPayment = taxamount * 0.15;
            if (paydate <= dtax)
            {
                Console.WriteLine("payment date is less than or equal to the delinquent date");
            }
            if (!(paydate <= dtax) && months > 0)
            {
                if (intrate > 0)
                {
                    double rate = ((intrate / months) / 100);
                    double factor = (rate + (rate / (Math.Pow(rate + 1, months) - 1)));
                    payment = (taxamount * factor);
                }
                else
                {
                    payment = (taxamount / (double)months);
                }
            }
            if (maxPayment > payment)
            {
                Console.WriteLine("maximum interest that can be charged is 15% of the tax amount");
            }
            else if (payment == 0)
            {
                Console.WriteLine("interest due cannot be less than 0.");
            }
            else
            {
                Console.WriteLine(Math.Round(payment, 2));
            }
        }
        static void printnumbers()
        {
            for (var count = 0; count < 100; count++)
            {
                if (count % 3 == 0 && count % 5 == 0) { Console.WriteLine("Fizzbuzz"); }
                else if (count % 3 == 0) { Console.WriteLine("Fizz"); }
                else if (count % 5 == 0) { Console.WriteLine("Buzz"); }
                else { Console.WriteLine(count); }
            }
        }
        static void Main(string[] args)
        {
            
            printnumbers();
            //OrderDetail od = new OrderDetail()
            //{
            //    ID = 1,
            //    OrderID = 1,
            //    Description = "des",
            //    Quantity =100,
            //    UnitPrice = 20
            //};

            //Order order = new Order()
            //{
            //    ID = 1,
            //    OrderDate = DateTime.Now,
            //    CustomerID = 100,
            //};
            //order.Save();


            DateTime dtax = new DateTime(2014, 01, 31);
            DateTime paydate = new DateTime(2016, 06, 30);
            calcuatetax(dtax, paydate, 5000, MonthDifference(dtax, paydate));


            Employee employee = new Employee();
            employee.Initialize(500);
            employee.Manager.Name = "";

            DoSomeWork();
            Console.Write(reverseWords("The Car is Red"));
            Console.Read();

            LCRRun lcrRun = new ConsoleApplication1.LCRRun()
            {
                exportSetups = new ExportSetups[] {
                    new ExportSetups()
                    {
                        comment = "text",
                        sql = "select * from categories " +
                        " selct kjsdfljsflj " +
                        " asdjkljlkj " +
                        " aslfjdsfjdsf " +
                        " kjsdfjdkl"
                    },
                    new ExportSetups() {
                        comment = "text",
                        sql = "select * from categories " +
                        " selct kjsdfljsflj " +
                        " asdjkljlkj " +
                        " aslfjdsfjdsf " +
                        " kjsdfjdkl"
                    },
                }
            };
            //System.IO.File.WriteAllText(@"c:\acr\lcrrun.json", JsonConvert.SerializeObject(lcrRun,Formatting.None));
            LCRRun temp = JsonConvert.DeserializeObject<LCRRun>(File.ReadAllText(@"c:\acr\lcrrun.json"));
            if (temp != null)
            {

                temp.exportSetups.ToList().ForEach(
                                x => { x.sql = Regex.Replace(x.sql, @"\r\n+", " "); });
                foreach (var item in temp.exportSetups)
                {
                    Console.WriteLine("old string: " + item.sql);
                    // var newstring = Regex.Replace(item.sql, @"\r\n+", " ");
                    //Console.WriteLine("new string :" + newstring);
                }
            }

            //string k = "This is my\r\nugly string. I want\r\nto change this. Please \r\n help!";
            //k = System.Text.RegularExpressions.Regex.Replace(k, @"\r\n+", " ");



            try
            {
                Console.WriteLine("Output 1:");
                IShoppingCart shoppingBasket = new ShoppingCart()
                {
                    ProductsList = new List<Product>()
                    {
                        new Book("1 Book", 12.49M,ProductType.Book),
                        new Music("1 Music CD", 14.99M, ProductType.Music, ImportDuty.SalesTax),
                        new Food("1 Chocolate Bar",0.85M,ProductType.Food)
                    }
                };
                Console.WriteLine(shoppingBasket.calcuateTax());
                Console.WriteLine("Output 2:");
                shoppingBasket = new ShoppingCart()
                {
                    ProductsList = new List<Product>()
                    {
                        new Food("1 Imported Box of Chocolates",10.00M,ProductType.Other, ImportDuty.ImportDutyTax),
                        new OtherProduct("1 Imported Bottle of Perfume",47.50M,ProductType.Other, ImportDuty.ImportDutyTax)
                    }
                };
                Console.WriteLine(shoppingBasket.calcuateTax());

                Console.WriteLine("Output 3:");
                shoppingBasket = new ShoppingCart()
                {
                    ProductsList = new List<Product>()
                    {
                        new OtherProduct("1 imported bottle of perfume",27.99M,ProductType.Other, ImportDuty.ImportDutyTax),
                        new OtherProduct("1 bottle of perfume",18.99M,ProductType.Other),
                        new Medical("1 packet of headache pills",9.75M,ProductType.Medical),
                        new Food("1 Imported Box of Chocolates",11.25M,ProductType.Other, ImportDuty.ImportDutyTax)
                    }
                };
                Console.WriteLine(shoppingBasket.calcuateTax());
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }














            var url = "http://apwmad0a2034:81/ReportServer/Pages/ReportViewer.aspx?/Public Reports/datcp_WM_ChangeofOwnership_MyDatcp";
            var spliturl = url.Split('/').Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => x).ToArray();
            if (!String.IsNullOrWhiteSpace(spliturl[0]) && !String.IsNullOrWhiteSpace(spliturl[1])
                && !String.IsNullOrWhiteSpace(spliturl[2]))
            {
                var finalURL = spliturl[0] + "//" + spliturl[1] + "/" + spliturl[2];
                var compareURL = "http://apwmad0a2034:81/ReportServer";
                if (finalURL == compareURL)
                {
                    Console.WriteLine("equals");
                }
            }

            List<Pet> lst = new List<Pet>();
            lst.Add(new cat());
            lst.Add(new dog());
            lst.Add(new bird());
            foreach (var item in lst)
            {
                item.speak();

            }
            Console.WriteLine();

            //myevent = new ManualResetEvent(true);
            //ThreadStart mythred = new ThreadStart(worker);
            //Thread myth = new Thread(mythred);
            //myth.Start();
            //Console.ReadKey();




            //Assembly sampleass;
            //var class1 = new n1.cl1();
            //sampleass = Assembly.GetAssembly(class1.GetType());
            //var types = sampleass.GetTypes();
            //foreach (var t in types)
            //{
            //    Console.WriteLine(t.GetType());
            //}



            //try
            //{

            //    try
            //    {
            //        int x = 0;
            //        int y = 5 / x;

            //    }
            //    catch (DivideByZeroException dex) {
            //        Console.WriteLine("1");throw;
            //    }
            //    catch (Exception exs) { Console.WriteLine("2"); throw; }
            //}
            //catch (DivideByZeroException exp)
            //{

            //    Console.WriteLine("3");
            //}
            //catch (Exception ex) { Console.WriteLine("4"); }
            dynamic myvariable;
            myvariable = "three";
            Type mytpe = myvariable.GetType();
            myvariable = myvariable.ToUpper();
            myvariable = 3;




            //UInt16 indata = 0xFFFF;
            //byte[] bytes = BitConverter.GetBytes(indata);
            //Int32 outdata = BitConverter.ToInt16(bytes, 0);

            string[] colors = { "House", "Room", "Building", "Street" };
            var lenth = colors.Max(c => c.Length);
            //string s = "Csharp";
            //Console.WriteLine(s.ToUpper());

            Eval(1);

            Console.Read();

            //Expression<Func<string, int>> exp;
            //exp = str => str.Length;

            //int lenght = exp.Compile()("CSharp");
            //Console.WriteLine(exp.Compile()("CSharp"));


            //try
            //{
            //    A();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.StackTrace);
            //}



            //string[] ordinals = new string[] { "first", "second", "third", "fourth" };
            //var taken = ordinals.Take(3);
            //Console.WriteLine(taken.Count());

            //Nullable<long> lng = null;


            //object o = null;
            //try
            //{
            //    int? i = (int?)o;
            //    int i2 = i ?? 0;
            //    Console.WriteLine(i2);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}



            //MultiThreadTest threadTest = new MultiThreadTest();
            //threadTest.proessMultithreading();

            ////using async and Task
            //threadTest.ProcessWriteMult();
            //Console.Read();
        }
    }
    //create a class 
    public class MultiThreadTest
    {
        //create an object
        public object tLock = new object();

        //method to write 
        public void proessMultithreading()
        {
            //use the lock mechanism
            lock (tLock)
            {
                Console.WriteLine(" {0} is Executing", Thread.CurrentThread.Name);
                for (int count = 0; count < 10; count++)
                {
                    //keep the thread sleep
                    Thread.Sleep(new Random().Next(5));
                    Console.WriteLine(" {0},", count);
                }
                Console.WriteLine();
            }
        }

        public async void ProcessWriteMult()
        {
            //create list of Task
            List<Task> tasksList = new List<Task>();
            //create list of FileStreams
            List<FileStream> sourceStreams = new List<FileStream>();
            try
            {
                for (int index = 1; index <= 10; index++)
                {
                    //assign the file path to store the files
                    string filePath = @"c:\tempfolder\" + "content" + index.ToString("00") + ".txt";
                    //get the byte
                    byte[] encodedText = Encoding.Unicode.GetBytes("In file " + index.ToString() + "\r\n");
                    //assign the file stream
                    FileStream sourceStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None,
                                                      bufferSize: 4096, useAsync: true);
                    //write the content
                    Task theTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                    //add the source stream to list of source stream
                    sourceStreams.Add(sourceStream);
                    //add the list of tasks 
                    tasksList.Add(theTask);
                }
                //
                await Task.WhenAll(tasksList);
            }
            catch (Exception exception)
            {
                //log the exception
                Console.WriteLine("Exception thrown at : " + exception.InnerException.Message);
            }
            finally
            {
                //close the file streams
                foreach (FileStream sourceStream in sourceStreams)
                {
                    sourceStream.Close();
                }
            }
        }
    }
}