/*
 * @lc app=leetcode.cn id=61 lang=csharp
 *
 * [61] 旋转链表
 *
 * https://leetcode-cn.com/problems/rotate-list/description/
 *
 * algorithms
 * Medium (38.82%)
 * Likes:    121
 * Dislikes: 0
 * Total Accepted:    20.3K
 * Total Submissions: 52.3K
 * Testcase Example:  '[1,2,3,4,5]\n2'
 *
 * 给定一个链表，旋转链表，将链表每个节点向右移动 k 个位置，其中 k 是非负数。
 * 
 * 示例 1:
 * 
 * 输入: 1->2->3->4->5->NULL, k = 2
 * 输出: 4->5->1->2->3->NULL
 * 解释:
 * 向右旋转 1 步: 5->1->2->3->4->NULL
 * 向右旋转 2 步: 4->5->1->2->3->NULL
 * 
 * 
 * 示例 2:
 * 
 * 输入: 0->1->2->NULL, k = 4
 * 输出: 2->0->1->NULL
 * 解释:
 * 向右旋转 1 步: 2->0->1->NULL
 * 向右旋转 2 步: 1->2->0->NULL
 * 向右旋转 3 步: 0->1->2->NULL
 * 向右旋转 4 步: 2->0->1->NULL
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
public class Solution0061
{
    // (120 ms) √ Your runtime beats 100 % of csharp submissions
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null) return head;
        ListNode pre = new ListNode(-1);
        pre.next = head;
        ListNode last = head;
        ListNode front = head;

        int len = 0;
        while (pre.next != null)
        {
            pre = pre.next;
            len++;
        }

        k = k % len;

        if (k == 0) return head;

        while (k > 0)
        {
            last = last.next;
            k--;
        }
        pre = new ListNode(-1);
        pre.next = head;
        while (last.next != null)
        {
            front = front.next;
            last = last.next;
        }

        ListNode startNode = front.next;
        last.next = pre.next;
        front.next = null;
        return startNode;
    }
}