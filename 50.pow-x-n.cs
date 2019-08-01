/*
 * @lc app=leetcode.cn id=50 lang=csharp
 *
 * [50] Pow(x, n)
 *
 * https://leetcode-cn.com/problems/powx-n/description/
 *
 * algorithms
 * Medium (32.86%)
 * Likes:    136
 * Dislikes: 0
 * Total Accepted:    24.3K
 * Total Submissions: 74K
 * Testcase Example:  '2.00000\n10'
 *
 * 实现 pow(x, n) ，即计算 x 的 n 次幂函数。
 * 
 * 示例 1:
 * 
 * 输入: 2.00000, 10
 * 输出: 1024.00000
 * 
 * 
 * 示例 2:
 * 
 * 输入: 2.10000, 3
 * 输出: 9.26100
 * 
 * 
 * 示例 3:
 * 
 * 输入: 2.00000, -2
 * 输出: 0.25000
 * 解释: 2^-2 = 1/2^2 = 1/4 = 0.25
 * 
 * 说明:
 * 
 * 
 * -100.0 < x < 100.0
 * n 是 32 位有符号整数，其数值范围是 [−2^31, 2^31 − 1] 。
 * 
 * 
 */
public class Solution0050
{
    // 快速幂
    public double MyPow(double x, int n)
    {
        long N = n;
        if (N < 0)
        {
            x = 1 / x;
            N = N * -1;
        }
        return FastPow(x, N);
    }

    public double FastPow(double x, long n)
    {
        if (n == 0) return 1;
        double half = FastPow(x, n / 2);
        if (n % 2 == 1)
        {
            return half * half * x;
        }
        else
        {
            return half * half;
        }
    }

    // Stackoverflow 可以改成long long 不过还是太慢
    public double MyPowError(double x, int n)
    {
        if (n < 0)
        {
            x = 1 / x;
            n = n * -1;
        }
        if (n == 0) return 1;
        return x * MyPowError(x, n - 1);
    }

}