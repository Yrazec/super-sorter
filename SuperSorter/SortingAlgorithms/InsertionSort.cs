using System;
using System.Diagnostics;


namespace SuperSorter.SortingAlgorithms
{
    public class InsertionSort<T> : ISorter where T : IComparable
    {
        public readonly T[] OriginalArray;
        public readonly T[] SortedArray;

        public int Length { get; set; }
        public ulong Iterations { get; set; }
        public double SortingTime_ms { get; set; }

        public InsertionSort(T[] arr)
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

            for (int i = 1; i < Length; ++i)
            {
                T key = SortedArray[i];
                int j = i - 1;

                while ((j >= 0) && (key.CompareTo(SortedArray[j]) == -1))
                {
                    SortedArray[j + 1] = SortedArray[j];
                    j--;

                    Iterations++;
                }
                SortedArray[j + 1] = key;
            }

            watch.Stop();
            SortingTime_ms = (Convert.ToDouble(watch.ElapsedTicks) / Convert.ToDouble(Stopwatch.Frequency)) * 1000.0;
        }

        private void Globals(T[] arr)
        {
            Length = arr.Length;
            Iterations = 0;
            SortingTime_ms = 0.0;
        }
    }
}