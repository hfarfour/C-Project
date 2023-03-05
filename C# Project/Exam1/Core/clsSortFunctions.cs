using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1.Core
{
    public enum SortFunctions
    {
        Quick = 1,
        Bubble = 2
    }

    public class clsSortFunctions
    {
        private long[] data;

        public void setData(long[] value)
        {
            this.data = value;
        }

        public long[] getData()
        {
            return this.data;
        }

        public void setDataList(List<long> value)
        {
            this.data = value.ToArray();
        }

        public List<long> getDataList()
        {
            return this.data.ToList<long>();
        }

        public void sort(SortFunctions SortType)
        {
            string type = SortType.ToString();
            if (type == "Quick")
            {
                QuickSort(data);
            }
            else
            {
                Bubble_Sort(data);
            }
        }

        private void QuickSort<T>(T[] data)
        {
            Quick_Sort(data, 0, data.Length - 1, Comparer<T>.Default);
        }

        private void QuickSort<T>(T[] data, IComparer<T> comparer)
        {
            Quick_Sort(data, 0, data.Length - 1, comparer);

        }
        private void Quick_Sort<T>(T[] data, long left, long right, IComparer<T> comparer)
        {
            long i, j;
            T pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((comparer.Compare(data[i], pivot) < 0) && (i < right)) i++;
                while ((comparer.Compare(pivot, data[j]) < 0) && (j > left)) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) Quick_Sort(data, left, j, comparer);
            if (i < right) Quick_Sort(data, i, right, comparer);
        }

        private void Bubble_Sort(long[] data)
        {
            long len = data.Length;

            for (long i = 0; i < len; i++)
            {
                for (long j = 0; j < len; j++)
                {
                    long a = data[j];
                    if (a != data[len - 1])
                    {
                        long b = data[j + 1];
                        if (a > b)
                        {
                            data[j] = b;
                            data[j + 1] = a;
                        }
                    }
                }
            }
        }
    }
}
