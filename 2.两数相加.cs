/*
 * @lc app=leetcode.cn id=2 lang=csharp
 *
 * [2] 两数相加
 *
 * https://leetcode-cn.com/problems/add-two-numbers/description/
 *
 * algorithms
 * Medium (34.95%)
 * Likes:    2747
 * Dislikes: 0
 * Total Accepted:    168.5K
 * Total Submissions: 482.1K
 * Testcase Example:  '[2,4,3]\n[5,6,4]'
 *
 * 给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。
 * 
 * 如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
 * 
 * 您可以假设除了数字 0 之外，这两个数都不会以 0 开头。
 * 
 * 示例：
 * 
 * 输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
 * 输出：7 -> 0 -> 8
 * 原因：342 + 465 = 807
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
public class Solution0002
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int carry = 0;
        ListNode pre = new ListNode(-1);
        ListNode cur = pre;
        while (l1 != null || l2 != null)
        {
            int val1 = l1 == null?0 : l1.val;
            int val2 = l2 == null?0 : l2.val;

            int sum = val1 + val2 + carry;
            int remainder = sum % 10;

            cur.next = new ListNode(remainder);
            carry = sum / 10;

            cur = cur.next;
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }
        if (carry == 1)
        {
            cur.next = new ListNode(carry);
        }
        return pre.next;
    }
}