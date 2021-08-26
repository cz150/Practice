using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

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
            //Method1();
            //Method2();
            #endregion
            #region Log编辑记录
            //Data data1 = new Data { Id = 3, Name = "程哲", Age = 20, Set = 1 };//新值
            //Data data2 = new Data { Id = 3, Name = "张飞", Age = 25, Set = 0 };//旧值 
            //var da = new LogContrast<Data>();
            //var dat=da.DataComparison(data1,data2,data1.Id,44);
            //foreach (var item in dat)
            //{
            //    Console.WriteLine("编辑项:"+item.EditItem+"  新值:"+item.Newvalue+"  旧值:"+item.Oldvalue+"    Id:"+item.Id+"  用户Id:"+item.UserId+"    编辑时间:"+item.EditTime);
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //Data data3 = new Data { Id = 4, Name = "韩信", Age = 25, Set = 1 };//新值
            //Data data4 = new Data { Id = 4, Name = "张良", Age = 25, Set = 1 };//旧值 
            //var dat1 = da.DataComparison(data3, data4, data3.Id, 44);
            //foreach (var item in dat1)
            //{
            //    Console.WriteLine("编辑项:" + item.EditItem + "  新值:" + item.Newvalue + "  旧值:" + item.Oldvalue + "    Id:" + item.Id + "  用户Id:" + item.UserId + "    编辑时间:" + item.EditTime);
            //}
            #endregion

            //decimal a = 1.17M;
            //var b = string.Format("{0:N}", a);
            //var c = Convert.ToDecimal(b);
            //Console.WriteLine(c);

            //stu a = new stu()
            //{
            //    id = 1, todecimal = 1.277M
            //};
            //Console.WriteLine(a.todecimal);

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
        ///// <summary>
        ///// 这个Attribute就是使用时候的验证，把它添加到需要执行事务的方法中，即可完成事务的操作。
        ///// </summary>
        //[AttributeUsage(AttributeTargets.Method, Inherited = true)]
        //public class UseTranAttribute : Attribute
        //{

        //}


        //public static int Method1()
        //{
        //    //写个新增
        //    return 0;

        //}
        //[UseTran]
        //public static int Method2()
        //{
        //    //写个新增
        //    return 0;
        //    throw new Exception("出现异常");
        //}
        #endregion
        #region Log编辑记录
        public class Data
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Set { get; set; }
        }
        public class LogContrast<T>
        {
            /// <summary>
            /// 编辑数据对比
            /// </summary>
            /// <param name="Newvalue">新值</param>
            /// <param name="Oldvalue">旧址</param>
            /// <param name="Id"></param>
            /// <param name="UserId"></param>
            /// <returns></returns>
            public List<EditRecord> DataComparison(object Newvalue, object Oldvalue, int Id, int UserId)
            {
                Type type = Newvalue.GetType();
                PropertyInfo[] pis = type.GetProperties();
                Type type1 = Oldvalue.GetType();
                PropertyInfo[] pis1 = type1.GetProperties();
                List<EditRecord> logs = new List<EditRecord>();
                for (int i = 0; i < pis.Length; i++)
                {
                    for (int j = 0; j < pis1.Length; j++)
                    {
                        if (pis[i].Name == pis1[j].Name)
                        {
                            if (pis[i].GetValue(Newvalue) is not null && pis1[j].GetValue(Oldvalue) is not null)
                            {
                                if (pis[i].GetValue(Newvalue).ToString() != pis1[j].GetValue(Oldvalue).ToString())
                                {
                                    EditRecord log = new EditRecord();
                                    log.Newvalue = pis[i].GetValue(Newvalue).ToString();
                                    log.Oldvalue = pis1[j].GetValue(Oldvalue).ToString();
                                    log.EditTime = DateTime.Now;
                                    log.UserId = UserId;
                                    log.EditItem = pis[i].Name;
                                    log.Id = Id;
                                    logs.Add(log);
                                }
                            }
                            else if (pis[i].GetValue(Newvalue) is null && pis1[j].GetValue(Oldvalue) is null)
                            {
                                continue;
                            }
                            else if (pis[i].GetValue(Newvalue) is null && pis1[j].GetValue(Oldvalue) is not null)
                            {
                                EditRecord log = new EditRecord();
                                log.Newvalue = "/";
                                log.Oldvalue = pis1[j].GetValue(Oldvalue).ToString();
                                log.EditTime = DateTime.Now;
                                log.UserId = UserId;
                                log.EditItem = pis[i].Name;
                                log.Id = Id;
                                logs.Add(log);
                            }
                            else if (pis[i].GetValue(Newvalue) is not null && pis1[j].GetValue(Oldvalue) is null)
                            {
                                EditRecord log = new EditRecord();
                                log.Newvalue = pis[i].GetValue(Newvalue).ToString();
                                log.Oldvalue = "/";
                                log.EditTime = DateTime.Now;
                                log.UserId = UserId;
                                log.EditItem = pis[i].Name;
                                log.Id = Id;
                                logs.Add(log);
                            }
                        }
                    }
                }
                return logs;
            }
        }
        /// <summary>
        /// 编辑记录
        /// </summary>
        public class EditRecord
        {
            /// <summary>
            /// 编辑数据Id
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 编辑项
            /// </summary>
            public string EditItem { get; set; }
            /// <summary>
            /// 旧址
            /// </summary>
            public string Oldvalue { get; set; }
            /// <summary>
            /// 新值
            /// </summary>
            public string Newvalue { get; set; }
            /// <summary>
            /// 编辑人Id
            /// </summary>
            public int UserId { get; set; }
            /// <summary>
            /// 编辑时间
            /// </summary>
            public DateTime EditTime { get; set; }
        }
        #endregion
    }

    public class stu
    {
        

        public int id { get; set; }

        public decimal todecimal { get => todecimal; set { Convert.ToDecimal(string.Format("0:N", this.todecimal)); } }
        
    }
}
