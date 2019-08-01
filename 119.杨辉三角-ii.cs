using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=119 lang=csharp
 *
 * [119] 杨辉三角 II
 *
 * https://leetcode-cn.com/problems/pascals-triangle-ii/description/
 *
 * algorithms
 * Easy (57.14%)
 * Likes:    77
 * Dislikes: 0
 * Total Accepted:    19.4K
 * Total Submissions: 34K
 * Testcase Example:  '3'
 *
 * 给定一个非负索引 k，其中 k ≤ 33，返回杨辉三角的第 k 行。
 * 
 * 
 * 
 * 在杨辉三角中，每个数是它左上方和右上方的数的和。
 * 
 * 示例:
 * 
 * 输入: 3
 * 输出: [1,3,3,1]
 * 
 * 
 * 进阶：
 * 
 * 你可以优化你的算法到 O(k) 空间复杂度吗？
 * 
 */
public class Solution0119
{
    // (304 ms) Your runtime beats 100 % of csharp submissions
    public IList<int> GetRow(int rowIndex)
    {
        IList<IList<int>> cacheList = new List<IList<int>>();
        return GenerateEachLayer(rowIndex, cacheList, 1);
    }

    public IList<int> GenerateEachLayer(int numRows, IList<IList<int>> list, int currentLayer)
    {
        if (currentLayer > numRows + 1)
            return list[numRows];
        if (currentLayer == 1)
            list.Add(new List<int> { 1 });
        else if (currentLayer == 2)
            list.Add(new List<int> { 1, 1 });
        else
        {
            int needToCalc = currentLayer / 2;
            bool isOught = currentLayer % 2 == 1;
            if (isOught)
                needToCalc += 1;
            List<int> currList = new List<int>();
            IList<int> preList = list[currentLayer - 2];
            for (int i = 0; i < needToCalc; i++)
            {
                if (i == 0)
                {
                    currList.Add(1);
                }
                else
                {
                    currList.Add(preList[i - 1] + preList[i]);
                }
            }
            for (int i = needToCalc; i < currentLayer; i++)
            {
                int index = currentLayer - i - 1;
                currList.Add(currList[index]);
            }
            list.Add(currList);
        }
        return GenerateEachLayer(numRows, list, currentLayer + 1);
    }
}