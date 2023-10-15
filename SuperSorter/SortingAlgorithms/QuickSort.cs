using System;
using System.Diagnostics;


namespace SuperSorter.SortingAlgorithms
{
    public class QuickSort<T> : ISorter where T : IComparable
    {
        public readonly T[] OriginalArray;
        public readonly T[] SortedArray;

        public int Length { get; set; }
        public ulong Iterations { get; set; }
        public double SortingTime_ms { get; set; }

        public QuickSort(T[] arr)
        {
            Globals(arr);

            OriginalArray = new T[Length];
            SortedArray = new T[Length];

            Array.Copy(arr, OriginalArray, Length);
            Array.Copy(arr, SortedArray, Length);
        }

        public void Sort()
        {
            Stopwatch watch = Stopwatch.StartNew();

            QS(0, Length - 1);

            watch.Stop();
            SortingTime_ms = (Convert.ToDouble(watch.ElapsedTicks) / Convert.ToDouble(Stopwatch.Frequency)) * 1000.0;
        }

        private void QS(int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(left, right);

                if (pivot > 1)
                    QS(left, pivot - 1);
                if (pivot + 1 < right)
                    QS(pivot + 1, right);
            }
        }

        private int Partition(int left, int right)
        {
            T pivot = SortedArray[left];
            while (true)
            {
                while (pivot.CompareTo(SortedArray[left]) == 1)
                {
                    left++;
                    Iterations++;
                }

                while (pivot.CompareTo(SortedArray[right]) == -1)
                {
                    right--;
                    Iterations++;
                }

                Iterations++;

                if (left < right)
                {
                    if (SortedArray[left].CompareTo(SortedArray[right]) == 0)
                        return right;

                    (SortedArray[right], SortedArray[left]) = (SortedArray[left], SortedArray[right]);
                }
                else
                    return right;
            }
        }

        private void Globals(T[] arr)
        {
            Length = arr.Length;
            Iterations = 0;
            SortingTime_ms = 0.0;
        }
    }
}
