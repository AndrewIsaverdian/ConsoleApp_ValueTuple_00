using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using InterfacesForMyRuntimeLib;

namespace MyLoadingDLLatRuntime00
{
    class Program
    {
        static void Main(string[] args)
        {
            string appStartPath = AppDomain.CurrentDomain.BaseDirectory;
            var DLL = Assembly.LoadFile(appStartPath + "MyDynamicallyLoadedClasses00.dll");

            var class1Type1 = DLL.GetType("MyDynamicallyLoadedClasses00.Class1", true);
            var class1Type2 = DLL.GetType("MyDynamicallyLoadedClasses00.Class2", true);

            //Now you can use reflection or dynamic to call the method. I will show you the dynamic way
            object[] inputParam = { "111" };

            dynamic obj1 = Activator.CreateInstance(class1Type1, inputParam);
            IMethods1 iObj1 = obj1;

            dynamic obj2 = Activator.CreateInstance(class1Type2, inputParam);
            IMethods1 iObj2 = obj2;

            Console.WriteLine(obj1.GetObjectID("object 1 ID"));
            Console.WriteLine(iObj1.GetObjectID("iObject 1 ID"));
            bool x1 = iObj1.Pass;

            Console.WriteLine(obj2.GetObjectID("object 2 ID"));
            Console.WriteLine(iObj2.GetObjectID("iObject 2 ID"));
            bool x2 = iObj2.Pass;


            Console.ReadLine();
        }

        public T CreateInstance<T>(params object[] paramArray)
        {
            return (T)Activator.CreateInstance(typeof(T), args: paramArray);
        }
    }

}
