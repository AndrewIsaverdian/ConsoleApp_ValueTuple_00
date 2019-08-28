using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesForMyRuntimeLib;

namespace MyDynamicallyLoadedClasses00
{
    public class Class1 : IMethods1
    {
        private string _objectID = "";
        public Class1(string id)
        {
            _objectID = id;
        }

        public string GetObjectID(string comment1)
        {
            return comment1 + ": " + _objectID;
        }

        public bool Pass
        {
            get
            { return true; }
        }
    }

    public class Class2 : Class1, IMethods1
    {
        public Class2(string id) : base(id) { }
    }

    public class Class3 : IMethods1
    {
        public bool Pass => throw new NotImplementedException();

        public string GetObjectID(string comments1)
        {
            throw new NotImplementedException();
        }
    }
}
