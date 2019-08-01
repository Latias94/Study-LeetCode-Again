using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=20 lang=csharp
 *
 * [20] 有效的括号
 *
 * https://leetcode-cn.com/problems/valid-parentheses/description/
 *
 * algorithms
 * Easy (38.98%)
 * Likes:    945
 * Dislikes: 0
 * Total Accepted:    99.7K
 * Total Submissions: 255.7K
 * Testcase Example:  '"()"'
 *
 * 给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
 * 
 * 有效字符串需满足：
 * 
 * 
 * 左括号必须用相同类型的右括号闭合。
 * 左括号必须以正确的顺序闭合。
 * 
 * 
 * 注意空字符串可被认为是有效字符串。
 * 
 * 示例 1:
 * 
 * 输入: "()"
 * 输出: true
 * 
 * 
 * 示例 2:
 * 
 * 输入: "()[]{}"
 * 输出: true
 * 
 * 
 * 示例 3:
 * 
 * 输入: "(]"
 * 输出: false
 * 
 * 
 * 示例 4:
 * 
 * 输入: "([)]"
 * 输出: false
 * 
 * 
 * 示例 5:
 * 
 * 输入: "{[]}"
 * 输出: true
 * 
 */
public class Solution0020
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        char[] leftArr = new char[] { '(', '[', '{' };
        char[] rightArr = new char[] { ')', ']', '}' };
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (Contains(leftArr, c))
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count != 0)
                {
                    int index = IndexOf(leftArr, stack.Pop());
                    if (index != -1 && rightArr[index] != c)
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    private int IndexOf(char[] arr, char c)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == c) return i;
        }
        return -1;
    }

    private bool Contains(char[] arr, char c)
    {
        foreach (var e in arr)
        {
            if (e == c) return true;
        }
        return false;
    }
}