/*
 * @lc app=leetcode.cn id=19 lang=csharp
 *
 * [19] 删除链表的倒数第N个节点
 *
 * https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/description/
 *
 * algorithms
 * Medium (34.74%)
 * Likes:    462
 * Dislikes: 0
 * Total Accepted:    58.5K
 * Total Submissions: 168.5K
 * Testcase Example:  '[1,2,3,4,5]\n2'
 *
 * 给定一个链表，删除链表的倒数第 n 个节点，并且返回链表的头结点。
 * 
 * 示例：
 * 
 * 给定一个链表: 1->2->3->4->5, 和 n = 2.
 * 
 * 当删除了倒数第二个节点后，链表变为 1->2->3->5.
 * 
 * 
 * 说明：
 * 
 * 给定的 n 保证是有效的。
 * 
 * 进阶：
 * 
 * 你能尝试使用一趟扫描实现吗？
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
public class Solution0019
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode pre = new ListNode(-1);
        pre.next = head;
        ListNode front = pre, end = pre;
        while (n != 0)
        {
            end = end.next;
            n--;
        }
        while (end.next != null)
        {
            end = end.next;
            front = front.next;
        }
        front.next = front.next.next;
        return pre.next;
    }
}