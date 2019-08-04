using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=145 lang=csharp
 *
 * [145] 二叉树的后序遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-postorder-traversal/description/
 *
 * algorithms
 * Hard (66.96%)
 * Likes:    140
 * Dislikes: 0
 * Total Accepted:    23.5K
 * Total Submissions: 35.1K
 * Testcase Example:  '[1,null,2,3]'
 *
 * 给定一个二叉树，返回它的 后序 遍历。
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
 * 输出: [3,2,1]
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
public class Solution0145
{
    // 先序：考察到一个节点后，即刻输出该节点的值，并继续遍历其左右子树。(根左右)
    // 中序：考察到一个节点后，将其暂存，遍历完左子树后，再输出该节点的值，然后遍历右子树。(左根右)
    // 后序：考察到一个节点后，将其暂存，遍历完左右子树后，再输出该节点的值。(左右根)
    // 递归 
    // 时间复杂度为 O(n) 
    // 空间复杂度为 O(n)，平均情况为 O(logn)。
    public IList<int> PostorderTraversal(TreeNode root)
    {
        IList<int> list = new List<int>();
        PostorderTraversal(root, list);
        return list;
    }

    public void PostorderTraversal(TreeNode root, IList<int> list)
    {
        if (root == null) return;
        PostorderTraversal(root.left, list);
        PostorderTraversal(root.right, list);
        list.Add(root.val);
    }

    // 迭代 时间复杂度和空间复杂度都是 O(n)
    // 因为深度优先搜索后序遍历的顺序是从下到上、从左至右，所以需要将输出列表逆序输出。
    // 从根节点开始，每次迭代弹出当前栈顶元素，并将其孩子节点压入栈中，先压右孩子再压左孩子。
    public IList<int> PostorderTraversalLoop(TreeNode root)
    {
        if (root == null) return new List<int>();

        IList<int> list = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode visitor;
        stack.Push(root);

        while (stack.Count > 0)
        {
            visitor = stack.Pop();
            list.Insert(0, visitor.val); //逆序添加结点值

            // 注意添加的顺序，和传统先序遍历不一样，要先压左孩子再压右孩子
            if (visitor.left != null)
                stack.Push(visitor.left);
            if (visitor.right != null)
                stack.Push(visitor.right);
        }
        return list;
    }
}