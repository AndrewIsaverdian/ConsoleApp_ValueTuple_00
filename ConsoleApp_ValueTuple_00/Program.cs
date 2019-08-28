using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ValueTuple_00
{
    class Program
    {
        static void Main(string[] args)
        {

            var result = DoStuff(Enumerable.Range(0, 10));
            Console.WriteLine($"Sum: {result.Sum}, Count: {result.Count}");

            int? x1 = OutParameterSampleMethod("2");
            int? x2 = OutParameterSampleMethod("aaa");
            int? x3 = (x2 == null) ? x2 : (x2 * 3);
            int x4 = (x2 ?? 0) * 5;
            Console.WriteLine($"x1: {x1}, x2: {x2}");

            Console.WriteLine("\n------------------------------------");
            A1 a1 = new A1("aaa");
            A2 a2 = new A2(2);
            object obj1 = null;

            DisplayID(a1);
            DisplayID(a2);
            DisplayID(obj1);

            //Optional Function Parameters Example
            MyOptExample();
            MyOptExample("ccc");
            MyOptExample("bbb", "ccc");
            MyOptExample("aaa", "bbb", "ccc");
        }

        public static (int Sum, int Count) DoStuff(IEnumerable<int> values)
        {
            var res = (sum: 0, count: 0);
            foreach (var value in values)
            {
                res.sum += value;
                res.count++;
            }

            return res;
        }

        public static int? OutParameterSampleMethod(string input)
        {
            if (!int.TryParse(input, out int result))
            {
                return null;
            }
            return result;
        }

        public static void DisplayID(object myObj)
        {
            switch (myObj)
            {
                case A1 a1:
                    Console.WriteLine($"This is A1 ID = {a1.ID}");
                    break;
                case A2 a2:
                    Console.WriteLine($"This is A2 ID = {a2.ID}");
                    break;
                case null:
                    Console.WriteLine($"Object is Null");
                    break;
                default:
                    Console.WriteLine($"This is Default ID");
                    break;
            }
        }

        static void MyOptExample(string arg1 = "111", string arg2 = "222", string arg3 = "333")
        {
            Console.WriteLine($"\nIn MyOptExample arg1: {arg1}, arg2: {arg2}, arg3: {arg3}");
        }
    }
    class A1
    {
        string _id = "";

        public A1(string id)
        {
            _id = id;
        }
        public string ID
        {
            get
            {
                return _id;
            }
        }
    }
    class A2
    {
        int _id = -1;

        public A2(int id)
        {
            _id = id;
        }
        public int ID
        {
            get
            {
                return _id;
            }
        }
    }
}


