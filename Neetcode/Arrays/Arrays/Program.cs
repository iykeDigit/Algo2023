using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 1, 1, 2, 2, 3 };
            var list = new string[] {"eat", "tea"};
            char[][] jaggedArray =
            {
               new char[]{'5', '3', '.', '.', '7', '.', '.', '.', '.' },
               new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.' },
               new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1' },
               new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.' },
               new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9' },
               new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.' },
               new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3' },
               new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6' },
               new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5' },
            };
            var m = Encode(list);
            Console.WriteLine();
        }

        public static int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int maxSize = 0;

            foreach (int item in set)
            {
                if (!set.Contains(item - 1))
                {
                    int current = item;
                    int count = 1;
                    while (set.Contains(current + count))
                    {
                        count++;
                    }

                    maxSize = Math.Max(maxSize, count);
                }
            }

            return maxSize;
        }
        public static string Encode(IList<string> strs)
        {
            if (strs.Count == 0) return strs.ToString();

            string d = char.ToString((char) 257);
            StringBuilder s = new StringBuilder();
            foreach (var item in strs)
            {
                s.Append(item);
                s.Append(d);
            }
            
            return s.Remove(s.Length - 1, 1).ToString();
        }

        public static IList<string> Decode(string s)
        {
            string[] arr = s.Split(char.ToString((char) 257));
            return arr.ToList();
        }

        public static bool IsValidSudoku(char[][] board)
        {
            var num = 9;
            HashSet<char>[] row = new HashSet<char>[num];
            HashSet<char>[] col = new HashSet<char>[num];
            var box = new HashSet<char>[num];

            for (int i = 0; i < num; i++)
            {
                row[i] = new HashSet<char>();
                col[i] = new HashSet<char>();
                box[i] = new HashSet<char>();
            }

            for (int r = 0; r < num; r++)
            {
                for (int c = 0; c < num; c++)
                {
                    var val = board[r][c];
                    if (val == '.')
                    {
                        continue;
                    }

                    if (row[r].Contains(val))
                    {
                        return false;
                    }
                    row[r].Add(val);

                    if (col[c].Contains(val))
                    {
                        return false;
                    }
                    col[c].Add(val);

                    int idx = (r / 3) * 3 + (c / 3);
                    if (box[idx].Contains(val))
                    {
                        return false;
                    }

                    box[idx].Add(val);
                }
            }
            return true;
        }

        public static IList<IList<string>> GroupAnagramsChar(string[] strs)
        {

            if (strs == null || strs.Length == 0) return new List<IList<string>>();
            var dict = new Dictionary<string, IList<string>>();
            foreach (var element in strs)
            {
                var arr = new char[26];
                foreach (var item in element)
                {
                    arr[item - 'a']++;
                }

                var str = new string(arr);
                if (dict.ContainsKey(str))
                {
                    dict[str].Add(element);
                }
                else
                {
                    dict.Add(str, new List<string>{ element });
                }
            }

            return dict.Values.ToList();
        }
        public static bool IsAnagramDict(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var c in s)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.TryAdd(c, 1);
                }
            }

            foreach (var c in t)
            {
                if (map.ContainsKey(c) && map[c] >= 1)
                {
                    map[c]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static int[] ProductExceptSelfTwo(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            var result = new int[nums.Length];
            int temp = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = temp;
                temp *= nums[i];
            }

            temp = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= temp;
                temp *= nums[i];
            }

            return result;
        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            result[0] = 1;
            int pre = 1;
            int post = 1;
            int preIndex = 0;
            int postIndex = nums.Length-1;
            for (int i = 1; i < result.Length; i++)
            {
                pre *= nums[preIndex];
                result[i] = pre;
                preIndex++;
            }

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                post *= nums[postIndex];
                result[i] *= post;
                postIndex--;
            }

            

            return result;
        }
        public static bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>();
            foreach (var item in nums)
            {
                if (!set.Add(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var first = new int[26];
            var second = new int[26];

            for (int i = 0; i < t.Length; i++)
            {
                first[s[i] - 'a']++;
                second[t[i] - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }

            }

            return true;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = target - nums[i];
                if (dict.ContainsKey(complement))
                {
                    return new int[] {dict[complement], i};
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }

            return new int[] {0, 0};
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();
            foreach (var item in strs)
            {
                var count = new int[26];
                foreach (var element in item)
                {
                    count[item[element] - 'a']++;
                }

                StringBuilder sb = new StringBuilder();
                foreach (var x in count)
                {
                    sb.Append(x.ToString());
                    sb.Append("#");
                }

                var key = sb.ToString();
                if (dict.ContainsKey(key))
                {
                    dict[key].Add(item);
                }
                else
                {
                    dict.Add(key, new List<string> {item});
                }
            }

            return dict.Values.ToList();
        }

        public static int[] TopKFrequentOptimal(int[] nums, int k)
        {
            if (nums.Length < k)
            {
                return null;
            }
            else if (nums.Length == k)
            {
                return nums;
            }

            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (counts.ContainsKey(nums[i]))
                {
                    counts[nums[i]] += 1;
                }
                else
                {
                    counts[nums[i]] = 1;
                }
            }

            int[] result = new int[k];
            int max = 0;
            int lastKey = 0;
            for (int m = 0; m < k; m++)
            {
                foreach (var count in counts)
                {
                    if (count.Value > max)
                    {
                        max = count.Value;
                        lastKey = count.Key;
                    }
                }
                counts.Remove(lastKey);
                result[m] = lastKey;
                max = 0;
            }

            return result;
        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            
            foreach (var item in nums)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }
            }

            return dict.OrderByDescending(o => o.Value).Take(k).Select(c => c.Key).ToArray();
        }

        public static int[] TopKFrequentSortedSet(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            foreach (var element in nums)
            {
                if (dict.ContainsKey(element))
                {
                    dict[element]++;
                }
                else
                {
                    dict[element] = 1;
                }
            }

            var set = new SortedSet<(int frequency, int num)>();
            foreach (var item in dict)
            {
                set.Add((item.Value, item.Key));
                if (set.Count > k)
                {
                        set.Remove(set.Min);
                }
            }
            
            var output = new int[k];
            for (int i = 0; i < k; i++)
            {
                output[i] = set.ElementAt(i).num;
            }

            return output;
        }

        public static int[] TopKFrequentSortedSetArray(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();
            var result = new int[k];
            var list = new List<int>[nums.Length];
            var index = 0;
            foreach (var item in nums)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }
            }

            foreach(var item in dict)
            {
                if (list[item.Value] == null)
                {
                    list[item.Value] = new List<int>{item.Key};

                }
                else
                {
                    list[item.Value].Add(item.Key);
                }
                
            }

            for (int i = nums.Length-1; i > 0; i--)
            {
                if (list[i] != null)
                {
                    foreach (var element in list[i])
                    {
                        result[index] = element;
                        index += 1;
                        if (index == k) return result;
                    }

                }

                    
            }
            
            return result;
        }
    }

}
