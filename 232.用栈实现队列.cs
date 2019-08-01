using System.Collections.Generic;
/*
 * @lc app=leetcode.cn id=232 lang=csharp
 *
 * [232] 用栈实现队列
 *
 * https://leetcode-cn.com/problems/implement-queue-using-stacks/description/
 *
 * algorithms
 * Easy (60.57%)
 * Likes:    84
 * Dislikes: 0
 * Total Accepted:    15.8K
 * Total Submissions: 26K
 * Testcase Example:  '["MyQueue","push","push","peek","pop","empty"]\n[[],[1],[2],[],[],[]]'
 *
 * 使用栈实现队列的下列操作：
 * 
 * 
 * push(x) -- 将一个元素放入队列的尾部。
 * pop() -- 从队列首部移除元素。
 * peek() -- 返回队列首部的元素。
 * empty() -- 返回队列是否为空。
 * 
 * 
 * 示例:
 * 
 * MyQueue queue = new MyQueue();
 * 
 * queue.push(1);
 * queue.push(2);  
 * queue.peek();  // 返回 1
 * queue.pop();   // 返回 1
 * queue.empty(); // 返回 false
 * 
 * 说明:
 * 
 * 
 * 你只能使用标准的栈操作 -- 也就是只有 push to top, peek/pop from top, size, 和 is empty
 * 操作是合法的。
 * 你所使用的语言也许不支持栈。你可以使用 list 或者 deque（双端队列）来模拟一个栈，只要是标准的栈操作即可。
 * 假设所有操作都是有效的 （例如，一个空的队列不会调用 pop 或者 peek 操作）。
 * 
 * 
 */
public class MyQueue
{
    /** Initialize your data structure here. */
    Stack<int> stack;
    Stack<int> tempStack;
    int front;

    public MyQueue()
    {
        stack = new Stack<int>();
        tempStack = new Stack<int>();
    }

    /** Push element x to the back of queue. */
    public void Push(int x)
    {
        if (stack.Count == 0)
            front = x;
        stack.Push(x);
    }

    /** Removes the element from in front of queue and returns that element. */
    public int Pop()
    {
        if (tempStack.Count == 0)
        {
            while (stack.Count != 0)
            {
                tempStack.Push(stack.Pop());
            }
        }

        return tempStack.Pop();
    }

    /** Get the front element. */
    public int Peek()
    {
        if (tempStack.Count != 0)
            return tempStack.Peek();
        else
            return front;
    }

    /** Returns whether the queue is empty. */
    public bool Empty()
    {
        return stack.Count == 0 && tempStack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */