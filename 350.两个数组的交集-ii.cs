using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=350 lang=csharp
 *
 * [350] 两个数组的交集 II
 *
 * https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/description/
 *
 * algorithms
 * Easy (43.11%)
 * Likes:    171
 * Dislikes: 0
 * Total Accepted:    40.9K
 * Total Submissions: 94.8K
 * Testcase Example:  '[1,2,2,1]\n[2,2]'
 *
 * 给定两个数组，编写一个函数来计算它们的交集。
 * 
 * 示例 1:
 * 
 * 输入: nums1 = [1,2,2,1], nums2 = [2,2]
 * 输出: [2,2]
 * 
 * 
 * 示例 2:
 * 
 * 输入: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
 * 输出: [4,9]
 * 
 * 说明：
 * 
 * 
 * 输出结果中每个元素出现的次数，应与元素在两个数组中出现的次数一致。
 * 我们可以不考虑输出结果的顺序。
 * 
 * 
 * 进阶:
 * 
 * 
 * 如果给定的数组已经排好序呢？你将如何优化你的算法？
 * 如果 nums1 的大小比 nums2 小很多，哪种方法更优？
 * 如果 nums2 的元素存储在磁盘上，磁盘内存是有限的，并且你不能一次加载所有的元素到内存中，你该怎么办？
 * 
 * 
 */

// 进阶1：排好序的话可以迭代小数组的每一个元素，在大数组中进行二分查找
// 进阶2：如果考虑空间复杂度，则将小的数组放到哈希表中
// 进阶3：如果内存放得下 nums1 元素，就把 nums1 放哈希表里面一样查询
// 如果两个都放不进内存，就进行外部排序，再分别从两个数组中一个一个取元素对比
public class Solution0350
{
    // (360 ms) Your runtime beats 100 % of csharp submissions
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        if (nums1 == null || nums2 == null) return null;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            AddOrUpdateKey(dict, nums1[i]);
        }

        List<int> list = new List<int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            if (RemoveOrUpdateKey(dict, nums2[i]))
            {
                list.Add(nums2[i]);
            }
        }

        return list.ToArray();
    }

    private void AddOrUpdateKey(Dictionary<int, int> dict, int key)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = dict[key] + 1;
        }
        else
        {
            dict.Add(key, 1);
        }
    }

    private bool RemoveOrUpdateKey(Dictionary<int, int> dict, int key)
    {
        if (dict.ContainsKey(key))
        {
            if (dict[key] == 1)
                dict.Remove(key);
            else
                dict[key] = dict[key] - 1;
            return true;
        }
        return false;
    }
}