using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 *
 * https://leetcode-cn.com/problems/two-sum/description/
 *
 * algorithms
 * Easy (46.33%)
 * Likes:    5809
 * Dislikes: 0
 * Total Accepted:    469K
 * Total Submissions: 1M
 * Testcase Example:  '[2,7,11,15]\n9'
 *
 * 给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
 * 
 * 你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
 * 
 * 示例:
 * 
 * 给定 nums = [2, 7, 11, 15], target = 9
 * 
 * 因为 nums[0] + nums[1] = 2 + 7 = 9
 * 所以返回 [0, 1]
 * 
 * 
 */

public class Solution0001
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                if (dict.TryGetValue(nums[i], out int index))
                {
                    return new [] { index, i };
                }
            }
            else
            {
                AddOrUpdateKey(dict, target - nums[i], i);
            }
        }

        return new int[] { };
    }

    private void AddOrUpdateKey(Dictionary<int, int> dict, int key, int value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = value;
        }
        else
        {
            dict.Add(key, value);
        }
    }
}