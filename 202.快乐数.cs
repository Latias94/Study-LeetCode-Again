using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=202 lang=csharp
 *
 * [202] 快乐数
 *
 * https://leetcode-cn.com/problems/happy-number/description/
 *
 * algorithms
 * Easy (54.27%)
 * Likes:    142
 * Dislikes: 0
 * Total Accepted:    23.7K
 * Total Submissions: 43.6K
 * Testcase Example:  '19'
 *
 * 编写一个算法来判断一个数是不是“快乐数”。
 * 
 * 一个“快乐数”定义为：对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和，然后重复这个过程直到这个数变为 1，也可能是无限循环但始终变不到
 * 1。如果可以变为 1，那么这个数就是快乐数。
 * 
 * 示例: 
 * 
 * 输入: 19
 * 输出: true
 * 解释: 
 * 1^2 + 9^2 = 82
 * 8^2 + 2^2 = 68
 * 6^2 + 8^2 = 100
 * 1^2 + 0^2 + 0^2 = 1
 * 
 * 
 */
public class Solution0202
{
    public bool IsHappy(int n)
    {
        return IsHappy(n, new HashSet<int>());
    }

    public bool IsHappy(int n, HashSet<int> set)
    {
        int sum = 0;
        while (n >= 1)
        {
            int remainder = n % 10;
            n = n / 10;
            sum += remainder * remainder;
        }
        if (sum == 1) return true;
        if (set.Contains(sum)) return false;
        set.Add(sum);
        return IsHappy(sum, set);
    }
}