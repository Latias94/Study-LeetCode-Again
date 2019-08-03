# 重刷 LeetCode

用 C# 重刷一遍 LeetCode, Orz

框架：.Net Core Command Line Project（只是为了自动补全= =）

重学完数据结构（[Study-Data-Structure-Again](https://github.com/Latias94/Study-Data-Structure-Again)）后，重刷 LeetCode 准备面试~

vscode 插件：
* C#
* C# FixFormat
* Auto-Using for C#
* LeetCode

# 二分查找

推荐 LeetCode 的专题：[二分查找](https://leetcode-cn.com/explore/learn/card/binary-search/)

递归：

```csharp
public int Search(int[] nums, int target)
{
    return Search(nums, target, 0, nums.Length - 1);
}

public int Search(int[] nums, int target, int low, int high)
{
    int mid = ((high - low) >> 1) + low; // (high-low)/2+low 优化而来
    if (low <= high)
    {
        if (nums[mid] < target)
        {
            return Search(nums, target, mid + 1, high);
        }
        else if (nums[mid] > target)
        {
            return Search(nums, target, low, mid - 1);
        }
        else
        {
            return mid;
        }
    }
    return -1;
}
```

迭代

```csharp
public int Search(int[] nums, int target)
{
    int low = 0, high = nums.Length - 1;
    while (low <= high)
    {
        int mid = ((high - low) >> 1) + low;
        if (nums[mid] < target)
        {
            low = mid + 1;
        }
        else if (nums[mid] > target)
        {
            high = mid - 1;
        }
        else
        {
            return mid;
        }
    }
    return -1;
}
```

题目：704、33、69、374、278

## 二分查找变形

![](imgs\binary-search.png)

### 变体一：查找第一个值等于给定值的元素

例如题目：[[278] 第一个错误的版本](https://leetcode-cn.com/problems/first-bad-version/description/)

模板：

```csharp
public int Search(int[] nums, int target)
{
    int low = 0, high = nums.Length - 1;
    while (low <= high)
    {
        int mid = ((high - low) >> 1) + low;
        if (nums[mid] < target)
        {
            low = mid + 1;
        }
        else if (nums[mid] > target)
        {
            high = mid - 1;
        }
        else
        {   // 如果当前不是想要的值，就继续在前面的部分里找
                        if ((mid == 0) || (nums[mid - 1] != value)) return mid;
            else high = mid - 1;
        }
    }
    return -1;
}
```

### 变体二：查找最后一个值等于给定值的元素

```csharp
public int Search(int[] nums, int target)
{
    int low = 0, high = nums.Length - 1;
    while (low <= high)
    {
        int mid = ((high - low) >> 1) + low;
        if (nums[mid] < target)
        {
            low = mid + 1;
        }
        else if (nums[mid] > target)
        {
            high = mid - 1;
        }
        else
        {   // 和变体一相比，只改了下面两行，在后半部分寻找
                        if ((mid == nums.Length - 1) || (nums[mid + 1] != value)) return mid;
            else low = mid + 1;
        }
    }
    return -1;
}
```

### 变体三：查找第一个大于等于给定值的元素

```csharp
public int Search(int[] nums, int target)
{
    int low = 0, high = nums.Length - 1;
    while (low <= high)
    {
        int mid = ((high - low) >> 1) + low;
        if (nums[mid] >= target)
        {
                        if ((mid == 0) || (nums[mid - 1] < target)) return mid;
            high = mid - 1;
        } 
                else 
                { // nums[mid] < target
                        low = mid + 1;
                }
    }
    return -1;
}
```

### 变体四：查找最后一个小于等于给定值的元素

相似的就不写了

其他题目：153、162、367 等，更多看：[LeetCode 二分查找题](https://leetcode-cn.com/problemset/all/?topicSlugs=binary-search)

## LeetCode 模板

![](imgs\binary-search-leetcode.png)

这 3 个模板的不同之处在于：

- 左、中、右索引的分配。
- 循环或递归终止条件。
- 后处理的必要性。

模板 #1 和 #3 是最常用的，几乎所有二分查找问题都可以用其中之一轻松实现。模板 #2 更 高级一些，用于解决某些类型的问题。

这 3 个模板中的每一个都提供了一个特定的用例：

**模板 #1** `(left <= right)：`

- 二分查找的最基础和最基本的形式。
- 查找条件可以在不与元素的两侧进行比较的情况下确定（或使用它周围的特定元素）。
- 不需要后处理，因为每一步中，你都在检查是否找到了元素。如果到达末尾，则知道未找到该元素。

**模板 #2** `(left < right)：`

- 一种实现二分查找的高级方法。
- 查找条件需要访问元素的直接右邻居。
- 使用元素的右邻居来确定是否满足条件，并决定是向左还是向右。
- 保证查找空间在每一步中至少有 2 个元素。
- 需要进行后处理。 当你剩下 1 个元素时，循环 / 递归结束。 需要评估剩余元素是否符合条件。

**模板 #3** `(left + 1 < right)：`

- 实现二分查找的另一种方法。
- 搜索条件需要访问元素的直接左右邻居。
- 使用元素的邻居来确定它是向右还是向左。
- 保证查找空间在每个步骤中至少有 3 个元素。
- 需要进行后处理。 当剩下 2 个元素时，循环 / 递归结束。 需要评估其余元素是否符合条件。

# 参考
* 极客时间 - 数据结构与算法之美