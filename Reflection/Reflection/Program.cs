using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var asm = Assembly.GetExecutingAssembly();
            Console.WriteLine(asm.FullName);

            foreach(var type in asm.GetTypes())
            {
                Console.WriteLine(type.Name);

                //foreach (var member in type.GetMembers())
                //{
                //    Console.WriteLine(member.Name);
                //}

                foreach (var prop in type.GetFields())
                {
                    Console.WriteLine(prop.Name);
                }
                foreach (var meth in type.GetMethods())
                {
                    if(meth.Name != "Equals" && meth.Name != "GetHashCode" && meth.Name != "GetType" && meth.Name != "ToString")
                    {
                        var o = Activator.CreateInstance(type);
                        meth.Invoke(o, null);
                        Console.WriteLine(meth.Name);
                    }
                }

            }
            Console.ReadLine();
            
        }
    }

    public class Hello
    {
        public string hello = "hello";

        public void IS() {
            Console.WriteLine("Hello");
        }
        public void There()
        {
        }
    }

    public class Anybody
    {

        public Boolean IN = false;
        public string there;
    }
}
