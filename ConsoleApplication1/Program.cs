﻿using static System.Math;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using n1;
using System.Runtime.CompilerServices;
using Admin.empty;
using System.Globalization;
using Admin;
using System.IO.IsolatedStorage;
using System.Reflection;
using Admin.Empty;


public class BC : IDisposable
{
    public BC()
    {
        Console.WriteLine("BC created");
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        Console.WriteLine("BC Disposed");
        // TODO: uncomment the following line if the finalizer is overridden above.
        // GC.SuppressFinalize(this);
    }
}
public class DC : BC {
    public DC() : base()
    {
        Console.WriteLine("DC");
    }
    public void Dispose()
    {
        (this as IDisposable).Dispose();
        Console.WriteLine("DC disposed");
    }
}
public interface I_A { }
public interface I_B { }
public class C_C : I_A { }
public class C_D : I_B { }
public class C_E : C_C { }

namespace Admin
{
    namespace Fill
    {
        interface Bin
        {
            void Add();
        }
    }
    namespace Empty
    {
        interface Bin
        {
            void Add();
        }
    }
}
namespace Company
{
    class CompanyWaste : Bin
    {
        void Bin.Add()
        {
            throw new NotImplementedException();
        }
    }
}
namespace CSLibrary
{
    public class Class1 { }
    class Class2
    {
        class Class3 { }
    }
}
namespace NotCSLibrary
{
    class Class4 { }
}
namespace NotInCSLibrary
{
    class Class5 { }
}
namespace custommetadata
{
    public enum pri { high, medium, low }
    //test
}
namespace Admin
{
    //
    //delegate with input as double,output is double
    //extension class / method
    public static class Circle
    {
        public static double circumference(double radius)
        {
            return 2 * radius * PI;
        }
    }

    public class Group
    {
        public int ID { get; set; }
        public int? ParentID { get; set; }
        public List<Group> Children { get; set; }
    }
    public static class GroupEnumerable
    {
        public static IList<Group> BuildTree(this IEnumerable<Group> source)
        {
            var groups = source.GroupBy(i => i.ParentID);
            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();
            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                {
                    AddChildren(roots[i], dict);
                }
            }
            return roots;
        }
        private static void AddChildren(Group node, IDictionary<int, List<Group>> source)
        {
            if (source.ContainsKey(node.ID))
            {
                node.Children = source[node.ID];
                for (int i = 0; i < node.Children.Count; i++)
                {
                    AddChildren(node.Children[i], source);
                }
            }
            else
            {
                node.Children = new List<Group>();
            }
        }
    }
    public abstract class PhoneBase : IPhone
    {
        private bool isOpen;
        private PhoneCall activeCall;
        public PhoneBase()
        {
            isOpen = false;
            activeCall = null;
        }
        bool IPhone.FlipOpen
        {
            set
            {
                isOpen = true;
            }
        }
        void IPhone.FlipClose()
        {
            if (IsConnected())
                this.Disconnect(activeCall);
            isOpen = false;
        }
        public PhoneCall Call(bool IsOpen, bool IsConnected, string phoneNumber)
        {
            if (!IsOpen)
                throw new ApplicationException("Must flip phone open before making a call.");

            if (IsConnected)
                throw new ApplicationException("Unable to make a new call while another call is active.");

            return new PhoneCall(phoneNumber);
        }

        public void Disconnect(PhoneCall activeCall)
        {
            if (activeCall != null) { activeCall.Disconnect(); }
            activeCall = null;
        }

        public bool IsConnected()
        {
            return activeCall != null;
        }

        public bool IsOpen()
        {
            return isOpen;
        }

        public void SaveContact(int contactID, string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }

    public class Phone : PhoneBase
    {
        private bool isOpen;
        private PhoneCall activeCall;
        public void Call(string phoneNumber)
        {
            base.Call(base.IsOpen(), base.IsConnected(), phoneNumber);
        }
        public void Disconnect()
        {
            base.Disconnect(activeCall);
        }
        public void FlipOpen()
        {
            isOpen = true;
        }

        public void FlipClose()
        {
            if (IsConnected())
                Disconnect();
            isOpen = false;
        }

        public Phone()
        {
            isOpen = false;
            activeCall = null;
        }
    }

    public class SmartPhone : PhoneBase
    {
        List<PhoneCall> history;
        Dictionary<int, string> contacts;

        public PhoneCall ActiveCall
        {
            get
            {
                return history.FirstOrDefault(c => c.EndTime == DateTime.MinValue);
            }
        }

        public void Call(string phoneNumber)
        {
            if (IsConnected())
                throw new ApplicationException("Unable to make a new call while another call is active.");

            history.Add(new PhoneCall(phoneNumber));
        }

        public void Call(int contactID)
        {
            if (IsConnected())
                throw new ApplicationException("Unable to make a new call while another call is active.");

            if (!contacts.Keys.Contains(contactID))
                throw new ApplicationException("Unable to locate a contact with that ID.");

            history.Add(new PhoneCall(contacts[contactID]));
        }

        public void Disconnect()
        {
            base.Disconnect(this.ActiveCall);
        }

        public new void SaveContact(int contactID, string phoneNumber)
        {
            contacts.Add(contactID, phoneNumber);
        }

        public SmartPhone()
        {
            history = new List<PhoneCall>();
            contacts = new Dictionary<int, string>();
        }
    }

    public class PhoneCall
    {
        private string phoneNumber;

        public PhoneCall(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public DateTime EndTime { get; internal set; }

        internal void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
    public interface IPhone
    {
        bool FlipOpen { set; }
        PhoneCall Call(bool IsOpen, bool IsConnected, string phoneNumber);
        void Disconnect(PhoneCall activeCall);
        bool IsConnected();
        bool IsOpen();

        void FlipClose();
        void SaveContact(int contactID, string phoneNumber);
    }
    public abstract class Foo
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("do something baes");
        }
    }
    public class Bar : Foo
    {
        public override void DoSomething()
        {
            base.DoSomething();
            Console.WriteLine("do something derived");
        }

    }

    namespace Fill
    {
        interface bin
        {
            void add();
        }
    }
    namespace empty
    {
        interface bin
        {
            void empty();
        }
    }
}
namespace co
{
    class cowaster : bin
    {
        public void empty()
        {
            throw new NotImplementedException();
        }
    }
    struct te
    {
        public int test { get; set; }
        public void t() { }

    }
}
namespace n1
{

