using static System.Math;
using System;
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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapper.Mappers;
using AutoMapper.Configuration.Conventions;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using n1;
using System.Runtime.CompilerServices;

namespace custommetadata
{
    public enum pri { high, medium, low }
    //test
}

namespace n1
{
    public static class test
    {
        static string ToUpper(this string s)
        {
            return s;
        }
    }
    public class Member
    {
        public int freetickets { get; set; }

    }
    public class Associate : Member
    {
        public new int freetickets { get; set; }
    }
    public class CA
    {
        public string prop { get; set; }
        public string methoda(int va)
        {
            return va.ToString();
        }

    }


    public interface Myinter
    {
        string method();
    }
    public class c2 : Myinter
    {

        public string method()
        {
            return "te";
        }
    }
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
    class DataList<TData> : IEnumerable<TData>
    {
        public IEnumerator<TData> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
    public abstract class Student { }
    public class EnginerignStudent : Student { }
    public class LiterStu : Student { }
    //public class Course<TStu> {
    //    private List<TStu> stu = new List<TStu>();
    //    public void CreateTempl() {
    //        stu.Add(new TStu());
    //    }
    //}
    public class GenderResolver : AutoMapper.IValueResolver<bool, string, string>
    {
        public string Resolve(bool source, string destination, string destMember, ResolutionContext context)
        {
            return source ? "Man" : "Female";
        }
    }

    //public class DateFormatter : AutoMapper.
    //{
    //    public string FormatValue(ResolutionContext context)
    //    {
    //        return ((DateTime)context.SourceValue).ToShortDateString();
    //    }


