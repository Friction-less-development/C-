using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTypes
{
    class ObscuredInformation<T>
    {
        public T Header { get; set; }
        public T Body { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ObscuredInformation<int> oi = new ObscuredInformation<int>();
            oi.Header = 3;
            oi.Body = 34;
            Log(oi);
            
            //Nonsense.
            ObscuredInformation < ObscuredInformation<int> > ooii = new ObscuredInformation<ObscuredInformation<int>>();
            ooii.Header = new ObscuredInformation<int>();
            ooii.Body = new ObscuredInformation<int>();
            ooii.Header.Header = 6;
            ooii.Header.Body = 66;
            ooii.Header.Body = 999;
            ooii.Body.Body = 68;
            Log(ooii);
            Console.ReadLine();

        }

        private static void Log<T>(ObscuredInformation<T> obj){
            Console.WriteLine(obj.Header);
            Console.WriteLine(obj.Body);
        }
    }
}
