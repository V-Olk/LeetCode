
namespace LeetCode
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-integer/
    /// </summary>
    public class TwoSum
    {
        public int[] TwoSumSol(int[] nums, int target)
        {
            System.Collections.Generic.Dictionary<int, int> indexByElement = new System.Collections.Generic.Dictionary<int, int>();

            int i = default, missing;
            foreach (int num in nums)
            {
                missing = target - num;
                if (!indexByElement.ContainsKey(missing))
                {
                    if (!indexByElement.ContainsKey(num))
                        indexByElement.Add(num, i);
                }
                else
                    return new int[] { indexByElement[missing], i };
                i++;
            }
            throw new System.Exception("Not valid input");
        }

        public static int[] TwoSumSol1(int[] nums, int target)
        {
            System.Collections.Generic.Dictionary<int, int> indexByElement = new System.Collections.Generic.Dictionary<int, int>();

            int missing, num;
            for (int i = 0; i < nums.Length; i++)
            {
                num = nums[i];
                missing = target - num;
                if (!indexByElement.ContainsKey(missing))
                    indexByElement.Add(num, i);
                else
                    return new int[] { indexByElement[missing], i };
            }
            throw new System.Exception("Not valid input");
        }
    }
}