    //}

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
    public class EmployeeMap
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public AddressMap Address { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public int Age { get; set; }
        public int YearsInCompany { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class AddressMap
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }

    public class EmployeeViewItemMap
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public int YearsInCompany { get; set; }
        public string StartDate { get; set; }
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
        //static IEnumerable ParseCodes(string value, out int code)
        //{
        //    int parsedCode;
        //    code = 0;
        //    if (!Int32.TryParse(value, out parsedCode)) {
        //        yield return "false";
        //    }
        //    code = parsedCode;
        //    for (int i = 0; i <= parsedCode.ToString().Length; i++) {
        //        yield return parsedCode.ToString().Substring(i, 1);
        //    }
        //}
        delegate int Calculator(int m, int n);
        private static void A1()
        {
            try { B1(); }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void B1()
        {
            try { C(); }
            catch (Exception ex)
            {
                throw;
            }
        }
        private static void C()
        {
            throw new InvalidOperationException();
        }
        internal static void method() { }

        static void updateText()
        {

            Console.Write("te");

        }
        static void showmess(string t, [CallerMemberName]string t1 = "")
        {
            string m = t1;
            Console.Write(t1);
        }
        [Obsolete("use mthod1", false)]
        static string methodx()
        {
            return "test";
        }
        static void m1(string na = "")
        {
            Console.Write(na);
        }
        public enum WeeklyoFf { Sunday = 1, saturday = 2 }
        static async Task<string> testasync()
        {
            await Task.Delay(100);
            string ms = "yr";
            return ms;
        }
        static decimal logadd(decimal op1, decimal op2)
        {
            var result = op1 + op2;
            Console.WriteLine("{0}+{1} = {2}", op1, op2, result);
            return result;
        }
        static void Log(string mesg, [CallerMemberName] string method = null)
        {
            Console.Write(String.Format("{0} {1}", mesg, method));
        }

        static void printVehicle(List<Vehicle> vehicleList)
        {
            foreach (var vehicle in vehicleList)
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {

                VehicleData data = new VehicleData();
                var newestVehicle = data.getNewestVehicleInOrder();
                Console.WriteLine("1) A function to calculate newest vehicles in order");
                printVehicle(newestVehicle);

                var alphabeticalVehicles = data.getAlphabetizedList();
                Console.WriteLine("2) A function to calculate alphabetized List of vehicles");
                printVehicle(alphabeticalVehicles);

                var orderByvehiclesPrice = data.getOrderedListOfVehiclesByPrice();
                Console.WriteLine("3) A function to calculate ordered List of Vehicles by Price");
                printVehicle(orderByvehiclesPrice);

                var bestVehiclebyMileage = data.getBestValueByMileage();
                Console.WriteLine("4) A function to calculate the best value");
                Console.WriteLine(bestVehiclebyMileage.ToString());

                var fuelConsumption = data.getFuelConsumption();
                Console.WriteLine("5) A function to calculate full consumption for a given distance");
                Console.WriteLine(fuelConsumption.ToString());

                var randomVehicle = data.getRandomCar();
                Console.WriteLine("6) A function to return a random car from the list");
                Console.WriteLine(randomVehicle.ToString());

                String output = data.getAverageMPGByYear();
                Console.WriteLine("7) A function to return average MPG by year");
                Console.WriteLine(output);



                string s = "Csharp";
                Console.WriteLine(s.ToUpper());




                List<Func<int, int>> coinFunctiosn = new List<Func<int, int>>();
                var coins = new int[] { 1, 5, 10, 25 };
                for (var ijk = 0; ijk < coins.Length; ijk++)
                {
                    coinFunctiosn.Add((count11) => coins[ijk] * count11);

                }
                foreach (var item in coinFunctiosn)
                {
                    Console.WriteLine(item(2));
                }



                int baseInt = 23;
                object o = baseInt;
                short i = (short)(int)o;

                Expression<Func<string, int>> exp;
                exp = st => st.Length;
                int len = exp.Compile()("CShar");

                var salaryGrades = new List<int>() { 11, 14, 15, 18 };
                var maxSalaryGrade = new Dictionary<int, double>()
                                        { { 10,40000 } };


                var literal = 0xadefdebe;
                Console.WriteLine(literal.GetType().Name);

                Log("Begining");
                Console.WriteLine("test");
                Log("Ending");

                n1.Associate ass = new n1.Associate();
                n1.Member y = ass;
                Associate z = (Associate)y;
                ass.freetickets = 1;
                y.freetickets = 2;
                Console.Write(z.freetickets);

                Console.Write(y.freetickets);

                logadd(2.2m, 1);

                var pe = new { fname = "tets", lname = "doe" };
                try
                {

                    Console.WriteLine(pe.fname + " " + pe.lname);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("test");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("test1");
                }
                m1();

                int count1 = 1;
                int i1 = 2;
                i1 = i1 + count1++;
                Console.Write(i1);

                bool? fal = null;

                System.IO.Directory.CreateDirectory(@"c:\vamsiusha\usha");
                string ms = "tst";
                showmess(ms);

                WeeklyoFf off = WeeklyoFf.saturday;
                off = (WeeklyoFf)5;
                Console.Write(off.ToString());

                string q = "update prod set ta='test' whre prod=1";
                dynamic d = new CA();
                d.methoda("xiud");
                Thread tr = new Thread(updateText);
                tr.Start();

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            foreach (Match item in Regex.Matches("Ninety Six Thousand and Ninety Starts", @"\bN\S*"))
            {
                Console.Write(item.Value);
                Console.Read();
            }


            int count = 0; int t = 0;
            try
            {
                count++;
                count = count / t;
                count++;
            }
            catch (Exception ex)
            {

            }
            count++;
            Console.Write(count);

            var str = "Brainbench";

            //try
            //{
            //    string p = @"\b(\w+)\s\1\b";
            //    var r = new Regex(p, RegexOptions.Singleline,Time);
            //    var m = r.Match("I am string to be tested");

            //}
            //catch (RegexMatchTimeoutException ex)
            //{

            //    throw;
            //}
            //switch (customerTran)
            //{
            //    case "Cash": Console.WriteLine("cash");
            //        return;
            //    case "Visa": 
            //    case "Master":
            //    case "cc":
            //        Console.WriteLine("cc");break;
            //    default:return;

            //}



            try { A1(); }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            //int? xyz = 5;
            //Console.WriteLine(xyz.GetType());

            //Calculator cd = new Calculator((n, m) => n + m);
            //cd += new Calculator((n, m) => n * m);
            //Console.WriteLine(cd(cd(2, 5), 4));
            //try
            //{
            //    var person = new { FirstName = "Jon", LastName = "Doe" };
            //    dynamic typeList = null;
            //    typeList.invoke();
            //}
            //catch (Exception ex) { }


            string[] ordinals = new string[] { "First", "second", "third", "fourth" };
            var taken = ordinals.Take(3);
            Console.WriteLine(taken.Count());

            int[] numbers = { 1, 3, 4, 5, 6 };
            int[] evenNumbers = Array.FindAll<int>(numbers, i => i % 2 == 0);

            int ij = 0;
            ij *= 1 + 1 * 2 - 1 / 3;
            Console.WriteLine(ij);



            //EmployeeMap employee = new EmployeeMap
            //{
            //    Name = "John SMith",
            //    Email = "john@codearsenal.net",
            //    Address = new AddressMap
            //    {
            //        Country = "USA",
            //        City = "New York",
            //        Street = "Wall Street",
            //        Number = 7
            //    },
            //    Position = "Manager",
            //    Gender = true,
            //    Age = 35,
            //    YearsInCompany = 5,
            //    StartDate = new DateTime(2007, 11, 2)
            //};
            //Mapper.Initialize(cfg => cfg.CreateMap<EmployeeMap, EmployeeViewItemMap>()
            //.ForMember(ev => ev.Address,
            //           m => m.MapFrom(a => a.Address.City + ", " +
            //                               a.Address.Street + " " +
            //                               a.Address.Number)
            //          );
            //.ForMember(ev => ev.Gender,
            //            m => m.ResolveUsing<GenderResolver>().FromMember(e => e.Gender))
            //.ForMember(ev => ev.StartDate, m => m.AddFormatter<DateFormatter>());



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

    internal class ConfigurationManager
    {
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
