/*
 * @lc app=leetcode.cn id=23 lang=csharp
 *
 * [23] 合并K个排序链表
 *
 * https://leetcode-cn.com/problems/merge-k-sorted-lists/description/
 *
 * algorithms
 * Hard (47.18%)
 * Likes:    286
 * Dislikes: 0
 * Total Accepted:    32.7K
 * Total Submissions: 69.2K
 * Testcase Example:  '[[1,4,5],[1,3,4],[2,6]]'
 *
 * 合并 k 个排序链表，返回合并后的排序链表。请分析和描述算法的复杂度。
 * 
 * 示例:
 * 
 * 输入:
 * [
 * 1->4->5,
 * 1->3->4,
 * 2->6
 * ]
 * 输出: 1->1->2->3->4->4->5->6
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
public class Solution0023
{
    // O(Nlogk)  其中 k 是链表的数目。N 是节点的总数目。
    // 执行用时: 160 ms, 在所有 C# 提交中击败了 99.09% 的用户
    // 递归更简单，不过这道题面试的时候，面试官要求递归转迭代来做，那就做个迭代的8
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0) return null;
        if (lists.Length == 1) return lists[0];
        if (lists.Length == 2) return MergeTwoLists(lists[0], lists[1]);

        int len = lists.Length;

        while (len > 1)
        {
            // 从 0 开始存放合并后的链表
            int index = 0;
            bool isOught = len % 2 == 1;

            for (int j = 0; j < len - 1; j += 2)
            {
                lists[index++] = MergeTwoLists(lists[j], lists[j + 1]);
            }
            if (isOught)
            {
                lists[index] = lists[len - 1];
            }
            len = CalculateLen(len);
        }
        return lists[0];
    }
    // 计算每次循环中，两两合并后链表的长度
    private int CalculateLen(int len)
    {
        if (len % 2 == 1)
        {
            len = len / 2 + 1;
        }
        else
        {
            len = len / 2;
        }
        return len;
    }

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