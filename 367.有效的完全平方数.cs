using System;
/*
 * @lc app=leetcode.cn id=367 lang=csharp
 *
 * [367] 有效的完全平方数
 *
 * https://leetcode-cn.com/problems/valid-perfect-square/description/
 *
 * algorithms
 * Easy (41.61%)
 * Likes:    58
 * Dislikes: 0
 * Total Accepted:    12.3K
 * Total Submissions: 29.6K
 * Testcase Example:  '16'
 *
 * 给定一个正整数 num，编写一个函数，如果 num 是一个完全平方数，则返回 True，否则返回 False。
 * 
 * 说明：不要使用任何内置的库函数，如  sqrt。
 * 
 * 示例 1：
 * 
 * 输入：16
 * 输出：True
 * 
 * 示例 2：
 * 
 * 输入：14
 * 输出：False
 * 
 * 
 */
public class Solution0367
{
    // 如果用二分法，输入的平方数可能会超出 Int 范围，ulong 勉强算是通过了
    public bool IsPerfectSquare(int num)
    {
        if (num == 1) return true;
        ulong target = (ulong) num;
        ulong low = 1, high = target / 2;
        while (low <= high)
        {
            ulong mid = ((high - low) >> 1) + low;
            ulong midSquare = mid * mid;
            if (midSquare == target) return true;
            if (midSquare > target) high = mid - 1;
            if (midSquare < target) low = mid + 1;
        }
        return false;
    }

    // 利用 1+3+5+7+9+…+(2n-1)=n^2，即完全平方数肯定是前n个连续奇数的和
    public bool IsPerfectSquare1(int num)
    {
        for (int i = 1; i <= num; i += 2)
        {
            num -= i;
            if (num == 0) return true;
            if (num < 0) break;
        }
        return false;
    }
}