using System.Collections;
/*
 * @lc app=leetcode.cn id=155 lang=csharp
 *
 * [155] 最小栈
 *
 * https://leetcode-cn.com/problems/min-stack/description/
 *
 * algorithms
 * Easy (49.28%)
 * Likes:    248
 * Dislikes: 0
 * Total Accepted:    35.6K
 * Total Submissions: 72.2K
 * Testcase Example:  '["MinStack","push","push","push","getMin","pop","top","getMin"]\n[[],[-2],[0],[-3],[],[],[],[]]'
 *
 * 设计一个支持 push，pop，top 操作，并能在常数时间内检索到最小元素的栈。
 * 
 * 
 * push(x) -- 将元素 x 推入栈中。
 * pop() -- 删除栈顶的元素。
 * top() -- 获取栈顶元素。
 * getMin() -- 检索栈中的最小元素。
 * 
 * 
 * 示例:
 * 
 * MinStack minStack = new MinStack();
 * minStack.push(-2);
 * minStack.push(0);
 * minStack.push(-3);
 * minStack.getMin();   --> 返回 -3.
 * minStack.pop();
 * minStack.top();      --> 返回 0.
 * minStack.getMin();   --> 返回 -2.
 * 
 * 
 */
public class MinStack
{
    /** initialize your data structure here. */
    Stack stack, minStack;

    public MinStack()
    {
        stack = new Stack();
        minStack = new Stack();
    }

    public void Push(int x)
    {
        stack.Push(x);
        if (minStack.Count == 0 || x <= (int) minStack.Peek())
            minStack.Push(x);
    }

    public void Pop()
    {
        int num = (int) stack.Pop();
        if (num == (int) minStack.Peek())
            minStack.Pop();
    }

    public int Top()
    {
        return (int) stack.Peek();
    }

    public int GetMin()
    {
        return (int) minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */