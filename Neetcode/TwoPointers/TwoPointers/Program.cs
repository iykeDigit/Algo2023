using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace TwoPointers
{
    class Program
    {
        static void Main(string[] args)
        {
            //var str = "A man, a plan, a canal: Panama";
            var arr = Array.Empty<int>();
            var nums = new int[] { 1, 1,2 };
            var result = RemoveDuplicates(nums);
            Console.WriteLine("Hello World!");
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int insertIndex = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                // We skip to next index if we see a duplicate element
                if (nums[i - 1] != nums[i])
                {
                    /* Storing the unique element at insertIndex index and incrementing
                       the insertIndex by 1 */
                    nums[insertIndex] = nums[i];
                    insertIndex++;
                }
            }
            return insertIndex;
        }

        public static bool HalvesAreAlike(string s)
        {
            s = s.ToLower();
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            var left = 0;
            var right = s.Length - 1;
            var a = 0;
            var b = 0;

            while (left < right)
            {
                if (vowels.Contains(s[left])) a++;
                if (vowels.Contains(s[right])) b++;
                left++;
                right--;
            }
            return a == b;
        }
        public static int MaxArea(int[] height)
        {
            int max_Area = 0;
            int first = 0;
            int second = height.Length-1;
            while (first < second)
            {
                Console.WriteLine(height[first]);
                Console.WriteLine(height[second]);
                Console.WriteLine("");
                if (height[first] < height[second])
                {
                    max_Area = Math.Max(max_Area, height[first] * (second - first));
                    first++;
                }
                else
                {
                    max_Area = Math.Max(max_Area, height[second] * (second - first));
                    second--;
                }
            }

            return max_Area;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
           Array.Sort(nums);
           var result = new List<IList<int>>();
           for (int i = 0; i < nums.Length - 2; i++)
           {
               if(i == 0 || (i > 0 && nums[i] != nums[i-1]))
               {
                   int low = i + 1;
                   int high = nums.Length - 1;
                   int sum = 0 - nums[i];

                   while (low < high)
                   {
                       if (nums[low] + nums[high] == sum)
                       {
                           result.Add(new List<int>{nums[i], nums[low], nums[high]});
                           while (low < high && nums[low] == nums[low + 1])
                           {
                               low++;
                           }
                           while (low < high && nums[high] == nums[high - 1])
                           {
                               high--;
                           }

                           low++;
                           high--;
                       }
                       else if (nums[low] + nums[high] > sum)
                       {
                           high--;
                       }
                       else
                       {
                           low++;
                       }

                   }
               }
           }

           return result;
        }
        public static int[] TwoSum(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;
            while (left < right)
            {
                int current = numbers[left] + numbers[right];
                if (current > target)
                {
                    right--;
                }
                if (current < target)
                {
                    left++;
                }
                if (current == target)
                {
                    return new int[] { left + 1, right + 1 };
                }
            }
            return Array.Empty<int>();
        }

        public static bool IsPalindrome(string s)
        {
            if (s.Length == 0) return true;
            var newStr = "";
            foreach(var item in s)
            {
                if (char.IsLetterOrDigit(item))
                {
                    newStr += item;
                }
            }

            var str = "";
            for (int i = newStr.Length-1; i >= 0; i--)
            {
                str += newStr[i];
            }

            return str.ToLower() == newStr.ToLower();
        }

        public static bool IsPalindromePointers(string s)
        {
            if (s.Length == 0) return true;
            s = s.ToLower();

            for (int i = 0, j = s.Length - 1; i < j; i++, j--)
            {
                while (i < j && !char.IsLetterOrDigit(s[i]))
                {
                    i++;
                }

                while (i < j && !char.IsLetterOrDigit(s[j]))
                {
                    j--;
                }

                if (s[i] != s[j]) return false;
            }

            return true;
        }
    }
}
