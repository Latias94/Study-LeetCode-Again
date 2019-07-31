/*
 * @lc app=leetcode.cn id=83 lang=csharp
 *
 * [83] 删除排序链表中的重复元素
 *
 * https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list/description/
 *
 * algorithms
 * Easy (46.85%)
 * Likes:    182
 * Dislikes: 0
 * Total Accepted:    36.2K
 * Total Submissions: 77.2K
 * Testcase Example:  '[1,1,2]'
 *
 * 给定一个排序链表，删除所有重复的元素，使得每个元素只出现一次。
 * 
 * 示例 1:
 * 
 * 输入: 1->1->2
 * 输出: 1->2
 * 
 * 
 * 示例 2:
 * 
 * 输入: 1->1->2->3->3
 * 输出: 1->2->3
 * 
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution0083
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode pre = new ListNode(-1);
        pre.next = head;
        ListNode front = pre, last = head;
        while (last != null)
        {
            while (last.next != null && last.val == last.next.val)
            {
                last = last.next;
            }

            if (front.next != last)
            {
                // 如果之前发现相同的元素
                front.next = last; // 与 82 题只相差一个 next
                last = front.next;
            }
            else
            {
                // 如果之前没发现相同的元素
                front = front.next;
                last = last.next;
            }
        }
        return pre.next;
    }
}