using System;
/*
 * @lc app=leetcode.cn id=24 lang=csharp
 *
 * [24] 两两交换链表中的节点
 *
 * https://leetcode-cn.com/problems/swap-nodes-in-pairs/description/
 *
 * algorithms
 * Medium (61.17%)
 * Likes:    248
 * Dislikes: 0
 * Total Accepted:    30.9K
 * Total Submissions: 50.6K
 * Testcase Example:  '[1,2,3,4]'
 *
 * 给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
 * 
 * 你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
 * 
 * 
 * 
 * 示例:
 * 
 * 给定 1->2->3->4, 你应该返回 2->1->4->3.
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
public class Solution0024
{
    public ListNode SwapPairs(ListNode head)
    {
        ListNode pre = new ListNode(-1);
        pre.next = head;
        ListNode temp = pre;

        while (temp.next != null && temp.next.next != null)
        {
            ListNode start = temp.next;
            ListNode end = temp.next.next;
            temp.next = end;
            start.next = end.next;
            end.next = start;
            temp = start;
        }
        return pre.next;
    }

    // 递归
    public ListNode SwapPairs1(ListNode head)
    {
        if (head == null || head.next == null) return head;
        ListNode newHead = head.next;
        ListNode temp = newHead.next;
        newHead.next = head;
        newHead.next.next = SwapPairs(temp);
        return newHead;
    }
}