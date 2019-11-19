using AutoMapUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new T { a = 1, b = 2 };
            var t2 = t.Map<T2>();
            Console.WriteLine(JsonConvert.SerializeObject(t2));

            var list1 = new List<T> { new T{a=1,b=2},new T { a = 3, b = 4 } };
            IList<T2> list2 = list1.MapList<T, T2>();
            Console.WriteLine(JsonConvert.SerializeObject(list2));
        }
    }
}
