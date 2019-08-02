/*
 * @lc app=leetcode.cn id=33 lang=csharp
 *
 * [33] 搜索旋转排序数组
 *
 * https://leetcode-cn.com/problems/search-in-rotated-sorted-array/description/
 *
 * algorithms
 * Medium (36.14%)
 * Likes:    311
 * Dislikes: 0
 * Total Accepted:    34K
 * Total Submissions: 94.1K
 * Testcase Example:  '[4,5,6,7,0,1,2]\n0'
 *
 * 假设按照升序排序的数组在预先未知的某个点上进行了旋转。
 * 
 * ( 例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] )。
 * 
 * 搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。
 * 
 * 你可以假设数组中不存在重复的元素。
 * 
 * 你的算法时间复杂度必须是 O(log n) 级别。
 * 
 * 示例 1:
 * 
 * 输入: nums = [4,5,6,7,0,1,2], target = 0
 * 输出: 4
 * 
 * 
 * 示例 2:
 * 
 * 输入: nums = [4,5,6,7,0,1,2], target = 3
 * 输出: -1
 * 
 */
public class Solution0033
{
    // 将数组一分为二，其中一定有一个是有序的，另一个可能是有序，也能是部分有序
    // 此时有序部分用二分法查找。无序部分再一分为二，其中一个一定有序，另一个可能有序，可能无序。就这样循环.
    // 执行用时 : 136 ms, 在所有 C# 提交中击败了 92.22% 的用户
    public int Search(int[] nums, int target)
    {
        return Search(nums, target, 0, nums.Length - 1);
    }
    public int Search(int[] nums, int target, int low, int high)
    {
        if (low > high) return -1;
        int mid = ((high - low) >> 1) + low;
        if (nums[mid] == target) return mid;

        if (nums[mid] < nums[high])
        {
            if (nums[mid] < target && target <= nums[high])
                return Search(nums, target, mid + 1, high);
            else // target > nums[high]
                return Search(nums, target, low, mid - 1);
        }
        else // nums[mid] >= nums[high]
        {
            if (nums[mid] > target && target >= nums[low])
                return Search(nums, target, low, mid - 1);
            else
                return Search(nums, target, mid + 1, high);
        }
    }
}