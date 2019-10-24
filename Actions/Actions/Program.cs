using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actions
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int> log = obj => { Console.WriteLine(obj); };
            log(123);

            var player1 = new User();
            player1.Click += () => Console.WriteLine("The user clicked");
            player1.SendClick();

            Console.ReadLine();
        }
    }

    public delegate void ClickEventHandler();
    class User
    {
        public event ClickEventHandler Click;

        public void SendClick()
        {
            Click();
        }
    }
}
