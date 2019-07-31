/*
 * @lc app=leetcode.cn id=92 lang=csharp
 *
 * [92] 反转链表 II
 *
 * https://leetcode-cn.com/problems/reverse-linked-list-ii/description/
 *
 * algorithms
 * Medium (45.77%)
 * Likes:    163
 * Dislikes: 0
 * Total Accepted:    15.2K
 * Total Submissions: 33.2K
 * Testcase Example:  '[1,2,3,4,5]\n2\n4'
 *
 * 反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。
 * 
 * 说明:
 * 1 ≤ m ≤ n ≤ 链表长度。
 * 
 * 示例:
 * 
 * 输入: 1->2->3->4->5->NULL, m = 2, n = 4
 * 输出: 1->4->3->2->5->NULL
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
public class Solution0092
{
    // (124 ms) Your runtime beats 100 % of csharp submissions
    // 用多个头结点和索引结点把链表分三段 中间部分重用翻转链表的函数
    public ListNode ReverseBetween(ListNode head, int m, int n)
    {
        ListNode pre = new ListNode(-1);
        pre.next = head;
        ListNode leftIndex = pre;
        ListNode rightHead;
        int len = n - m;
        while (m > 1)
        {
            leftIndex = leftIndex.next;
            m--;
        }

        ListNode midHead = leftIndex.next;
        ListNode midIndex = midHead;
        for (int i = len; i > 0; i--)
        {
            midIndex = midIndex.next;
        }

        rightHead = midIndex.next;

        // 要把中间部分前后切分开来，否则翻转链表时会死循环
        leftIndex.next = null;
        midIndex.next = null;

        midHead = ReverseList(midHead);
        midIndex = midHead;

        for (int i = len; i > 0; i--)
        {
            midIndex = midIndex.next;
        }

        leftIndex.next = midHead;
        midIndex.next = rightHead;
        return pre.next;
    }

    public ListNode ReverseList(ListNode head)
    {
        ListNode cur = head;
        ListNode pre = null;
        while (cur != null)
        {
            ListNode temp = cur.next;
            cur.next = pre;
            pre = cur;
            cur = temp;
        }
        return pre;
    }

    // (136 ms) Your runtime beats 93.94 % of csharp submissions
    public ListNode ReverseBetween1(ListNode head, int m, int n)
    {
        ListNode dummyHead = new ListNode(-1);
        dummyHead.next = head;
        ListNode pre = dummyHead;

        // 将 pre 定位到翻转链表前一个结点
        for (int i = 0; i < m - 1; i++)
        {
            pre = pre.next;
        }
        // 反转链表第一个结点
        head = pre.next;

        for (int i = m; i < n; i++)
        {
            ListNode temp = head.next;
            head.next = temp.next;
            temp.next = pre.next;
            pre.next = temp;
        }
        return dummyHead.next;
    }
}