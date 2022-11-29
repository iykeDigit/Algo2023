using System;

namespace SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] {4, 2, 2, 7, 8, 1, 2, 8, 1, 10};
            var m = SmallestSubArray(arr, 8);
            Console.WriteLine("Hello World!");
        }

        public static int FindMaxSumSubArray(int[] arr, int k)
        {
            int maxValue = int.MinValue;
            int currentSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                currentSum += arr[i];
                if (i >= k - 1)
                {
                    maxValue = Math.Max(maxValue, currentSum);
                    currentSum -= arr[i - (k - 1)];
                }
            }

            return maxValue;
        }

        public static int SmallestSubArray(int[] arr, int targetSum)
        {
            int currentWindowSum = 0;
            int windowStart = 0;
            int minWindowSize = int.MaxValue;
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                currentWindowSum += arr[windowEnd];

                while (currentWindowSum >= targetSum)
                {
                    minWindowSize = Math.Min(minWindowSize, windowEnd - windowStart + 1);
                    currentWindowSum -= arr[windowStart];
                    windowStart++;
                }
            }

            return minWindowSize;
        }
    }
}
