using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndFormattingAndGenerics
{
    public class QuickSorting<T> where T: IComparable
    {
        private void QuickSort(T[] items, int left, int right)
        {
            int i, j;
            i = left; j = right;
            IComparable pivot = items[left];

            while (i <= j)
            {
                for (; (items[i].CompareTo(pivot) < 0) && (i.CompareTo(right) < 0); i++) ;
                for (; (pivot.CompareTo(items[j]) < 0) && (j.CompareTo(left) > 0); j--) ;

                if (i <= j)
                    Swap(ref items[i++], ref items[j--]);

            }
            if (left < j) QuickSort(items, left, j);
            if (i < right) QuickSort(items, i, right);
        }

        private void Swap(ref T firstValue, ref T secondValue)
        {
            var temp = firstValue;
            firstValue = secondValue;
            secondValue = temp;
        }


    }
}
