using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideInheritance
{
    interface IFoo
    {
        void foo();
    }

    class Foo
    {
        public void foo()
        {

        }
    }

    internal class FooWithInterface : Foo, IFoo
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            var f = new FooWithInterface();
            f.foo();
        }
    }
}
