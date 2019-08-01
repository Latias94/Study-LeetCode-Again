using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=496 lang=csharp
 *
 * [496] 下一个更大元素 I
 *
 * https://leetcode-cn.com/problems/next-greater-element-i/description/
 *
 * algorithms
 * Easy (60.28%)
 * Likes:    92
 * Dislikes: 0
 * Total Accepted:    10.8K
 * Total Submissions: 18K
 * Testcase Example:  '[4,1,2]\n[1,3,4,2]'
 *
 * 给定两个没有重复元素的数组 nums1 和 nums2 ，其中nums1 是 nums2 的子集。找到 nums1 中每个元素在 nums2
 * 中的下一个比其大的值。
 * 
 * nums1 中数字 x 的下一个更大元素是指 x 在 nums2 中对应位置的右边的第一个比 x 大的元素。如果不存在，对应位置输出-1。
 * 
 * 示例 1:
 * 
 * 
 * 输入: nums1 = [4,1,2], nums2 = [1,3,4,2].
 * 输出: [-1,3,-1]
 * 解释:
 * ⁠   对于num1中的数字4，你无法在第二个数组中找到下一个更大的数字，因此输出 -1。
 * ⁠   对于num1中的数字1，第二个数组中数字1右边的下一个较大数字是 3。
 * ⁠   对于num1中的数字2，第二个数组中没有下一个更大的数字，因此输出 -1。
 * 
 * 示例 2:
 * 
 * 
 * 输入: nums1 = [2,4], nums2 = [1,2,3,4].
 * 输出: [3,-1]
 * 解释:
 * 对于num1中的数字2，第二个数组中的下一个较大数字是3。
 * ⁠   对于num1中的数字4，第二个数组中没有下一个更大的数字，因此输出 -1。
 * 
 * 
 * 注意:
 * 
 * 
 * nums1和nums2中所有元素是唯一的。
 * nums1和nums2 的数组大小都不超过1000。
 * 
 * 
 */
public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        Stack<int> stack = new Stack<int>();
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int[] result = new int[nums1.Length];

        if (nums2.Length > 0) stack.Push(nums2[0]);

        foreach (int num in nums2)
        {
            // 栈里面存的数据都是越来越小的，有一个更大的元素直接就是下一个更大的元素
            while (stack.Count > 0 && num > stack.Peek())
            {
                AddOrUpdateKey(dict, stack.Pop(), num);
            }
            stack.Push(num);
            for (int i = 0; i < nums1.Length; i++)
            {
                if (dict.TryGetValue(nums1[i], out int value))
                {
                    result[i] = value;
                }
                else
                {
                    result[i] = -1;
                }
            }
        }
        return result;
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