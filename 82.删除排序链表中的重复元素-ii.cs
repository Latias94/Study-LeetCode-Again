/*
 * @lc app=leetcode.cn id=82 lang=csharp
 *
 * [82] 删除排序链表中的重复元素 II
 *
 * https://leetcode-cn.com/problems/remove-duplicates-from-sorted-list-ii/description/
 *
 * algorithms
 * Medium (42.36%)
 * Likes:    125
 * Dislikes: 0
 * Total Accepted:    14.2K
 * Total Submissions: 33.5K
 * Testcase Example:  '[1,2,3,3,4,4,5]'
 *
 * 给定一个排序链表，删除所有含有重复数字的节点，只保留原始链表中 没有重复出现 的数字。
 * 
 * 示例 1:
 * 
 * 输入: 1->2->3->3->4->4->5
 * 输出: 1->2->5
 * 
 * 
 * 示例 2:
 * 
 * 输入: 1->1->1->2->3
 * 输出: 2->3
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
public class Solution0082
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
                front.next = last.next;
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