using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Patterns
{
    //http://www.viva64.com/en/b/0437/
    class Root
    {
        public volatile static Root StaticRoot = null;
        public Nested Nested = null;

        ~Root()
        {
            Console.WriteLine("Finalization of Root");
            StaticRoot = this;
        }
    }
    class Nested
    {
        public void DoSomeWork()
        {
            Console.WriteLine(String.Format(
                "Thread {0} enters DoSomeWork",
                Thread.CurrentThread.ManagedThreadId));
            Thread.Sleep(2000);
            Console.WriteLine(String.Format(
                "Thread {0} leaves DoSomeWork",
                Thread.CurrentThread.ManagedThreadId));
        }
        ~Nested()
        {
            Console.WriteLine("Finalization of Nested");
            DoSomeWork();
        }
    }

    class DisposePattern
    {
        static void CreateObjects()
        {
            Nested nested = new Nested();
            Root root = new Root();
            root.Nested = nested;
        }
        static void Main(string[] args)
        {
            CreateObjects();
            GC.Collect();
            while (Root.StaticRoot == null) { }
            Root.StaticRoot.Nested.DoSomeWork();
            Console.ReadLine();
        }
    }
}
