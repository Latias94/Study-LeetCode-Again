using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=224 lang=csharp
 *
 * [224] 基本计算器
 *
 * https://leetcode-cn.com/problems/basic-calculator/description/
 *
 * algorithms
 * Hard (33.10%)
 * Likes:    78
 * Dislikes: 0
 * Total Accepted:    3K
 * Total Submissions: 8.9K
 * Testcase Example:  '"1 + 1"'
 *
 * 实现一个基本的计算器来计算一个简单的字符串表达式的值。
 * 
 * 字符串表达式可以包含左括号 ( ，右括号 )，加号 + ，减号 -，非负整数和空格  。
 * 
 * 示例 1:
 * 
 * 输入: "1 + 1"
 * 输出: 2
 * 
 * 
 * 示例 2:
 * 
 * 输入: " 2-1 + 2 "
 * 输出: 3
 * 
 * 示例 3:
 * 
 * 输入: "(1+(4+5+2)-3)+(6+8)"
 * 输出: 23
 * 
 * 说明：
 * 
 * 
 * 你可以假设所给定的表达式都是有效的。
 * 请不要使用内置的库函数 eval。
 * 
 * 
 */
public class Solution0224
{
    // (112 ms) Your runtime beats 100 % of csharp submissions
    // Your memory usage beats 100 % of csharp submissions (22.9 MB)
    public int Calculate(string s)
    {
        Stack<int> stack = new Stack<int>();
        int result = 0;
        int sign = 1; // 0 为负数
        int num = 0; // 数字

        foreach (char c in s)
        {
            if (Char.IsDigit(c))
            {
                num = num * 10 + (c - '0');
            }
            else if (c == '+' || c == '-')
            {
                result += num * sign;
                sign = c == '+' ? 1 : -1;
                num = 0;
            }
            else if (c == '(')
            {
                stack.Push(result);
                stack.Push(sign);
                sign = 1;
                result = 0;
            }
            else if (c == ')')
            {
                result += sign * num;
                int oldSign = stack.Pop();
                int oldResult = stack.Pop();
                result = oldResult + oldSign * result;
                sign = 1;
                num = 0;
            }
        }
        result += sign * num;
        return result;
    }
}