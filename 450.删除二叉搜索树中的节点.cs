/*
 * @lc app=leetcode.cn id=450 lang=csharp
 *
 * [450] 删除二叉搜索树中的节点
 *
 * https://leetcode-cn.com/problems/delete-node-in-a-bst/description/
 *
 * algorithms
 * Medium (35.54%)
 * Likes:    77
 * Dislikes: 0
 * Total Accepted:    4.1K
 * Total Submissions: 11.4K
 * Testcase Example:  '[5,3,6,2,4,null,7]\n3'
 *
 * 给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key
 * 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的根节点的引用。
 * 
 * 一般来说，删除节点可分为两个步骤：
 * 
 * 
 * 首先找到需要删除的节点；
 * 如果找到了，删除它。
 * 
 * 
 * 说明： 要求算法时间复杂度为 O(h)，h 为树的高度。
 * 
 * 示例:
 * 
 * 
 * root = [5,3,6,2,4,null,7]
 * key = 3
 * 
 * ⁠   5
 * ⁠  / \
 * ⁠ 3   6
 * ⁠/ \   \
 * 2   4   7
 * 
 * 给定需要删除的节点值是 3，所以我们首先找到 3 这个节点，然后删除它。
 * 
 * 一个正确的答案是 [5,4,6,2,null,null,7], 如下图所示。
 * 
 * ⁠   5
 * ⁠  / \
 * ⁠ 4   6
 * ⁠/     \
 * 2       7
 * 
 * 另一个正确答案是 [5,2,6,null,4,null,7]。
 * 
 * ⁠   5
 * ⁠  / \
 * ⁠ 2   6
 * ⁠  \   \
 * ⁠   4   7
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
public class Solution0450
{
    // 执行用时 :164 ms, 在所有 C# 提交中击败了 100.00% 的用户
    // 内存消耗 : 29 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null) return null;
        TreeNode p = root; // p 指向要删除的节点，初始化指向根节点
        TreeNode pp = null; // pp 记录的是 p 的父节点
        while (p != null && p.val != key)
        {
            pp = p;
            if (key > p.val)
                p = p.right;
            else
                p = p.left;
        }
        if (p == null) return root; // 找不到

        // 如果要删除的节点有两个子节点，这就比较复杂了
        // 我们需要找到这个节点的右子树中的最小节点，把它替换到要删除的节点上。然后再删除掉这个最小节点，
        // 因为最小节点肯定没有左子节点（如果有左子结点，那就不是最小节点了）
        if (p.left != null && p.right != null)
        {
            TreeNode minP = p.right;
            TreeNode minPP = p;
            while (minP.left != null)
            {
                minPP = minP;
                minP = minP.left;
            }
            p.val = minP.val;
            p = minP; // 下面就变成了删除 minP 了
            pp = minPP;
        }

        // 删除节点是叶子节点或者仅有一个子节点
        TreeNode child;
        if (p.left != null) child = p.left;
        else if (p.right != null) child = p.right;
        else child = null;

        if (pp == null) root = child;
        else if (pp.left == p) pp.left = child;
        else pp.right = child;

        return root;
    }

    // 递归，参考《算法（第4版）》- 3.2 二叉查找树
    public TreeNode DeleteNodeRecursive(TreeNode root, int key)
    {
        if (root == null) return null;
        if (key < root.val)
        {
            root.left = DeleteNodeRecursive(root.left, key);
            return root;
        }
        else if (key > root.val)
        {
            root.right = DeleteNodeRecursive(root.right, key);
            return root;
        }
        else
        {
            // 返回右子树作为新的根
            if (root.left == null) return root.right;
            // 返回左子树作为新的根
            else if (root.right == null) return root.left;
            else
            {
                // 左右子树都存在，返回后继节点（右子树最左叶子）作为新的根
                TreeNode successor = Min(root.right);
                successor.right = DeleteMin(root.right);
                successor.left = root.left;
                return successor;
            }
        }
    }
    private TreeNode Min(TreeNode node)
    {
        if (node.left == null) return node;
        return Min(node.left);
    }

    private TreeNode DeleteMin(TreeNode node)
    {
        if (node.left == null) return node.right;
        node.left = DeleteMin(node.left);
        return node;
    }
}