using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=113 lang=csharp
 *
 * [113] 路径总和 II
 *
 * https://leetcode-cn.com/problems/path-sum-ii/description/
 *
 * algorithms
 * Medium (56.36%)
 * Likes:    112
 * Dislikes: 0
 * Total Accepted:    12.9K
 * Total Submissions: 22.8K
 * Testcase Example:  '[5,4,8,11,null,13,4,7,2,null,null,5,1]\n22'
 *
 * 给定一个二叉树和一个目标和，找到所有从根节点到叶子节点路径总和等于给定目标和的路径。
 * 
 * 说明: 叶子节点是指没有子节点的节点。
 * 
 * 示例:
 * 给定如下二叉树，以及目标和 sum = 22，
 * 
 * ⁠             5
 * ⁠            / \
 * ⁠           4   8
 * ⁠          /   / \
 * ⁠         11  13  4
 * ⁠        /  \    / \
 * ⁠       7    2  5   1
 * 
 * 
 * 返回:
 * 
 * [
 * ⁠  [5,4,11,2],
 * ⁠  [5,8,4,5]
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
public class Solution0113
{
    public IList<IList<int>> PathSum(TreeNode root, int sum)
    {
        IList<IList<int>> result = new List<IList<int>>();
        PathSum(root, sum, new List<int>(), result);
        return result;
    }

    public void PathSum(TreeNode node, int sum, IList<int> list, IList<IList<int>> result)
    {
        if (node == null) return;
        int remain = sum - node.val;
        list.Add(node.val);
        if (node.left == null && node.right == null)
        {
            // 如果递归到叶子节点，且路径和为 0，则把路径放入结果列表中
            if (remain == 0)
                result.Add(new List<int>(list));
        }
        else
        {
            PathSum(node.left, remain, list, result);
            PathSum(node.right, remain, list, result);
        }
        list.RemoveAt(list.Count - 1);
    }
}