/*
 * @lc app=leetcode.cn id=167 lang=csharp
 *
 * [167] 两数之和 II - 输入有序数组
 *
 * https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/description/
 *
 * algorithms
 * Easy (49.48%)
 * Likes:    155
 * Dislikes: 0
 * Total Accepted:    33.3K
 * Total Submissions: 67.3K
 * Testcase Example:  '[2,7,11,15]\n9'
 *
 * 给定一个已按照升序排列 的有序数组，找到两个数使得它们相加之和等于目标数。
 * 
 * 函数应该返回这两个下标值 index1 和 index2，其中 index1 必须小于 index2。
 * 
 * 说明:
 * 
 * 
 * 返回的下标值（index1 和 index2）不是从零开始的。
 * 你可以假设每个输入只对应唯一的答案，而且你不可以重复使用相同的元素。
 * 
 * 
 * 示例:
 * 
 * 输入: numbers = [2, 7, 11, 15], target = 9
 * 输出: [1,2]
 * 解释: 2 与 7 之和等于目标数 9 。因此 index1 = 1, index2 = 2 。
 * 
 */
public class Solution0167
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int[] result = new int[2];
        for (int i = 0; i < numbers.Length; i++)
        {
            // 从该索引后开始搜
            int index = BinarySearch(numbers, target - numbers[i], i + 1);
            if (index != -1)
            {
                result[0] = i + 1;
                result[1] = index + 1;
                return result;
            }
        }
        return null;
    }

    public int BinarySearch(int[] nums, int target, int low)
    {
        int high = nums.Length - 1;
        while (low <= high)
        {
            int mid = ((high - low) >> 1) + low;
            if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else if (nums[mid] > target)
            {
                high = mid - 1;
            }
            else
            {
                return mid;
            }
        }
        return -1;
    }
}