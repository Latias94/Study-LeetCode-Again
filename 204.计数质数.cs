/*
 * @lc app=leetcode.cn id=204 lang=csharp
 *
 * [204] 计数质数
 *
 * https://leetcode-cn.com/problems/count-primes/description/
 *
 * algorithms
 * Easy (29.24%)
 * Likes:    180
 * Dislikes: 0
 * Total Accepted:    23K
 * Total Submissions: 78.6K
 * Testcase Example:  '10'
 *
 * 统计所有小于非负整数 n 的质数的数量。
 * 
 * 示例:
 * 
 * 输入: 10
 * 输出: 4
 * 解释: 小于 10 的质数一共有 4 个, 它们是 2, 3, 5, 7 。
 * 
 * 
 */
public class Solution0204
{
    // 埃拉托斯特尼筛法能够非常高效地生成素数序列，原理是剔除所有可被素数整除的非素数。
    // 一开始列出到max为止的所有数字。首先，划掉所有可被2整除的数（2保留）。然后，找到下
    // 一个素数（也即下一个不会被划掉的数），并划掉所有可被它整除的数。划掉所有可被2、3、5、7、11
    // 等素数整除的数，最终可得到2到max之间的素数序列。

    public int CountPrimes(int n)
    {
        if (n == 0 || n == 1) return 0;
        bool[] flags = new bool[n + 1];
        // 将flags中0、1元素除外的所有元素设为true 
        InitArray(flags);
        int prime = 2;
        int count = 0;
        while (prime < n)
        {
            // 划掉余下为 prime 倍数的数字
            CrossOff(flags, prime);
            count++;
            prime = GetNextPrime(flags, prime);
            if (prime >= flags.Length) break;
        }
        return count;
    }

    private int GetNextPrime(bool[] flags, int prime)
    {
        int next = prime + 1;
        while (next < flags.Length && !flags[next])
        {
            next++;
        }
        return next;
    }

    private void CrossOff(bool[] flags, int prime)
    {
        if (prime == 2) return;
        ulong len = (ulong) flags.Length;
        ulong longPrime = (ulong) prime;
        for (ulong i = longPrime * longPrime; i < len; i += longPrime)
        {
            flags[i] = false;
        }
    }

    private void InitArray(bool[] flags)
    {
        for (int i = 0; i < flags.Length; i++)
        {
            // 0, 1 和 2 的倍数都去掉
            if (i == 0 || i == 1)
                continue;
            if (i != 2 && i % 2 == 0)
                continue;
            flags[i] = true;
        }
    }
}