using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=144 lang=csharp
 *
 * [144] 二叉树的前序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-preorder-traversal/description/
 *
 * algorithms
 * Medium (60.63%)
 * Likes:    130
 * Dislikes: 0
 * Total Accepted:    31.1K
 * Total Submissions: 51.2K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的 前序 遍历。
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
 * 输出: [1,2,3]
 * 
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
public class Solution0144
{
    // 先序：考察到一个节点后，即刻输出该节点的值，并继续遍历其左右子树。(根左右)
    // 中序：考察到一个节点后，将其暂存，遍历完左子树后，再输出该节点的值，然后遍历右子树。(左根右)
    // 后序：考察到一个节点后，将其暂存，遍历完左右子树后，再输出该节点的值。(左右根)
    // 递归 
    // 时间复杂度为 O(n) 
    // 空间复杂度为 O(n)，平均情况为 O(logn)。
    public IList<int> PreorderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        PreorderTraversal(root, list);
        return list;
    }

    public void PreorderTraversal(TreeNode root, IList<int> list)
    {
        if (root == null) return;
        list.Add(root.val);
        PreorderTraversal(root.left, list);
        PreorderTraversal(root.right, list);
    }

    // 迭代 时间复杂度和空间复杂度都是 O(n)
    // 从根节点开始，每次迭代弹出当前栈顶元素，并将其孩子节点压入栈中，先压右孩子再压左孩子。
    public IList<int> PreorderTraversalLoop(TreeNode root)
    {
        if (root == null) return new List<int>();

        IList<int> list = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode visitor;
        stack.Push(root);

        while (stack.Count > 0)
        {
            visitor = stack.Pop();
            list.Add(visitor.val);

            // 注意添加的顺序，要先压右孩子再压左孩子
            if (visitor.right != null)
                stack.Push(visitor.right);
            if (visitor.left != null)
                stack.Push(visitor.left);
        }
        return list;
    }
}