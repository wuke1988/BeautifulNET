using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortHelper helper = new SortHelper();
            int[] array = new int[] { 1, 8, 9, 7, 5, 2, 3, 4, 6, 1 };

            helper.BubbleSort(array);

            foreach (int i in array)
                Console.WriteLine(i);


            char[] array2 = new char[] { 'w', 'k', 'u', 'e' };
            helper.BubbleSort(array2);


            foreach (char i in array2)
                Console.WriteLine(i);


            SortHelper<int> helper2 = new SortHelper<int>();
            helper2.BubbleSort(array);

            helper.BubbleSort<char>(array2);


            Console.ReadLine();
        }
    }
}
