using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    public class SortHelper
    {
        public void BubbleSort(int[] array)
        {
            int length = array.Length;

            for (int k = length; k > 1; k--)
            {
                for (int i = 0; i < k - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
        public void BubbleSort(char[] array)
        {
            int length = array.Length;

            for (int k = length; k > 1; k--)
            {
                for (int i = 0; i < k - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        char temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
        public void BubbleSort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;

            for (int k = length; k > 1; k--)
            {
                for (int i = 0; i < k - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
    }
    public class SortHelper<T> where T : IComparable
    {
        public void BubbleSort(T[] array)
        {
            int length = array.Length;

            for (int k = length; k > 1; k--)
            {
                for (int i = 0; i < k - 1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
    }
}
