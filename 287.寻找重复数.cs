/*
 * @lc app=leetcode.cn id=287 lang=csharp
 *
 * [287] 寻找重复数
 *
 * https://leetcode-cn.com/problems/find-the-duplicate-number/description/
 *
 * algorithms
 * Medium (60.31%)
 * Likes:    235
 * Dislikes: 0
 * Total Accepted:    15.3K
 * Total Submissions: 25.3K
 * Testcase Example:  '[1,3,4,2,2]'
 *
 * 给定一个包含 n + 1 个整数的数组 nums，其数字都在 1 到 n 之间（包括 1 和
 * n），可知至少存在一个重复的整数。假设只有一个重复的整数，找出这个重复的数。
 * 
 * 示例 1:
 * 
 * 输入: [1,3,4,2,2]
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 输入: [3,1,3,4,2]
 * 输出: 3
 * 
 * 
 * 说明：
 * 
 * 
 * 不能更改原数组（假设数组是只读的）。
 * 只能使用额外的 O(1) 的空间。
 * 时间复杂度小于 O(n^2) 。
 * 数组中只有一个重复的数字，但它可能不止重复出现一次。
 * 
 * 
 */
public class Solution0287
{
    // 由于 n + 1 个整数的数组 nums，且数字都在 1 到 n 之间（包括 1 和 n）
    // 因此可以用值当数组的索引，再将索引上的值继续当做索引这样一直穿越下去
    // 总会有一处地方有两个相同的值。这样这道题可以看做有环链表，问题转化为有环链表找入口的地方
    public int FindDuplicate(int[] nums)
    {
        int slow = nums[0];
        int fast = nums[0];

        slow = nums[slow];
        fast = nums[nums[fast]];

        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        }

        // 到这一步时快慢指针相遇，开始找环的入口
        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return fast;
    }
}