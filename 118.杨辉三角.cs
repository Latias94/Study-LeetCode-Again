using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=118 lang=csharp
 *
 * [118] 杨辉三角
 *
 * https://leetcode-cn.com/problems/pascals-triangle/description/
 *
 * algorithms
 * Easy (63.31%)
 * Likes:    172
 * Dislikes: 0
 * Total Accepted:    30.6K
 * Total Submissions: 48.3K
 * Testcase Example:  '5'
 *
 * 给定一个非负整数 numRows，生成杨辉三角的前 numRows 行。
 * 
 * 
 * 
 * 在杨辉三角中，每个数是它左上方和右上方的数的和。
 * 
 * 示例:
 * 
 * 输入: 5
 * 输出:
 * [
 * ⁠    [1],
 * ⁠   [1,1],
 * ⁠  [1,2,1],
 * ⁠ [1,3,3,1],
 * ⁠[1,4,6,4,1]
 * ]
 * 
 */
public class Solution0118
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> result = new List<IList<int>>();
        GenerateEachLayer(numRows, result, 1);
        return result;
    }

    public void GenerateEachLayer(int numRows, IList<IList<int>> list, int currentLayer)
    {
        if (currentLayer > numRows) return;
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
        GenerateEachLayer(numRows, list, currentLayer + 1);
    }
}