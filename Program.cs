using System;
using System.Threading;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10000];
            Program acc = new Program(10);
            for (int i = 0; i < threads.Length; i++)
            {
                Thread t = new Thread(new ThreadStart(acc.DoTransactions));
                threads[i] = t;
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Start();
            }

        }
        int balance;

        Random r = new Random();

        public Program(int initial)
        {
            balance = initial;
        }

        void Withdraw(int amount)
        {
            lock (this)
            {
                if (balance == 0)
                {
                    Console.WriteLine("以抢完！");
                    throw new Exception("以抢完!");
                }
                Console.WriteLine("抢之前:  " + balance);
                Console.WriteLine("抢到数据: -" + amount);
                balance = balance - amount;
                Console.WriteLine("抢之后:  " + balance);
                Console.WriteLine();
            }
        }

        public void DoTransactions()
        { 
            for (int i = 0; i < 10; i++)
            {
                Withdraw(1);
            }
        }
    }
}
