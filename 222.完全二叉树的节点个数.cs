/*
 * @lc app=leetcode.cn id=222 lang=csharp
 *
 * [222] 完全二叉树的节点个数
 *
 * https://leetcode-cn.com/problems/count-complete-tree-nodes/description/
 *
 * algorithms
 * Medium (55.01%)
 * Likes:    71
 * Dislikes: 0
 * Total Accepted:    6.1K
 * Total Submissions: 11.1K
 * Testcase Example:  '[1,2,3,4,5,6]'
 *
 * 给出一个完全二叉树，求出该树的节点个数。
 * 
 * 说明：
 * 
 * 
 * 完全二叉树的定义如下：在完全二叉树中，除了最底层节点可能没填满外，其余每层节点数都达到最大值，并且最下面一层的节点都集中在该层最左边的若干位置。若最底层为第
 * h 层，则该层包含 1~ 2^h 个节点。
 * 
 * 示例:
 * 
 * 输入: 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   3
 * ⁠/ \  /
 * 4  5 6
 * 
 * 输出: 6
 * 
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution0222
{
    // SEU.FidGet 的题解
    // 完全二叉树的高度可以直接通过不断地访问左子树就可以获取
    // 判断左右子树的高度: 
    // 如果相等说明左子树是满二叉树, 然后进一步判断右子树的节点数(最后一层最后出现的节点必然在右子树中)
    // 如果不等说明右子树是深度小于左子树的满二叉树, 然后进一步判断左子树的节点数(最后一层最后出现的节点必然在左子树中)
    public int CountNodes(TreeNode root)
    {
        if (root == null) return 0;
        int leftDepth = GetDepth(root.left);
        int rightDepth = GetDepth(root.right);

        if (leftDepth == rightDepth)
        {
            return (1 << leftDepth) + CountNodes(root.right);
        }
        else // leftDepth > rightDepth
        {
            return (1 << rightDepth) + CountNodes(root.left);
        }

    }

    public int GetDepth(TreeNode root)
    {
        int depth = 0;
        while (root != null)
        {
            depth++;
            root = root.left;
        }
        return depth;
    }

    // 一开始直接递归做，但是没用到完全二叉树的性质
    public int CountNodes1(TreeNode root)
    {
        if (root == null) return 0;
        return 1 + CountNodes1(root.left) + CountNodes1(root.right);
    }
}