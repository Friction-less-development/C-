using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 1; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine(i);
            }
            watch.Stop();
            long firstElapsed = watch.ElapsedMilliseconds;
            watch = System.Diagnostics.Stopwatch.StartNew();
            Parallel.For(1, 100, (i) => {
                Thread.Sleep(10);
                Console.WriteLine(i);
            }
            );
            watch.Stop();
            long secondElapsed = watch.ElapsedMilliseconds;

            Console.Clear();
            Console.WriteLine("Single thread time: {0}, Multi thread time: {1}", firstElapsed, secondElapsed);

            Random rand = new Random(DateTime.Now.Millisecond);
            var task1 = Task.Factory.StartNew(() => EscapeMaze(rand)).ContinueWith((prev) => Console.WriteLine("First hamster escaped"));
            var task2 = Task.Factory.StartNew(() => EscapeMaze(rand)).ContinueWith((prev) => Console.WriteLine("Second hamster escaped"));

            Console.WriteLine("Which hamster will get out of the maze first?");

            Console.ReadLine();
        }

        static bool EscapeMaze(Random rand)
        {
            int i = 0;

            do
            {
                Thread.Sleep(10);
                i = rand.Next(0, 1000);
            } while (i != rand.Next(0, 1000));
            return true;
        }
    }
}
