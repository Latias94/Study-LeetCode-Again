/*
 * @lc app=leetcode.cn id=509 lang=csharp
 *
 * [509] 斐波那契数
 *
 * https://leetcode-cn.com/problems/fibonacci-number/description/
 *
 * algorithms
 * Easy (65.37%)
 * Likes:    44
 * Dislikes: 0
 * Total Accepted:    14.6K
 * Total Submissions: 22.4K
 * Testcase Example:  '2'
 *
 * 斐波那契数，通常用 F(n) 表示，形成的序列称为斐波那契数列。该数列由 0 和 1 开始，后面的每一项数字都是前面两项数字的和。也就是：
 * 
 * F(0) = 0,   F(1) = 1
 * F(N) = F(N - 1) + F(N - 2), 其中 N > 1.
 * 
 * 
 * 给定 N，计算 F(N)。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：2
 * 输出：1
 * 解释：F(2) = F(1) + F(0) = 1 + 0 = 1.
 * 
 * 
 * 示例 2：
 * 
 * 输入：3
 * 输出：2
 * 解释：F(3) = F(2) + F(1) = 1 + 1 = 2.
 * 
 * 
 * 示例 3：
 * 
 * 输入：4
 * 输出：3
 * 解释：F(4) = F(3) + F(2) = 2 + 1 = 3.
 * 
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 0 ≤ N ≤ 30
 * 
 * 
 */
public class Solution0509
{
    public int Fib(int N)
    {
        int[] cacheArr = new int[N + 1];
        return Fib(N, 0, cacheArr);
    }

    public int Fib(int N, int current, int[] cacheArr)
    {
        if (current == 0) cacheArr[0] = 0;
        else if (current == 1) cacheArr[1] = 1;
        else
        {
            int pre = cacheArr[current - 1];
            int prepre = cacheArr[current - 2];
            int sum = pre + prepre;
            cacheArr[current] = sum;
        }
        if (current == N)
            return cacheArr[current];
        else
            return Fib(N, current + 1, cacheArr);
    }
}