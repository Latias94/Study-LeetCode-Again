using System;
using System.Collections.Generic;
using System.Text;
/*
 * @lc app=leetcode.cn id=347 lang=csharp
 *
 * [347] 前 K 个高频元素
 *
 * https://leetcode-cn.com/problems/top-k-frequent-elements/description/
 *
 * algorithms
 * Medium (57.47%)
 * Likes:    144
 * Dislikes: 0
 * Total Accepted:    16.9K
 * Total Submissions: 29.3K
 * Testcase Example:  '[1,1,1,2,2,3]\n2'
 *
 * 给定一个非空的整数数组，返回其中出现频率前 k 高的元素。
 * 
 * 示例 1:
 * 
 * 输入: nums = [1,1,1,2,2,3], k = 2
 * 输出: [1,2]
 * 
 * 
 * 示例 2:
 * 
 * 输入: nums = [1], k = 1
 * 输出: [1]
 * 
 * 说明：
 * 
 * 
 * 你可以假设给定的 k 总是合理的，且 1 ≤ k ≤ 数组中不相同的元素的个数。
 * 你的算法的时间复杂度必须优于 O(n log n) , n 是数组的大小。
 * 
 * 
 */
public class Solution0347
{
    // 执行用时 :384 ms, 在所有 C# 提交中击败了 97.56% 的用户
    // topK 问题可以用优先队列（最大堆、最小堆）实现，本题用的最小堆的实现在最下面
    // 求 TopK，可以先将前 K 个元素拿来初始化（heapify）,再将后面的元素一个一个和堆顶（最小堆的最小值）比较，
    // 如果元素更大，则将堆顶移除，再插入元素。比堆顶小就不需要插入，因为这个元素比最小值还小
    // 最后留在堆中的就是前 k 个高频元素，但是堆顶是第 k 个高频元素，所以最后还要逆序输出
    public IList<int> TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            AddOrUpdateKey(dict, num);
        }
        Num[] numArray = new Num[dict.Count];
        int index = 0;
        foreach (KeyValuePair<int, int> pair in dict)
        {
            numArray[index++] = new Num(pair.Key, pair.Value);
        }

        // Heapify
        MinHeap<Num> minHeap = new MinHeap<Num>(Slice(numArray, 0, k));
        for (int i = k; i < numArray.Length; i++)
        {
            if (numArray[i].CompareTo(minHeap.GetMin()) > 0)
            {
                minHeap.ExtractMin();
                minHeap.Insert(numArray[i]);
            }
        }

        IList<int> results = new List<int>(k);
        for (int i = 0; i < k; i++)
        {
            // 如果要求结果从大到小排列，逆序插值即可。小到大排列则直接 Add
            results.Insert(0, minHeap.ExtractMin().Value);

            // 本题结果不要求按频率排序，因此可以忽略顺序，直接从堆中的数组取值
            results.Add(minHeap.data.Get(i).Value);
        }

        return results;
    }

    private void AddOrUpdateKey(Dictionary<int, int> dict, int key)
    {
        if (dict.ContainsKey(key))
        {
            dict[key]++;
        }
        else
        {
            dict.Add(key, 1);
        }
    }

    // 支持比较的数据结构，用在最小堆的泛型中
    public class Num : IComparable
    {
        public int Value;
        public int Count;
        public Num(int value, int count)
        {
            this.Value = value;
            this.Count = count;
        }
        public int CompareTo(object otherNum)
        {
            if (otherNum != null)
            {
                return Count.CompareTo(((Num) otherNum).Count);
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return "Value: " + Value + ", Count: " + Count;
        }
    }

    public T[] Slice<T>(T[] arr, int indexFrom, int indexTo)
    {
        if (indexFrom > indexTo)
        {
            throw new ArgumentOutOfRangeException("indexFrom is bigger than indexTo!");
        }

        int length = indexTo - indexFrom;
        T[] result = new T[length];
        Array.Copy(arr, indexFrom, result, 0, length);

        return result;
    }

    /// <summary>
    /// 基于之前实现的动态扩容数组来实现最小堆（二叉堆）结构
    /// 注意：跨 project 调用 Array 类，需要在 csproj 中添加引用，本项目已添加引用
    /// </summary>
    public class MinHeap<T> where T : IComparable
    {
        public Array<T> data;

        public MinHeap(int capacity)
        {
            data = new Array<T>(capacity);
        }

        public MinHeap()
        {
            data = new Array<T>();
        }

        /// <summary>
        /// Heapify: 将任意数组整理成堆的形状
        ///     操作：从不是叶子节点的最后一个节点开始，一个一个进行 sift down，
        ///          这样能少操作近乎占了一半的叶子结点
        ///     时间复杂度为 O(n)
        /// </summary>
        public MinHeap(T[] arr)
        {
            data = new Array<T>(arr);
            if (arr.Length <= 1) return;
            for (int i = Parent(arr.Length - 1); i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        public int Size()
        {
            return data.GetSize();
        }

        public bool IsEmpty()
        {
            return data.IsEmpty();
        }

        /// <summary>
        /// 索引所表示的节点 的父节点的索引
        /// </summary>
        /// <param name="index">要查询的节点索引</param>
        /// <returns>父节点索引</returns>
        private int Parent(int index)
        {
            if (index == 0)
            {
                throw new ArgumentException("index-0 doesn't have parent.");
            }

            // 二叉堆性质
            return (index - 1) / 2;
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的左孩子节点的索引
        /// </summary>
        /// <param name="index">要查询的节点索引</param>
        /// <returns>左孩子节点的索引</returns>
        private int LeftChild(int index)
        {
            return index * 2 + 1;
        }

        /// <summary>
        /// 返回完全二叉树的数组表示中，一个索引所表示的元素的右孩子节点的索引
        /// </summary>
        /// <param name="index">要查询的节点索引</param>
        /// <returns>右孩子节点的索引</returns>
        private int RightChild(int index)
        {
            return index * 2 + 2;
        }

        public void Insert(T element)
        {
            data.AddLast(element);
            SiftUp(data.GetSize() - 1);
        }

        private void SiftUp(int k)
        {
            // 只要节点比父节点小，就不断与父节点交换位置
            while (k > 0 && data.Get(Parent(k)).CompareTo(data.Get(k)) > 0)
            {
                data.Swap(k, Parent(k));
                k = Parent(k);
            }
        }

        private void SiftDown(int k)
        {
            while (LeftChild(k) < data.GetSize())
            {
                int j = LeftChild(k);
                if (j + 1 < data.GetSize() &&
                    data.Get(j + 1).CompareTo(data.Get(j)) < 0)
                {
                    // j 记录 k 左右子树中找比较小的值的索引
                    j++;
                }
                // 根据最小堆的性质，父节点要比左右子树节点都小
                // 如果 k 这个父节点比较大的子节点还小，就不用再操作了
                if (data.Get(k).CompareTo(data.Get(j)) <= 0)
                {
                    break;
                }
                // 将 k 父节点和较大值的节点交换位置
                data.Swap(k, j);
                k = j;
            }
        }

        /// <summary>
        /// 查看堆中的最小元素
        /// </summary>
        /// <returns>最小的元素</returns>
        public T GetMin()
        {
            if (data.GetSize() == 0)
            {
                throw new ArgumentException("Can not getMin when heap is empty.");
            }

            return data.Get(0);
        }

        /// <summary>
        /// 弹出出堆中最小元素
        /// </summary>
        /// <returns>最小的元素</returns>
        public T ExtractMin()
        {
            T max = GetMin();
            // 把最小的元素放到根节点，然后再端 sift down 还原堆结构
            data.Swap(0, data.GetSize() - 1);
            data.RemoveLast();
            SiftDown(0);
            return max;
        }

        /// <summary>
        /// 取出堆中的最小元素，并用新元素替换它
        /// </summary>
        /// <param name="element">新元素</param>
        /// <returns>取出的最小的元素</returns>
        public T Replace(T element)
        {
            T ret = GetMin();
            data.Set(0, element);
            SiftDown(0);
            return ret;
        }
    }

    public class Array<T>
    {
        /// <summary>
        /// 存储数据的数组
        /// </summary>
        private T[] data;

        /// <summary>
        /// 数组的容量(最多能容纳多少个元素)
        /// </summary>
        private int capacity;

        /// <summary>
        /// 数组目前有多少个元素
        /// </summary>
        private int size;

        /// <summary>
        /// 根据传入的容量量初始化
        /// </summary>
        /// <param name="capacity">数组容量</param>
        public Array(int capacity)
        {
            this.capacity = capacity;
            data = new T[capacity];
            size = 0;
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Array() : this(10) { }

        /// <summary>
        /// 将普通数组转成动态扩容数组
        /// </summary>
        public Array(T[] arr)
        {
            data = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                data[i] = arr[i];
            }

            size = arr.Length;
        }

        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// 获取数组中的数据容量(最多可以容纳多少元素)
        /// </summary>
        /// <returns>数组容量</returns>
        public int GetCapacity()
        {
            return capacity;
        }

        /// <summary>
        /// 判断数组中数据是否为空
        /// </summary>
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// 做一些预检查，比如范围、临界啊等等
        /// </summary>
        public void PreCheck()
        {
            if (size == data.Length)
            {
                throw new ArgumentException("容量已满！不能再添加新元素！");
            }
        }

        /// <summary>
        /// 向 data 中的 index 位置插入一个元素 e
        /// </summary>
        public void Insert(int index, T element)
        {
            // 动态扩容就不需要检查了
            //            PreCheck();
            if (index < 0 || index > size)
            {
                throw new ArgumentException("插入元素失败！index 的范围必须在[0, size)");
            }

            // 数组满了扩容一倍
            if (size == data.Length)
            {
                Resize(2 * capacity);
            }

            // index 后面的所有元素后移
            for (int i = size - 1; i >= index; i--)
            {
                data[i + 1] = data[i];
            }

            data[index] = element;
            size++;
        }

        /// <summary>
        /// 数组大小进行调整，根据数组元素数目决定数组是扩容还是缩容
        /// </summary>
        /// <param name="newCapacity">新容量</param>
        private void Resize(int newCapacity)
        {
            // 新的容量赋值
            capacity = newCapacity;
            T[] newData = new T[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[i];
            }

            // 释放原来的 data,指向新的 data
            data = newData;
        }

        /// <summary>
        /// 向所有元素最后加一个元素
        /// </summary>
        public void AddLast(T element)
        {
            Insert(size, element);
        }

        /// <summary>
        /// 向所有元素开始位置加一个元素
        /// </summary>
        public void AddFirst(T element)
        {
            Insert(0, element);
        }

        /// <summary>
        /// 获取最后的元素
        /// </summary>
        public T GetLast()
        {
            return Get(size - 1);
        }

        /// <summary>
        /// 获取第一个元素
        /// </summary>
        public T GetFirst()
        {
            return Get(0);
        }

        /// <summary>
        /// 获取指定位置的元素
        /// </summary>
        public T Get(int index)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentException("index 的范围必须在[0, size)");
            }

            return data[index];
        }

        /// <summary>
        /// 更新指定位置的元素
        /// </summary>
        /// <param name="index">要更新的索引位置</param>
        /// <param name="element">待更新元素</param>
        public void Set(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentException("index的范围必须在[0, size)");
            }

            data[index] = element;
        }

        /// <summary>
        /// 是否包含指定元素
        /// </summary>
        /// <param name="element">待查询元素</param>
        public bool Contain(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 查找指定元素
        /// </summary>
        /// <param name="element">待查询元素</param>
        /// <returns>所在索引</returns>
        public int Find(T element)
        {
            for (int i = 0; i < size; i++)
            {
                if (data[i].Equals(element))
                {
                    return i;
                }
            }

            // 没找到就返回-1
            return -1;
        }

        /// <summary>
        /// 从数组中删除 index 位置的元素，并返回删除的元素
        /// </summary>
        /// <param name="index">待删除所在的索引</param>
        /// <returns>删除的元素</returns>
        public T Remove(int index)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentException("index的范围必须在[0, size)");
            }

            T value = data[index];
            // index 位置开始，每个元素往前挪一位
            for (int i = index + 1; i < size; i++)
            {
                data[i - 1] = data[i];
            }

            size--;
            data[size] = default(T);
            // 当数组中元素数小于容量的 1/4 时，自动缩容为原来的一半
            // 之所以选 1/4 是为了防止频繁扩容和缩容引起性能下降
            if (size == capacity / 4 && data.Length / 2 != 0)
            {
                Resize(capacity / 2);
            }

            return value;
        }

        /// <summary>
        /// 删除数组头的元素
        /// </summary>
        /// <returns>删除的元素</returns>
        public T RemoveFirst()
        {
            return Remove(0);
        }

        /// <summary>
        /// 删除数组尾的元素
        /// </summary>
        /// <returns>删除的元素</returns>
        public T RemoveLast()
        {
            return Remove(size - 1);
        }

        /// <summary>
        /// 删除指定值的元素，不适用于存在重复元素的情况
        /// </summary>
        /// <param name="element">要删除的元素</param>
        public void RemoveElement(T element)
        {
            int index = Find(element);
            if (index != -1)
            {
                Remove(index);
            }
        }

        public void Swap(int i, int j)
        {
            if (i < 0 || i >= size || j < 0 || j >= size)
            {
                throw new ArgumentException("Index is illegal.");
            }

            T t = data[i];
            data[i] = data[j];
            data[j] = t;
        }

        public override string ToString()
        {
            return $"Array: capacity={capacity}, size={size}, data=[{ArrayToString()}]";
        }

        private string ArrayToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length - 1; i++)
            {
                sb.Append($"{data[i]}, ");
            }

            sb.Append($"{data[data.Length - 1]}");
            return sb.ToString();
        }
    }
}