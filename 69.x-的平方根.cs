/*
 * @lc app=leetcode.cn id=69 lang=csharp
 *
 * [69] x 的平方根
 *
 * https://leetcode-cn.com/problems/sqrtx/description/
 *
 * algorithms
 * Easy (36.52%)
 * Likes:    203
 * Dislikes: 0
 * Total Accepted:    48K
 * Total Submissions: 131.3K
 * Testcase Example:  '4'
 *
 * 实现 int sqrt(int x) 函数。
 * 
 * 计算并返回 x 的平方根，其中 x 是非负整数。
 * 
 * 由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。
 * 
 * 示例 1:
 * 
 * 输入: 4
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 输入: 8
 * 输出: 2
 * 说明: 8 的平方根是 2.82842..., 
 * 由于返回类型是整数，小数部分将被舍去。
 * 
 * 
 */
public class Solution0069
{
    public int MySqrt(int x)
    {
        return (int) MySqrt(0, x, x);
    }
    public long MySqrt(long low, long high, long target)
    {
        long mid = ((high - low) >> 1) + low;
        if (low <= high)
        {
            long midSqrt = mid * mid;
            if (midSqrt > target)
                return MySqrt(low, mid - 1, target);
            if (midSqrt < target)
                return MySqrt(mid + 1, high, target);
            else
                return mid;
        }
        return high;
    }
}