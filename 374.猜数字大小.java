/*
 * @lc app=leetcode.cn id=374 lang=java
 *
 * [374] 猜数字大小
 *
 * https://leetcode-cn.com/problems/guess-number-higher-or-lower/description/
 *
 * algorithms Easy (39.47%) Likes: 35 Dislikes: 0 Total Accepted: 8.9K Total Submissions: 22.5K
 * Testcase Example: '10\n6'
 *
 * 我们正在玩一个猜数字游戏。 游戏规则如下： 我从 1 到 n 选择一个数字。 你需要猜我选择了哪个数字。 每次你猜错了，我会告诉你这个数字是大了还是小了。
 * 你调用一个预先定义好的接口 guess(int num)，它会返回 3 个可能的结果（-1，1 或 0）：
 * 
 * -1 : 我的数字比较小 ⁠1 : 我的数字比较大 ⁠0 : 恭喜！你猜对了！
 * 
 * 
 * 示例 :
 * 
 * 输入: n = 10, pick = 6 输出: 6
 * 
 */
/*
 * The guess API is defined in the parent class GuessGame.
 * 
 * @param num, your guess
 * 
 * @return -1 if my number is lower, 1 if my number is higher, otherwise return 0 int guess(int
 * num);
 */

public class Solution0384 extends GuessGame {
    // 这道题不支持 C#，因此用 Java 做了
    public int guessNumber(int n) {
        int low = 0, high = n;
        while (low <= high) {
            int mid = ((high - low) >> 1) + low;
            if (guess(mid) == -1) {
                high = mid - 1;
            } else if (guess(mid) == 1) {
                low = mid + 1;
            } else {
                return mid;
            }
        }
        return -1;
    }
}

