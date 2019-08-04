using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-inorder-traversal/description/
 *
 * algorithms
 * Medium (66.89%)
 * Likes:    241
 * Dislikes: 0
 * Total Accepted:    45.6K
 * Total Submissions: 68.1K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的中序 遍历。
 * 
 * 示例:
 * 
 * 输入: [1,null,2,3]
 * ⁠  1
 * ⁠   \
 * ⁠    2
 * ⁠   /
 * ⁠  3
 * 
 * 输出: [1,3,2]
 * 
 * 进阶: 递归算法很简单，你可以通过迭代算法完成吗？
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
public class Solution0094
{
    // 先序：考察到一个节点后，即刻输出该节点的值，并继续遍历其左右子树。(根左右)
    // 中序：考察到一个节点后，将其暂存，遍历完左子树后，再输出该节点的值，然后遍历右子树。(左根右)
    // 后序：考察到一个节点后，将其暂存，遍历完左右子树后，再输出该节点的值。(左右根)
    // 递归 
    // 时间复杂度为 O(n) 
    // 空间复杂度为 O(n)，平均情况为 O(logn)。
    public IList<int> InorderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        InorderTraversal(root, list);
        return list;
    }

    public void InorderTraversal(TreeNode root, IList<int> list)
    {
        if (root == null) return;
        InorderTraversal(root.left, list);
        list.Add(root.val);
        InorderTraversal(root.right, list);
    }

    // 迭代 时间复杂度和空间复杂度都是 O(n)
    public IList<int> InorderTraversalLoop(TreeNode root)
    {
        IList<int> list = new List<int>();

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode visitor = root;

        while (visitor != null || stack.Count > 0)
        {
            while (visitor != null)
            {
                stack.Push(visitor);
                visitor = visitor.left;
            }
            visitor = stack.Pop();
            list.Add(visitor.val);
            visitor = visitor.right;
        }
        return list;
    }
}