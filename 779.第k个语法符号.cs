using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode.cn id=779 lang=csharp
 *
 * [779] 第K个语法符号
 *
 * https://leetcode-cn.com/problems/k-th-symbol-in-grammar/description/
 *
 * algorithms
 * Medium (38.44%)
 * Likes:    32
 * Dislikes: 0
 * Total Accepted:    1.7K
 * Total Submissions: 4.5K
 * Testcase Example:  '1\n1'
 *
 * 在第一行我们写上一个 0。接下来的每一行，将前一行中的0替换为01，1替换为10。
 * 
 * 给定行数 N 和序数 K，返回第 N 行中第 K个字符。（K从1开始）
 * 
 * 
 * 例子:
 * 
 * 输入: N = 1, K = 1
 * 输出: 0
 * 
 * 输入: N = 2, K = 1
 * 输出: 0
 * 
 * 输入: N = 2, K = 2
 * 输出: 1
 * 
 * 输入: N = 4, K = 5
 * 输出: 1
 * 
 * 解释:
 * 第一行: 0
 * 第二行: 01
 * 第三行: 0110
 * 第四行: 01101001
 * 
 * 
 * 
 * 注意：
 * 
 * 
 * N 的范围 [1, 30].
 * K 的范围 [1, 2^(N-1)].
 * 
 * 
 */
public class Solution0779
{
    // 序号
    //              1
    //          /        \   
    //      1                2
    //    /   \            /    \
    //  1       2        3       4
    // / \     /  \     /  \    / \ 
    //1   2   3    4   5    6  7   8

    // 01 排列
    //              0
    //          /        \   
    //      0                1
    //    /   \            /    \
    //  0       1        1       0
    // / \     /  \     /  \    / \ 
    //0   1   1    0   1    0  0   1
    public int KthGrammar(int N, int K)
    {
        if (K == 1) return 0;
        // 求父节点的索引
        int father = KthGrammar(N - 1, (K + 1) / 2);
        if (K % 2 == 1)
        {
            // K 为奇数则其值与父结点相同
            return father;
        }
        else
        {
            return 1 - father;
        }
    }

    // 输入：30 434991989 NullReferenceException 换种思路
    // 时间和空间复杂度都是 2^n 
    public int KthGrammarError(int N, int K)
    {
        if (K == 1) return 0;
        if (K == 2) return 1;
        ListNode pre = new ListNode(-1);
        pre.next = new ListNode(0);
        return KthGrammarError(N, K, pre);

    }

    public int KthGrammarError(int N, int K, ListNode list)
    {
        if (N == 0)
        {
            while (K > 0)
            {
                K--;
                list = list.next;
            }
            return list.val;
        }
        ListNode node = list;
        while (node != null && node.next != null)
        {
            ListNode temp = node.next.next;
            if (node.next.val == 0)
            {
                node.next.next = new ListNode(1);
            }
            else if (node.next.val == 1)
            {
                node.next.next = new ListNode(0);
            }
            node.next.next.next = temp;
            node = node.next.next.next;
        }
        N--;
        return KthGrammarError(N, K, list);
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}