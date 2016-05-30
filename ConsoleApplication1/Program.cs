using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace custommetadata {
    public enum pri { high, medium, low}

}

namespace n1 {
    public class cl1 { }
    class class2
    {
        class class3 { }

    }
}
namespace n2 {
    class cl4 { }
}
namespace ConsoleApplication1
{
    class Pet {
        public virtual void speak() { Console.WriteLine("not impl"); }
    }
    class cat : Pet {
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

        static void worker() {
            while (true) {

                Thread.Sleep(1000);
                Console.WriteLine("wrokig");
                myevent.WaitOne();
            }

        }
        static void Main(string[] args)
        {

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
