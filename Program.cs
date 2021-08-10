using Nito.AsyncEx;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            #region lock 同步锁
            //Thread[] threads = new Thread[100];
            //Program acc = new Program(10);
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    Thread t = new Thread(new ThreadStart(acc.DoTransactions));
            //    threads[i] = t;
            //}
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i].Start();
            //}
            #endregion
            #region AsyncLock 异步锁
            //Program acc = new Program(100);//通过构造函数给变量赋值，相当于100红包
            //Thread[] threads = new Thread[100];//创建100个线程模拟100人抢100元红包
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    Thread t = new Thread(() =>
            //    {
            //        DoTransactions("线程" + i + ":").Wait();
            //    });
            //    threads[i] = t;
            //}
            //for (int i = 0; i < threads.Length; i++)//开启线程
            //{
            //    threads[i].Start();
            //}
            #endregion
            #region 事务
            Method1();
            Method2();
            #endregion
            Console.Read();
        }
        #region lock 同步锁
        //int balance;
        //Random r = new Random();
        //public Program(int initial)
        //{
        //    balance = initial;
        //}

        //void Withdraw(int amount)
        //{
        //    lock (this)
        //    {
        //        if (balance == 0)
        //        {
        //            Console.WriteLine("以抢完！");
        //            throw new Exception("以抢完!");
        //        }
        //        else
        //        {
        //            Console.WriteLine("抢之前:  " + balance);
        //            Console.WriteLine("抢到数据: -" + amount);
        //            balance = balance - amount;
        //            Console.WriteLine("抢之后:  " + balance);
        //            Console.WriteLine();
        //        }

        //    }
        //}

        //public void DoTransactions()
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        Withdraw(1);
        //    }
        //}
        #endregion
        #region AsyncLock 异步锁
        //static int balance;

        //public Program(int initial)
        //{
        //    balance = initial;
        //}
        //public static AsyncLock asyncLock = new AsyncLock();
        //public static async Task<string> Withdraw(string name, int amount)
        //{
        //    using (await asyncLock.LockAsync())
        //    {
        //        if (balance <= 0)
        //        {
        //            Console.WriteLine(name + "没有抢到红包已经抢完！");
        //        }
        //        else
        //        {
        //            if (balance< amount)
        //            {
        //                amount = balance;
        //                balance = 0;
        //                Console.WriteLine(name + "抢到" + amount + "元，红包剩余:" + balance);
        //            }
        //            else
        //            {
        //                balance = balance - amount;
        //                Console.WriteLine(name + "抢到" + amount + "元，红包剩余:" + balance);
        //            }
                    
        //        }
        //        return  "";
        //   }

        //}
        //public static async Task<string> DoTransactions(string name)
        //{
        //    Random r = new Random();
        //    int a = r.Next(1, 10);
        //    await Withdraw(name, a);
        //    return "";
        //}
        #endregion
        #region 事务
        /// <summary>
        /// 这个Attribute就是使用时候的验证，把它添加到需要执行事务的方法中，即可完成事务的操作。
        /// </summary>
        [AttributeUsage(AttributeTargets.Method, Inherited = true)]
        public class UseTranAttribute : Attribute
        {

        }

        
        public static int Method1()
        {
            //写个新增
            return 0;
           
        }
        [UseTran]
        public static int Method2()
        {
            //写个新增
            return 0;
            throw new Exception("出现异常");
        }
        #endregion
    }
}
