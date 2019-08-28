using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttributes_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(MyClass);
            object[] AttArr = t.GetCustomAttributes(false);
            foreach (Attribute a in AttArr)
            {
                MyAttributeAttribute attr = a as MyAttributeAttribute;
                if (null != attr)
                {
                    Console.WriteLine($"Description : { attr.Description }");
                    Console.WriteLine($"Version Number : { attr.VersionNumber }");
                    Console.WriteLine($"Reviewer ID : { attr.ReviewerID }");
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MyAttributeAttribute : System.Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public string ReviewerID { get; set; }
        public MyAttributeAttribute(string desc, string ver)
        {
            Description = desc;
            VersionNumber = ver;
        }
    }
    [MyAttribute("Check it out", "2.4")]
    class MyClass
    {
    }
}
