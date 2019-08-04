using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=107 lang=csharp
 *
 * [107] 二叉树的层次遍历 II
 *
 * https://leetcode-cn.com/problems/binary-tree-level-order-traversal-ii/description/
 *
 * algorithms
 * Easy (61.54%)
 * Likes:    123
 * Dislikes: 0
 * Total Accepted:    20.9K
 * Total Submissions: 33.9K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其节点值自底向上的层次遍历。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）
 * 
 * 例如：
 * 给定二叉树 [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回其自底向上的层次遍历为：
 * 
 * [
 * ⁠ [15,7],
 * ⁠ [9,20],
 * ⁠ [3]
 * ]
 * 
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
public class Solution0107
{
    // 偷个懒，直接将 [102] 二叉树的层次遍历结果的列表反转
    public IList<IList<int>> LevelOrderBottom(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        result.Add(new List<int> { root.val });
        while (queue.Count > 0)
        {
            List<TreeNode> list = new List<TreeNode>();
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null)
                    list.Add(node.left);
                if (node.right != null)
                    list.Add(node.right);
            }
            if (list.Count > 0)
            {
                List<int> varList = new List<int>();
                for (int i = 0; i < list.Count; i++)
                {
                    varList.Add(list[i].val);
                }
                result.Add(varList);

                foreach (TreeNode node in list)
                {
                    queue.Enqueue(node);
                }
            }
        }
        IList<IList<int>> reverseList = new List<IList<int>>(result.Count);
        for (int i = result.Count - 1; i >= 0; i--)
        {
            reverseList.Add(result[i]);
        }
        return reverseList;
    }
}