/*
 * @lc app=leetcode.cn id=70 lang=csharp
 *
 * [70] 爬楼梯
 *
 * https://leetcode-cn.com/problems/climbing-stairs/description/
 *
 * algorithms
 * Easy (46.19%)
 * Likes:    552
 * Dislikes: 0
 * Total Accepted:    63.9K
 * Total Submissions: 138.2K
 * Testcase Example:  '2'
 *
 * 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
 * 
 * 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
 * 
 * 注意：给定 n 是一个正整数。
 * 
 * 示例 1：
 * 
 * 输入： 2
 * 输出： 2
 * 解释： 有两种方法可以爬到楼顶。
 * 1.  1 阶 + 1 阶
 * 2.  2 阶
 * 
 * 示例 2：
 * 
 * 输入： 3
 * 输出： 3
 * 解释： 有三种方法可以爬到楼顶。
 * 1.  1 阶 + 1 阶 + 1 阶
 * 2.  1 阶 + 2 阶
 * 3.  2 阶 + 1 阶
 * 
 * 
 */
public class Solution0070
{
    // 就是斐波那契问题
    // (52 ms) Your runtime beats 99.53 % of csharp submissions
    public int ClimbStairs(int n)
    {
        int[] cacheArr = new int[n];
        return ClimbStair(n, 1, cacheArr);
    }

    public int ClimbStair(int n, int current, int[] cacheArr)
    {
        if (current == 1) cacheArr[0] = 1;
        else if (current == 2) cacheArr[1] = 2;
        else
        {
            int pre = cacheArr[current - 2];
            int prepre = cacheArr[current - 3];
            int sum = pre + prepre;
            cacheArr[current - 1] = sum;
        }
        if (current == n)
            return cacheArr[current - 1];
        else
            return ClimbStair(n, current + 1, cacheArr);
    }
}