using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=844 lang=csharp
 *
 * [844] 比较含退格的字符串
 *
 * https://leetcode-cn.com/problems/backspace-string-compare/description/
 *
 * algorithms
 * Easy (47.56%)
 * Likes:    56
 * Dislikes: 0
 * Total Accepted:    7.6K
 * Total Submissions: 15.9K
 * Testcase Example:  '"ab#c"\n"ad#c"'
 *
 * 给定 S 和 T 两个字符串，当它们分别被输入到空白的文本编辑器后，判断二者是否相等，并返回结果。 # 代表退格字符。
 * 
 * 
 * 
 * 示例 1：
 * 
 * 输入：S = "ab#c", T = "ad#c"
 * 输出：true
 * 解释：S 和 T 都会变成 “ac”。
 * 
 * 
 * 示例 2：
 * 
 * 输入：S = "ab##", T = "c#d#"
 * 输出：true
 * 解释：S 和 T 都会变成 “”。
 * 
 * 
 * 示例 3：
 * 
 * 输入：S = "a##c", T = "#a#c"
 * 输出：true
 * 解释：S 和 T 都会变成 “c”。
 * 
 * 
 * 示例 4：
 * 
 * 输入：S = "a#c", T = "b"
 * 输出：false
 * 解释：S 会变成 “c”，但 T 仍然是 “b”。
 * 
 * 
 * 
 * 提示：
 * 
 * 
 * 1 <= S.length <= 200
 * 1 <= T.length <= 200
 * S 和 T 只含有小写字母以及字符 '#'。
 * 
 * 
 * 
 * 
 */
public class Solution0844
{
    // (104 ms) Your runtime beats 96.77 % of csharp submissions
    public bool BackspaceCompare(string S, string T)
    {
        Stack<char> stackS = RemoveBackspace(S);
        Stack<char> stackT = RemoveBackspace(T);
        if (stackS.Count != stackT.Count) return false;
        while (stackS.Count != 0)
        {
            if (stackS.Pop() != stackT.Pop())
                return false;
        }
        return true;
    }

    private Stack<char> RemoveBackspace(string s)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '#' && stack.Count > 0)
            {
                stack.Pop();
            }
            else if (s[i] != '#')
            {
                stack.Push(s[i]);
            }
        }
        return stack;
    }
}