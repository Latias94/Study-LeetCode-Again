/*
 * @lc app=leetcode.cn id=162 lang=csharp
 *
 * [162] 寻找峰值
 *
 * https://leetcode-cn.com/problems/find-peak-element/description/
 *
 * algorithms
 * Medium (41.01%)
 * Likes:    76
 * Dislikes: 0
 * Total Accepted:    14.1K
 * Total Submissions: 34.4K
 * Testcase Example:  '[1,2,3,1]'
 *
 * 峰值元素是指其值大于左右相邻值的元素。
 * 
 * 给定一个输入数组 nums，其中 nums[i] ≠ nums[i+1]，找到峰值元素并返回其索引。
 * 
 * 数组可能包含多个峰值，在这种情况下，返回任何一个峰值所在位置即可。
 * 
 * 你可以假设 nums[-1] = nums[n] = -∞。
 * 
 * 示例 1:
 * 
 * 输入: nums = [1,2,3,1]
 * 输出: 2
 * 解释: 3 是峰值元素，你的函数应该返回其索引 2。
 * 
 * 示例 2:
 * 
 * 输入: nums = [1,2,1,3,5,6,4]
 * 输出: 1 或 5 
 * 解释: 你的函数可以返回索引 1，其峰值元素为 2；
 * 或者返回索引 5， 其峰值元素为 6。
 * 
 * 
 * 说明:
 * 
 * 你的解法应该是 O(logN) 时间复杂度的。
 * 
 */
public class Solution0162
{
    // 规律一：如果nums[i] > nums[i+1]，则在i之前一定存在峰值元素
    // 规律二：如果nums[i] < nums[i+1]，则在i+1之后一定存在峰值元素
    public int FindPeakElement(int[] nums)
    {
        if (nums.Length == 1) return 0;
        int low = 0, high = nums.Length - 1;
        while (low <= high)
        {
            int mid = ((high - low) >> 1) + low;
            if (mid == 0 && nums[mid + 1] < nums[mid]) return mid;
            if (mid == nums.Length - 1 && nums[mid - 1] < nums[mid]) return mid;
            if (mid > 0 && mid < nums.Length - 1 && nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1]) return mid;

            if (nums[mid] > nums[mid + 1])
            {
                high = mid - 1;
            }
            else // nums[mid] < nums[mid + 1]
            {
                low = mid + 1;
            }
        }
        return -1;
    }

    // 别人的实现，效率更高
    public int FindPeakElement1(int[] nums)
    {
        int low = 0, high = nums.Length - 1;
        while (low < high)
        {
            int mid = low + (high - low) >> 1;
            int mid1 = mid + 1;
            if (nums[mid] < nums[mid1])
            {
                low = mid1;
            }
            else
            {
                high = mid;
            }
        }
        return low;
    }
}