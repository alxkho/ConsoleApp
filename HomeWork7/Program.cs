namespace HomeWork7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, LeetCode!");
        }

        /// <summary>
        /// Given a non-negative integer x, compute and return the square root of x.
        /// Since the return type is an integer, the decimal digits are truncated, and only the integer part of the result is returned.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            return (int)Math.Pow(x, 0.5);
        }

        /// <summary>
        /// You are climbing a staircase.It takes n steps to reach the top.
        /// Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            int fib = 1;
            int result = 1;
            int temp = 1;
            for (var i = 1; i < n; i++)
            {
                temp = result;
                result += fib;
                fib = temp;
            }
            return result;
        }

        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///You can return the answer in any order.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j <= nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Roman to Integer
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToInt(string s)
        {
            Dictionary<char, int> roman = new Dictionary<char, int>()
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000,
            };
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i != 0 && roman[s[i]] > roman[s[i - 1]])
                    result += roman[s[i]] - roman[s[i - 1]] * 2;

                else
                    result += roman[s[i]];
            }
            return result;
        }

    }
}