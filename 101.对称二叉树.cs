using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
 *
 * https://leetcode-cn.com/problems/symmetric-tree/description/
 *
 * algorithms
 * Easy (47.68%)
 * Likes:    400
 * Dislikes: 0
 * Total Accepted:    44.8K
 * Total Submissions: 93.9K
 * Testcase Example:  '[1,2,2,3,4,4,3]'
 *
 * 给定一个二叉树，检查它是否是镜像对称的。
 * 
 * 例如，二叉树 [1,2,2,3,4,4,3] 是对称的。
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   2
 * ⁠/ \ / \
 * 3  4 4  3
 * 
 * 
 * 但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:
 * 
 * ⁠   1
 * ⁠  / \
 * ⁠ 2   2
 * ⁠  \   \
 * ⁠  3    3
 * 
 * 
 * 说明:
 * 
 * 如果你可以运用递归和迭代两种方法解决这个问题，会很加分。
 * 
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode leftNode;
 *     public TreeNode rightNode;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution0101
{
    // 递归实现
    public bool IsSymmetric(TreeNode root)
    {
        if (root == null) return true;
        return IsSymmetric(root.left, root.right);
    }

    public bool IsSymmetric(TreeNode leftNode, TreeNode rightNode)
    {
        if (leftNode == null && rightNode == null) return true;
        if (leftNode == null || rightNode == null) return false;
        return leftNode.val == rightNode.val &&
            IsSymmetric(leftNode.left, rightNode.right) &&
            IsSymmetric(leftNode.right, rightNode.left);
    }

    // 迭代实现
    public bool IsSymmetricLoop(TreeNode root)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(root);
        while (queue.Count != 0)
        {
            TreeNode leftNode = queue.Dequeue();
            TreeNode rightNode = queue.Dequeue();
            if (leftNode == null && rightNode == null) continue;
            if (leftNode == null || rightNode == null) return false;
            if (leftNode.val != rightNode.val) return false;
            queue.Enqueue(leftNode.left);
            queue.Enqueue(rightNode.right);
            queue.Enqueue(leftNode.right);
            queue.Enqueue(rightNode.left);
        }
        return true;
    }
}