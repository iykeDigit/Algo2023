using System;
using System.Collections.Generic;
using System.Linq;

namespace BigONotation
{
    class Program
    {
        static void Main(string[] args)
        {
           // var arr = new string[] {"cat", "dog", "rat", "dog", "bird", "mouse"};
            Foo(4);
            Console.WriteLine();
        }

        public static int CalculateAverage(int[] numbers)
        {
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                sum += number;
            }

            return sum / numbers.Length;
        }

        public static string[] UniqueItems(string[] arr)
        {
            var res = new HashSet<string>();
            foreach (var item in arr)
            {
                if (!res.Add(item))
                {
                    continue;
                }
            }

            return res.ToArray();
        }

        public static void Foo(int n)
        {
            if (n == 1) return;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("");
                Console.WriteLine(n);
                Console.WriteLine(i);
                Foo(n-1);
            }
        }
    }
}
