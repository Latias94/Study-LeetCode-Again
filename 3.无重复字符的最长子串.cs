using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=3 lang=csharp
 *
 * [3] 无重复字符的最长子串
 *
 * https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/description/
 *
 * algorithms
 * Medium (30.51%)
 * Likes:    2115
 * Dislikes: 0
 * Total Accepted:    166.9K
 * Total Submissions: 546.9K
 * Testcase Example:  '"abcabcbb"'
 *
 * 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
 * 
 * 示例 1:
 * 
 * 输入: "abcabcbb"
 * 输出: 3 
 * 解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
 * 
 * 
 * 示例 2:
 * 
 * 输入: "bbbbb"
 * 输出: 1
 * 解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
 * 
 * 
 * 示例 3:
 * 
 * 输入: "pwwkew"
 * 输出: 3
 * 解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
 * 请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
 * 
 * 
 */
public class Solution0003
{
    // 滑动窗口
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int result = 0;
        for (int i = 0, j = 0; j < s.Length; j++)
        {
            if (dict.ContainsKey(s[j]))
            {
                // 这样可以忽略从字典删除索引的操作，只需比较索引大小
                i = Math.Max(dict[s[j]], i);
            }
            result = Math.Max(result, j - i + 1);
            AddOrUpdateKey(dict, s[j], j + 1);
        }
        return result;
    }

    private void AddOrUpdateKey(Dictionary<char, int> dict, char key, int value)
    {
        if (dict.ContainsKey(key))
        {
            dict[key] = value;
        }
        else
        {
            dict.Add(key, value);
        }
    }
}