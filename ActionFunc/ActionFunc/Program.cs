using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionFunc
{

    //Action与Func作用几乎一样，没返回值

    //Func 是.net内置泛型委托 ，有返回值
    static class Program
    {
        static void Main(string[] args)
        {
 

            //1 func 简单Lambda用法
            Func<int> f1 = () => { 
                return 10;
            };
            Console.WriteLine("f1"+f1());

            //2 func 简单Lambda用法2 
            Func<string, int, string> f2 = (x, y) =>
            {
                return x + y;
            };
            Console.WriteLine("f2"+f2("你好",666));



            //3 action 简单Lambda用法
            Action<int, int> ac1 = (x, y) =>
            {
                Console.WriteLine("{0}*{1}={2}",x,y, x * y);
            };
            ac1(10, 99);


            //4 action使用 
            Actiontmp<int, int>((t1, t2) => { Console.WriteLine("Actiontmp:{0}+{1}={2}", t1, t2, t1 + t2); }, 12, 15);


          




            //初始值
            List<int> list = new List<int>() { 10, 22, 2, 5, 89, 75 };

            //5 func用法获取 实体
            try {
                var entity = list.GetEntity(m => m > 100);
                Console.WriteLine(entity);
            }
            catch {
                var d = 222;
            }

            //6 func用法获取 列表
            var nlist = list.GetSelect(m => m > 6);
            foreach (var entity in nlist)
            {
                Console.WriteLine(entity);
            }
            Console.ReadKey();
        }

        //func用法获取 实体
        public static TData GetEntity<TData>(this IEnumerable<TData> list, Func<TData, bool> func)
        {
            foreach (TData entity in list)
            {
                if (func(entity))
                {
                    return entity;
                }
            }
            
            throw new Exception("不存在满足条件的第一个元素！");
            //return ;   
        }

        //func用法获取 列表
        public static List<TData> GetSelect<TData>(this IEnumerable<TData> list, Func<TData, bool> func)
        {
            List<TData> nlist = new List<TData>();
            foreach (TData entity in list)
            {
                if (func(entity))
                {
                    nlist.Add(entity);
                }
            }
            return nlist;
        }

        //action使用
        public static void Actiontmp<T1,T2>(Action<T1,T2> act, T1 t1, T2 t2) {
            act(t1, t2);
        }

       
    }

 
}
