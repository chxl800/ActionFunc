using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionFunc
{
    public class ActionAndFunc
    {
        public static void TestActionAndFunc()
        {


            #region Func委托 

            ///Func<TResult>的用法 
            ///这里TResult代表函数的返回值类型 
            ///只能代理返回值为TResult类型的无参函数 
            Func<string> func = delegate ()
            {
                return "我是Func<TResult>委托出来的结果";
            };
            Console.WriteLine(func());
            Console.ReadKey();

            ///Func<T,TResult>的用法 
            ///这里的T为代理的函数的传入类型,TResult代表函数的返回值类型 
            ///只能代理参数为T类型,返回值为TResult类型的函数 
            Func<string, string> funcOne = delegate (string s)
            {
                return s.ToUpper();
            };
            Console.WriteLine(funcOne("我是Func<T,TResult>委托出来的结果"));
            Console.ReadKey();

            ///Func<T1,T2,TResult>的用法 
            ///这里T1,T2为代理的函数的传入类型,TResult代表函数的返回值类型 
            ///只能代理参数为T1,T2类型,返回值为TResult类型的函数 
            Func<string, string, string> funcTwo = delegate (string value1, string value2)
            {
                return value1 + " " + value2;
            };
            Console.WriteLine(funcTwo("我是", "Func<T1,T2,TResult>委托出来的结果"));
            Console.ReadKey();

            /*************余下的类似上面的这种操作,最多可以接受四个传入参数*************** 
             *delegate TResult Func<TResult>();   
             *delegate TResult Func<T1,TResult>(T1 arg1); 
             *delegate TResult Func<T1,T2,TResult>(T1 arg1, T2 arg2); 
             *delegate TResult Func<T1,T2,T3,TResult>(T1 arg1, T2 arg2, T3 arg3); 
             *delegate TResult Func<T1,T2,T3,T4,TResult>T1 arg1, T2 arg2, T3 arg3, T4 arg4); 
             */

            #endregion

            #region Action的用法 
            ///Action<T>的用法 
            ///这里的T为代理函数的传入类型,无返回值 
            Action<string[]> action = delegate (string[] x)
            {
                var result = from p in x
                             where p.Contains("s")
                             select p;
                foreach (string s in result.ToList())
                {
                    Console.WriteLine(s);
                }
            };
            string[] str = { "charlies", "nancy", "alex", "jimmy", "selina" };
            action(str);
            Console.ReadKey();

            /***************余下的类似上面的这种操作,最多可以接受四个传入参数********** 
             * delegate void Action(); 无参,无返回值 
             * delegate void Action<T>(T1 arg1); 
             * delegate void Action<T1,T2>(T1 arg1, T2 arg2); 
             * delegate void Action<T1,T2,T3>T1 arg1, T2 arg2, T3 arg3); 
             * delegate void Action<T1,T2,T3,T4>T1 arg1, T2 arg2, T3 arg3, T4 arg4); 
             */

            #endregion

            #region Predicate 
            ///bool Predicate<T>的用法 
            ///输入一个T类型的参数,返回值为bool类型 
            Predicate<string[]> predicate = delegate (string[] x)
            {
                var result = from p in x
                             where p.Contains("s")
                             select p;
                if (result.ToList().Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            string[] _value = { "charlies", "nancy", "alex", "jimmy", "selina" };
            if (predicate(_value))
            {
                Console.WriteLine("They contain.");
            }
            else
            {
                Console.WriteLine("They don't contain.");
            }
            Console.ReadKey();

            #endregion


        }
    }
}
