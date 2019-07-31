/*
 * @lc app=leetcode.cn id=206 lang=csharp
 *
 * [206] 反转链表
 *
 * https://leetcode-cn.com/problems/reverse-linked-list/description/
 *
 * algorithms
 * Easy (63.21%)
 * Likes:    505
 * Dislikes: 0
 * Total Accepted:    77.7K
 * Total Submissions: 123K
 * Testcase Example:  '[1,2,3,4,5]'
 *
 * 反转一个单链表。
 * 
 * 示例:
 * 
 * 输入: 1->2->3->4->5->NULL
 * 输出: 5->4->3->2->1->NULL
 * 
 * 进阶:
 * 你可以迭代或递归地反转链表。你能否用两种方法解决这道题？
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
public class Solution0206
{
    public ListNode ReverseList(ListNode head)
    {
        // 当前节点
        ListNode cur = head;
        // 头结点
        ListNode pre = null;
        // 每次循环，都将当前节点指向它前面的节点，然后当前节点和头节点后移
        while (cur != null)
        {
            ListNode temp = cur.next;
            cur.next = pre;
            pre = cur;
            cur = temp;
        }
        return pre;
    }
}