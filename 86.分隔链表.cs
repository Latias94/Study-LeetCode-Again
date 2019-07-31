/*
 * @lc app=leetcode.cn id=86 lang=csharp
 *
 * [86] 分隔链表
 *
 * https://leetcode-cn.com/problems/partition-list/description/
 *
 * algorithms
 * Medium (51.33%)
 * Likes:    104
 * Dislikes: 0
 * Total Accepted:    11.5K
 * Total Submissions: 22.4K
 * Testcase Example:  '[1,4,3,2,5,2]\n3'
 *
 * 给定一个链表和一个特定值 x，对链表进行分隔，使得所有小于 x 的节点都在大于或等于 x 的节点之前。
 * 
 * 你应当保留两个分区中每个节点的初始相对位置。
 * 
 * 示例:
 * 
 * 输入: head = 1->4->3->2->5->2, x = 3
 * 输出: 1->2->2->4->3->5
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
public class Solution0086
{
    // (140 ms) Your runtime beats 100 % of csharp submissions
    public ListNode Partition(ListNode head, int x)
    {
        if (head == null || head.next == null) return head;
        ListNode head1 = new ListNode(-1);
        ListNode head2 = new ListNode(-1);
        ListNode cur1 = head1, cur2 = head2;
        while (head != null)
        {
            if (head.val < x)
            {
                cur1.next = head;
                cur1 = cur1.next;
                head = head.next;
                cur1.next = null;
            }
            else
            {
                cur2.next = head;
                cur2 = cur2.next;
                head = head.next;
                cur2.next = null;
            }
        }
        cur1.next = head2.next;
        return head1.next;
    }
}