/*
 * @lc app=leetcode.cn id=21 lang=csharp
 *
 * [21] 合并两个有序链表
 *
 * https://leetcode-cn.com/problems/merge-two-sorted-lists/description/
 *
 * algorithms
 * Easy (56.06%)
 * Likes:    542
 * Dislikes: 0
 * Total Accepted:    90.2K
 * Total Submissions: 160.9K
 * Testcase Example:  '[1,2,4]\n[1,3,4]'
 *
 * 将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。 
 * 
 * 示例：
 * 
 * 输入：1->2->4, 1->3->4
 * 输出：1->1->2->3->4->4
 * 
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
public class Solution0021
{
    // O(min(n, m))
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        ListNode pre = new ListNode(-1);
        ListNode cur = pre;
        while (l1 != null && l2 != null)
        {
            if (l1.val > l2.val)
            {
                cur.next = l2;
                l2 = l2.next;
            }
            else
            {
                cur.next = l1;
                l1 = l1.next;
            }
            cur = cur.next;
        }
        cur.next = l1 == null?l2 : l1;
        return pre.next;
    }
}