    public class A
    {
        protected virtual void m1() { }
        public void m2() { }
    }
    public class B : A
    {
        protected override sealed void m1() { }
    }

    public sealed class C : B
    {
        public void metho() { }
        //public sealed void m2(int par) { }
    }


    [DebuggerDisplay("[{y},{x}]")]
    public class Coordinate
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Coordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public static Coordinate operator *(Coordinate c, int factor)
        {
            return new Coordinate(c.x * factor, c.y * factor);
        }
        public override string ToString()
        {
            return string.Format("{0} , {1}", x, y);
        }
    }


    public enum conn_States
    {
        connecting, discon
    }
    public class Rectange
    {
        public double x1 { get; set; }
        public double x2 { get; set; }
        public float y1 { get; set; }
        public float y2 { get; set; }
        public double Area
        {
            get
            {
                return (x2 - x1) * (y2 - y1);
            }
        }
    }
    class MyTestClass
    {
        private string name;
        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

    }

    public static class Myclass
    {
        static Myclass() { throw new Exception(); }
        public static string MyMethod()
        {
            return "My method";
        }
    }
    public class Account
    {
        public Account()
        {
            Account.checkvalid(20);
        }
        public static void checkvalid(int cust)
        {

        }

    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public static class Myext
    {
        public static void Add(this Point p, Point p1)
        {
            p.X += p1.X;
            p.Y += p1.Y;
        }
    }
    public class Instrument
    {
        public virtual void Playsound()
        {

            Console.WriteLine("silence");
        }
    }
    public class Horn : Instrument
    {
        public override void Playsound()
        {
            Console.WriteLine("Beep");
        }
    }
    public class Drum : Instrument
    {
        public override void Playsound()
        {
            Console.WriteLine("Bang");
        }
    }
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

        static void mymethod(out ushort A, out ushort b)
        {
            A = b = 0;
            try
            {
                A = unchecked((ushort)(A - 10));
            }
            catch (Exception ex)
            {
                Console.WriteLine("cant calc a");
                throw;
            }

            try
            {
                b = checked((ushort)(b - 10));
            }
            catch (Exception ex)
            {
                Console.WriteLine("cant calc v");
                throw;
            }
        }
        static int CountEmployeesByName(string[] namesToSearch)
        {
            using (var context = new NorthwindEntities())
            {
                var queries = new List<IEnumerable<employees_test>>();
                string nameParam;
                foreach (string name in namesToSearch)
                {
                    nameParam = name; //search for employees by name 
                    queries.Add(from e in context.employees_test
                                where e.name.ToUpper().Equals(name.ToUpper(),
                                StringComparison.OrdinalIgnoreCase)
                                select e);

                    queries.Add(from e in context.employees_test
                                where
                                CultureInfo.InvariantCulture.CompareInfo.IndexOf(e.name,
                                nameParam, CompareOptions.IgnoreNonSpace) > -1
                                select e);
                }
                return queries.Sum(q => q.Count());
            }
        }
        static ManualResetEvent MyEvent;
        static void Worker()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine("working");
                MyEvent.WaitOne();
            }
        }
        static void update()
        {
            Console.WriteLine("sun moon stars");
        }
        enum weekoff { sunday = 1, saturday = 2 };

        //static IEnumerable Squares(this int from, int to)
        //{
        //    for (int i = from; i <= to; i++)
        //    {
        //        yield return (int)i * 1;

        //    }

        //}

        static void A_1()
        {
            try { B_1(); }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        static void B_1()
        {
            try { c_1(); }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        static void c_1()
        {
            throw new InvalidOperationException();

        }

        public interface IRiskService
        {
            Task<decimal> GetRisk(decimal homeValue, decimal desiredAmount, decimal loanToValueRatio);
        }
        public class RiskService : IRiskService
        {
            public Task<decimal> GetRisk(decimal homeValue, decimal desiredAmount, decimal loanToValueRatio)
            {
                Task<decimal> returnvalue = Task<decimal>.Factory.StartNew(() => homeValue + desiredAmount + loanToValueRatio);
                return returnvalue;
            }
        }

        public interface IApprovalService
        {
            Task<bool> IsApproved(int homeValue, int amountOwed, int amountDesired);
        }

        public class ApprovalService : IApprovalService
        {
            IRiskService _riskService;
            public ApprovalService()
            {
                this._riskService = new RiskService();
            }
            public ApprovalService(IRiskService riskService)
            {

            }

            public Task<bool> IsApproved(int homeValue, int amountOwed, int amountDesired)
            {
                Task<decimal> _value = this._riskService.GetRisk(homeValue, amountOwed, amountDesired);
                if (_value.Result > 5.0m)
                {
                    return Task<bool>.Factory.StartNew(() => false);
                }
                else
                {
                    return Task<bool>.Factory.StartNew(() => true);
                }
            }
        }

        //static void foo(int i = 0, DateTime dt = DateTime.Now)
        //{
        //    if (i == 0)
        //    {
        //        Console.Write(date)
        //    }
        //}
        delegate int Calc(int m, int n);
        static bool workDone;
        static object locker = new object();
        static void Dowork()
        {
            lock (locker)
            {
                if (!workDone)
                {
                    Console.WriteLine("result");
                    workDone = true;
                }
            }
        }
        public class Test
        {
            public double getresulet()
            {
                return 0;
            }
        }
        abstract class Testa
        {
            public abstract double getres();
        }

        static string Addnumbers(string first, string second)
        {
            int firstint = 0, secondint = 0;
            try
            {
                return Int32.TryParse(first, out secondint).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception");
            }
            return secondint.ToString();
        }

        public class Instrument
        {
            public virtual void Playsound()
            {

                Console.WriteLine("silence");
            }

        }
        public class Horn : Instrument
        {
            public override void Playsound()
            {
                Console.WriteLine("beep");
            }
        }

        public class Drum : Instrument
        {
            new public void Playsound()
            {

                Console.WriteLine("bang");
            }
        }

        struct mystruct
        {
            public int dataint;
            public string datastr;
        }

        static void myfunction(mystruct a)
        {
            a.dataint = 6;
            a.datastr = "six";
        }

        class MyClass
        {
            private static MyClass instance = null;
            private string classValue;
            private MyClass(string newValue) { classValue = newValue; }
            public string Value
            {
                get
                {
                    return classValue;
                }
                set
                {
                    classValue = value;
                }
            }
            public static MyClass NewInstance(string value)
            {
                if (instance == null) instance = new MyClass(value);
                return instance;
            }

        }
        interface iSquare
        {
            int x { get; }
        }
        interface IRectangle
        {
            int X();
        }

        public static class StaticCl
        {
            static StaticCl()
            {
                throw new Exception();
            }
            public static string mymethod()
            {
                return "y sdf";
            }
        }

        static void foo(string s)
        {
            Console.WriteLine("string");
        }
        static void foo(int i)
        {
            Console.WriteLine("integer");
        }
        static void foo(object o)
        {
            Console.WriteLine("object");
        }
        class TextAdder
        {
            public StringBuilder addText(StringBuilder inputString)
            {
                inputString.Append("Text");
                StringBuilder returnValue = new StringBuilder(inputString.ToString());
                inputString = null;
                return returnValue;
            }
        }
        static void foo(int x = 0, int y = 1, string s = "abc")
        {
            Console.WriteLine(x + " " + y + " " + s);
        }
        public static class MyClass1
        {
            static MyClass1()
            {
                throw new Exception();
            }
            public static string MyMethod()
            {
                return "My Method";
            }
        }

        static Func<int, int> X(Func<int, int, int> f)
        {
            Console.WriteLine(f.Method.Name);
            return a => f(a, 4);
        }
        static int Sum(int x, int y)
        {
            return x + y;
        }

        static string AddNumbers(string first, string second)
        {
            int firstint = 0, secondint = 0;
            try
            {
                return Int32.TryParse(first, out secondint).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception");
            }
            return secondint.ToString();
        }

        static void writeoutput(object o)
        {
            if (o == null) Console.WriteLine("null");
            else Console.WriteLine(o.ToString());
        }

        static int solutionMissingInteger(int[] A)
        {
            int solution = 1;
            HashSet<int> hashSet = new HashSet<int>();

            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i] < 1) continue;
                if (hashSet.Add(A[i]))
                {
                    //this int was not handled before
                    while (hashSet.Contains(solution))
                    {
                        solution++;
                    }
                }
            }

            return solution;
        }

        static string solution(string S)
        {
            //Extensions
            List<String> musicEtxn = new List<String>() { ".mp3", ".aac", ".flac" };//Music extension
            List<String> imageEtxn = new List<String>() { ".jpg", ".bmp", ".gif" };//Movie extension
            List<String> movieEtxn = new List<String>() { ".mp4", ".avi", ".mkv" };//Image extension
            List<String> othersEtxn = new List<String>() { ".exe", ".txt", ".zip" };//Others extension

            //size
            int musicSize = 0;
            int movieSize = 0;
            int imageSize = 0;
            int otherSize = 0;

            var finalstr = S.Split('\n');
            foreach (var filestr in finalstr)
            {
                var extn = filestr.LastIndexOf('.');
                var substr = filestr.Substring(extn).Split(' ');
                if (musicEtxn.Contains(substr[0]))
                {
                    musicSize += Convert.ToInt32(Regex.Match(substr[1], @"\d+").Value);
                }
                else if (movieEtxn.Contains(substr[0]))
                {
                    movieSize += Convert.ToInt32(Regex.Match(substr[1], @"\d+").Value);
                }
                else if (imageEtxn.Contains(substr[0]))
                {
                    imageSize += Convert.ToInt32(Regex.Match(substr[1], @"\d+").Value);
                }
                else if (othersEtxn.Contains(substr[0]))
                {
                    otherSize += Convert.ToInt32(Regex.Match(substr[1], @"\d+").Value);
                }
            }
            String finalString = "music " + musicSize + "b\nimages " + imageSize + "b\nmovies " + movieSize + "b\nother " + otherSize + "b";
            Console.WriteLine(finalString);
            return finalString;
        }
        class Pet
        {
            public virtual void speak()
            {
                Console.WriteLine("not implemented");
            }
        }
        class Cat : Pet
        {
            public override void speak()
            {
                Console.WriteLine("Meow");
            }
        }
        class Dog : Pet
        {
            public new void speak()
            {
                Console.WriteLine("woof");
            }
        }
        class Bird : Pet
        {
            public void speak()
            {
                Console.WriteLine("tweet");
            }
        }
        public class Account_Test
        {
            public static void calculate()
            {
                Console.WriteLine("calculate");
            }
            public Account_Test()
            {
                Account_Test.calculate();
            }
        }
        public static class MyClass_Test
        {
            static MyClass_Test()
            {
                throw new Exception();
            }
            public static string MyMethod()
            {
                return "my method";
            }
        }
        static void MyMethod(out ushort A, out ushort B)
        {
            A = B = 0;
            try
            {
                A = unchecked((ushort)(A - 10));
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("cant calculate A");
            }
            try
            {
                B = unchecked((ushort)(B - 10));
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("cant calculate B");
            }
        }

        public class BaseClass
        {
            public virtual void Test()
            {
                Console.WriteLine("From baseclass");
            }
        }

        public class DerivedClass : BaseClass
        {
            public override void Test()
            {
                Console.WriteLine("From derivedclass");
            }
        }
        static void foo_test(int x = 0, int y = 1, string s = "abc")
        {
            Console.WriteLine(x + "" + y + s);
        }


        public static void testmethod()
        {
            throw new ApplicationException("someething wrong");
        }
        static void write_output(object o)
        {
            if (o == null)
            {
                Console.WriteLine("null");
            }
            else
                Console.WriteLine(o.ToString());
        }

        static string Add_Numbers(string first, string second)
        {
            int firstInt = 0, secondInt = 0;
            try
            {
                return Int32.TryParse(first, out secondInt).ToString();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return secondInt.ToString();
        }



        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                EmailHelper.sendEmail("Hello");

                Console.WriteLine(Add_Numbers("1", "tow"));

                double _doubleVal = 10 / 4;
                int _intVal = 10 / 4;
                var resultVal = _doubleVal + _intVal;
                Console.WriteLine(resultVal + " " + resultVal.GetType());


                bool? _a1 = null, _b1 = null;
                write_output(_a1 & _b1);
                write_output(_a1 | _b1);
                _a1 = true;
                write_output(_a1 & _b1);
                write_output(_a1 | _b1);
                _b1 = false;
                write_output(_a1 & _b1);
                write_output(_a1 | _b1);
                Console.Read();

                //DateTime dt1 = new DateTime(2000, 12, 1);
                //DateTime dt2 = new DateTime(2000, 12, 1);
                //object o1 = dt1;
                //dynamic o2 = dt1;
                //Console.WriteLine(dt1 == dt2);
                //Console.WriteLine(dt1.Equals(dt2));
                //Console.WriteLine(o1.Equals(dt1));
                //Console.WriteLine(object.ReferenceEquals(o1, o2));

                System.IO.StreamWriter _file = new StreamWriter(@"c:\test.txt");
                //_file.WriteLine("mytest");
                //_file.Close();
                //_file.Dispose();

                //bool running = true;
                //try
                //{
                //    testmethod(); ;
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    return;
                //}
                //finally
                //{
                //    Console.WriteLine("quitting");
                //    running = false;
                //}
                //Console.WriteLine(string.Format("Running = {0}", running));


                string _s = "\\My Test\\\\";
                int _ii = _s.LastIndexOf(@"\\");

                int _a = 1;
                do
                {
                    _a++;
                    if (_a != 2)
                    {
                        continue;
                    }
                    Console.WriteLine(_a);
                } while (_a < 6);



                foo_test();
                C_C objc = new C_E();
                I_A ia = new C_E();
                I_A iia = new C_C();

                List<String> myCollection = new List<string>();
                myCollection.Add("One");
                myCollection.Add("Two");
                myCollection.Add("Three");
                myCollection.Sort();
                myCollection.Insert(1, "Four");
                myCollection.RemoveAt(2);
                foreach (var item in myCollection)
                {
                    Console.WriteLine(item);
                }
                int? a = null;
                int b = (int)a;


                DerivedClass dc = new ConsoleApplication1.Program.DerivedClass();
                dc.Test();
                BaseClass bc = (BaseClass)dc;
                bc.Test();


                //ushort a = 0, b = 0;
                //MyMethod(out a, out b);
                //Console.WriteLine("A={0}, B={1}", a, b);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            Account_Test acc = new ConsoleApplication1.Program.Account_Test();



            List<Pet> pets = new List<Pet>();
            pets.Add(new Cat());
            pets.Add(new Dog());
            pets.Add(new Bird());


            foreach (Pet _p in pets)
            {
                _p.speak();
            }


            string[] _colors = { "House", "Room", "Building", "Street" };
            var _output = _colors.Max(x => x.Length);


            UInt16 indata = 0xFFFF;
            byte[] bytes = BitConverter.GetBytes(indata);
            Int32 outdata = BitConverter.ToInt16(bytes, 0);

            //Int32 myint32 = 123;
            //double mydouble = 123;
            //decimal mydecimal = 123;
            //UInt16 unit16 = 123;
            //byte mybyte = 123;

            //mydecimal = mybyte;
            //mydouble = mydecimal;
            //myint32 = unit16;
            //mydouble = myint32;
            //myint32 = mydouble;




            Assembly sample;
            var c1 = new CSLibrary.Class1();
            sample = Assembly.GetAssembly(c1.GetType());
            var types = sample.GetTypes();
            foreach (Type t_x in types)
            {
                Console.WriteLine(t_x);
            }



            try
            {
                try
                {
                    int x = 0;
                    int y = 5 / x;

                }
                catch (DivideByZeroException dex)
                {
                    Console.WriteLine("caught inner divide by zero ex");
                }
                catch (Exception exi)
                {
                    Console.WriteLine("caught inner ex");
                }

            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine("caught outer divide by zero ex");
            }
            catch (Exception exi)
            {
                Console.WriteLine("caught outer ex");
            }
            Console.Read();



            try
            {
                string test_1 = "abc";
                string test_2 = "def";
                test_1 = test_1 + test_2;

                //Test String
                String myString = "my.song.mp3 11b\n" +
                        "greatSong.flac 1000b\n" +
                        "not3.txt 5b\n" +
                        "video.mp4 200b\n" +
                        "game.exe 100b\n" +
                        "mov!e.mkv 10000b";
                myString = "my.song.mp3 11b\ngreatSong.flac 1000b\nnot3.txt 5b\nvideo.mp4 200b\ngame.exe 100b\nmov!e.mkv 10000b";
                solution(myString);

                var arr = new int[] { 1, 3, 6, 4, 1, 2 };
                Console.WriteLine(solutionMissingInteger(arr));



                int[][] array1 = new int[][] {
                    new int[] { 1,1,1 },
                    new int[] {1,1,2},
                    new int[] {  2,2,3},
                    new int[] {2,2,2}
                };
                try
                {
                    for (int icount = 0; icount < array1[0].Length; icount++)
                    {
                        for (int jcount = 0; jcount < array1.Length; jcount++)
                        {
                            if (array1[icount][jcount] == 2)
                            {
                                continue;
                            }
                            else if (array1[icount][jcount] == 3)
                            {
                                break;
                            }
                            Console.Write("{0} , {1}", icount, jcount);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().ToString());
                }






                bool? ax_bx = null, bx_yb = null;
                writeoutput(ax_bx & bx_yb);
                writeoutput(ax_bx | bx_yb);
                ax_bx = true;
                writeoutput(ax_bx & bx_yb);
                writeoutput(ax_bx | bx_yb);
                bx_yb = false;
                writeoutput(ax_bx & bx_yb);
                writeoutput(ax_bx | bx_yb);

                Console.ReadLine();




                Console.WriteLine(Addnumbers("1", "Two"));
                String mystring = "New York";
                mystring.ToUpper();
                mystring.ToLowerInvariant();
                mystring += "er";
                Console.WriteLine(mystring);


                double doubleVal1 = 10 / 4;
                int intVal1 = 10 / 4;

                var resultVal = doubleVal1 + intVal1;
                Console.WriteLine(resultVal + " " + resultVal.GetType());


                Func<int, int> f = X(Sum);
                var re = f(5);
                Console.WriteLine(re);

                Console.WriteLine(MyClass1.MyMethod());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
            }



            foo();

            int a_xs = 1, b_xs = 2;
            if (++a_xs == 1)
            {
                Console.WriteLine(a_xs++ + b_xs * 2);
            }
            else
            {
                Console.WriteLine(a_xs-- * b_xs);
            }

            try
            {

                List<String> mycollection = new List<string>();
                mycollection.Add("One");
                mycollection.Add("Two");
                mycollection.Add("Three");
                mycollection.Sort();
                mycollection.Insert(1, "Four");
                mycollection.RemoveAt(2);
                foreach (String nextItem in mycollection)
                {
                    Console.Write(nextItem);
                }




                int? a_x = null;
                int b = (int)a_x;

                StringBuilder text1 = new StringBuilder("John");
                StringBuilder text2 = new TextAdder().addText(text1);
                Console.WriteLine(text2);
                Console.WriteLine(text1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().ToString());
            }


            object x_x = "string";
            foo(x_x);
            dynamic y_y = "String";
            foo(y_y);


            string st_s = "\\My Test\\\\";
            int i_s = st_s.LastIndexOf(@"\\");
            Console.WriteLine(i_s);


            try
            {
                Console.WriteLine(StaticCl.mymethod());
            }
            catch (Exception ex1)
            {
                Console.Write(ex1.GetType().ToString());
            }



            int? a_1 = null;
            int b_1 = (int)a_1;


            int temp_a = 1;
            do
            {
                temp_a++;
                if (temp_a != 2)
                {
                    continue;
                }
                Console.WriteLine(temp_a);

            } while (temp_a < 6);





            double doubleVal = 10 / 4;
            int intVal = 10 / 4;
            var resultval = doubleVal + intVal;
            Console.WriteLine(resultval + " " + resultval.GetType());




            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();
            IsolatedStorageFileStream userSTream = new IsolatedStorageFileStream("Mydomain.john",
                System.IO.FileMode.Create, userStore);
            StreamWriter userwriter = new StreamWriter(userSTream);
            userwriter.Write("red/write");
            userwriter.Close();

            for (int counter = 0; counter < 3; counter++)
            {
                System.IO.StreamWriter sw = new StreamWriter("c:\\test_f.txt", true, Encoding.ASCII);
                sw.Write("line:");
                sw.WriteLine(counter);
                sw.Close();
            }





            object[] array = new string[10];
            array[0] = 10;


            //mystruct struct_my;
            //struct_my.dataint = 5;
            //struct_my.datastr = "five";
            //myfunction(struct_my);
            //Console.WriteLine(struct_my);




            Instrument i11 = new Horn();
            Instrument i22 = new Drum();
            i11.Playsound();
            i22.Playsound();
            Console.WriteLine(Addnumbers("1", "tow"));
            int[] data1 = { 1, 2, 3 };
            var rs = from x in data1 select x;
            Console.WriteLine(rs);


            new Thread(Dowork).Start();
            Dowork();

            try
            {
                A_1();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

            }



            var _vl = new List<int>();
            _vl.Add(1);
            _vl.Add(5);
            _vl.Add(15);
            _vl.Add(11);

            var _query_Re = from i_val in _vl
                            where i_val > 10
                            select i_val;
            _vl[1] = 20;
            foreach (var item in _query_Re)
            {
                Console.WriteLine(item);
            }

            string s_c = "collect";
            foreach (char item in s_c)
            {
                if (s_c.IndexOf(item) == 2)
                {
                    Console.WriteLine("*");
                }
                else
                {
                    Console.WriteLine(item);

                }
            }



            Calc c_l = new Calc((n, m) => n + m);
            c_l += new Calc((n, m) => n * m);
            Console.WriteLine(c_l(c_l(2, 5), 4));


            int ijk_u = 0;
            ijk_u *= 1 + 1 * 2 - 1 / 3;
            Console.WriteLine(ijk_u);
            weekoff woff = weekoff.saturday;
            woff = (weekoff)5;
            Console.WriteLine(woff.ToString());

            Thread th = new Thread(new ThreadStart(update));
            th.Start();

            foreach (Match m in Regex.Matches("Ninety Six Thousand and Ninety Stars", @"\bN\S*"))
            {
                Console.WriteLine(m.Value);
                Console.ReadKey();

            }


            int _count = 0;
            int _i = 0;
            try
            {
                _count++;
                _count = _count / _i;
                _count++;
            }
            catch (Exception ex) { }
            _count++;
            Console.WriteLine(_count.ToString());




            MyEvent = new ManualResetEvent(true);
            ThreadStart mythr = new ThreadStart(worker);
            Thread myth = new Thread(mythr);
            myth.Start();
            Console.ReadKey();




            String t_1 = "abc";
            String t_2 = "def";
            t_1 = t_1 + t_2;
            Console.WriteLine(t_1);

            Console.WriteLine(String.Concat(t_1, t_2));


            try
            {
                try
                {
                    int x = 0;
                    int y = 5 / x;

                }
                catch (DivideByZeroException exp)
                {
                    Console.WriteLine("inner divide by zero");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("inner ");
                    throw;
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("inner divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine("outer");
            }
            int xxx = 10;
            int? yyy = 20;
            int? zzz = null;
            Console.WriteLine(xxx + zzz ?? yyy);

            var flatList = new List<Admin.Group>() {
                new Admin.Group() { ID = 1, ParentID = null },    // root node
                new Admin.Group() { ID = 2, ParentID = 1 },
                new Admin.Group() { ID = 3, ParentID = 1 },
                new Admin.Group() { ID = 4, ParentID = 3 },
                new Admin.Group() { ID = 5, ParentID = 4 },
                new Admin.Group() { ID = 6, ParentID = 4 }
            };

            var tree = flatList.BuildTree();

            List<string> listtest = new List<string>() { "10", "20" };
            Dictionary<String, List<string>> dictst = new Dictionary<String, List<string>>()
            {
                { "a",listtest},
            };


            int ans = 5;
            ans += 9;
            ans *= 3;
            try
            {
                using (var context = new NorthwindEntities())
                {
                    var temp1 = context.employees_test;
                    var temp2 = temp1.Take(30).Select(x => x.uniqueEmployeesId);
                    var temp3 = temp1.ToList();
                    var temp4 = temp1.Count();
                    var temp5 = temp4 + temp2.Count();
                }



                double doubleva = 10 / 4;
                int intv = 10 / 4;
                var re = doubleva + intv;
                Console.Write(re + "" + re.GetType());

                var src_dir = @"C:\usha";
                var tar_dir = @"C:\vamsi\test";
                string[] files = Directory.GetFiles(src_dir);
                Directory.CreateDirectory(tar_dir);
                foreach (var item in files)
                {

                }

                n1.Coordinate c_1 = new n1.Coordinate(100, 200);
                c_1 *= 2;

                Console.WriteLine(c_1);


                String m1 = "One";
                String m2 = "One";
                StringBuilder sb1 = new StringBuilder("One");
                StringBuilder sb2 = new StringBuilder("One");

                List<Object> lst_a = new List<object>();
                lst_a.Add(m1);
                lst_a.Add(sb1);

                Console.WriteLine(lst_a.Contains(m2));
                Console.WriteLine(lst_a.Contains(sb2));
                Console.WriteLine(lst_a.Contains(m2.ToString()));

                String mytest_1 = "New York";
                mytest_1.ToUpper();
                mytest_1.ToLowerInvariant();
                mytest_1.Clone();
                mytest_1 += "er";
                Console.WriteLine(mytest_1);

                ushort a = 0, b = 0;
                mymethod(out a, out b);
                Console.WriteLine("A={0},B={1}", a, b);
                System.IO.StreamWriter s1 = new StreamWriter(@"c:\t.txt");
                s1.WriteLine("test");
                s1.Close();
                s1.Dispose();

                n1.MyTestClass mc = new n1.MyTestClass();
                //mc.Name = "tet";
                Console.WriteLine(mc.Name);



                var source = Enumerable.Range(1, 20000);
                var results = from num in source.AsParallel()
                              where num % 10 == 0
                              orderby num
                              select num;
                var count_test = 0;
                results.ForAll((e) => Console.WriteLine(e + " " + count_test++));


                try
                {
                    Console.WriteLine(n1.Myclass.MyMethod());
                }
                catch (Exception ex11)
                {
                    Console.WriteLine(ex11.GetType().ToString());
                }



                string data_t = "12dewe123ffg4565";
                var stringquery = from ch in data_t
                                  where char.IsDigit(ch)
                                  select ch;
                Console.WriteLine(stringquery.Count());


                //int? aaatemp = null;
                //int b = (int)A;
                Int32 mydata = 0x0000FFFF;
                mydata = mydata >> 4;
                mydata = mydata << 4;

                mydata = mydata | 0x0000FFFF;
                mydata = mydata ^ 0x55555555;

                n1.Point p = new n1.Point() { X = 100, Y = 200 };
                Myext.Add(p, new n1.Point() { X = 100, Y = 200 });

                //n1.Instrument i111 = new Horn();
                //n1.Instrument i211 = new Drum();
                //i111.Playsound();
                //i211.Playsound();


                // AppDomain appdom = AppDomain.CreateDomain("");
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


            //Employee employee = new Employee();
            //employee.Initialize(500);
            //employee.Manager.Name = "";

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

            //List<Pet> lst = new List<Pet>();
            //lst.Add(new cat());
            //lst.Add(new dog());
            //lst.Add(new bird());
            //foreach (var item in lst)
            //{
            //    item.speak();

            //}
            //Console.WriteLine();

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
