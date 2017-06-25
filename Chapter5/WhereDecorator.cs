using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter5
{
    /// <summary>
    /// 扩展方法：自行实现Where筛选函数
    /// </summary>
    public static class Enumerable
    {
        public static IEnumerable<TSource> WhereNew<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return new WhereDecorator<TSource>(source, predicate);
        }

    }
    /// <summary>
    /// 采用装饰者模式，实现Where方法
    /// 装饰者模式：继承一个类，且包含对该类对象的一个引用
    /// 每次在需要迭代（Foreach）的时候，迭代器WhereEnumerator会按照条件重新过滤对象集合并返回
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WhereDecorator<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private Predicate<T> _predicate;

        public WhereDecorator(IEnumerable<T> source, Predicate<T> predicate)
        {
            _source = source;
            _predicate = predicate;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new WhereEnumerator<T>(_source, _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new WhereEnumerator<T>(_source, _predicate);
        }

        public class WhereEnumerator<T> : IEnumerator<T>
        {
            private List<T> innerList;
            private int index;

            public WhereEnumerator(IEnumerable<T> list, Predicate<T> predicate)
            {
                innerList = new List<T>();
                index = -1;
                foreach (T item in list)
                {
                    if (predicate(item))
                    {
                        innerList.Add(item);
                    }
                }
            }

            public T Current
            {
                get
                {
                    return innerList[index];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return innerList[index];
                }
            }

            public void Dispose()
            {
                innerList.Clear();
                innerList = null;
            }

            public bool MoveNext()
            {
                index++;
                if (index < innerList.Count)
                    return true;
                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
