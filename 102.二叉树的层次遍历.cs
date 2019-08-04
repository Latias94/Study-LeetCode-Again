using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=102 lang=csharp
 *
 * [102] 二叉树的层次遍历
 *
 * https://leetcode-cn.com/problems/binary-tree-level-order-traversal/description/
 *
 * algorithms
 * Medium (57.64%)
 * Likes:    246
 * Dislikes: 0
 * Total Accepted:    36K
 * Total Submissions: 62.3K
 * Testcase Example:  '[3,9,20,null,null,15,7]'
 *
 * 给定一个二叉树，返回其按层次遍历的节点值。 （即逐层地，从左到右访问所有节点）。
 * 
 * 例如:
 * 给定二叉树: [3,9,20,null,null,15,7],
 * 
 * ⁠   3
 * ⁠  / \
 * ⁠ 9  20
 * ⁠   /  \
 * ⁠  15   7
 * 
 * 
 * 返回其层次遍历结果：
 * 
 * [
 * ⁠ [3],
 * ⁠ [9,20],
 * ⁠ [15,7]
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
public class Solution0102
{
    // 执行用时 :364 ms, 在所有 C# 提交中击败了 96.25% 的用户
    public IList<IList<int>> LevelOrder(TreeNode root)
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
        return result;
    }
}