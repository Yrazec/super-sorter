using System;
using System.Diagnostics;


namespace SuperSorter.SortingAlgorithms
{
    public class BubbleSort<T> : ISorter where T : IComparable
    {
        public readonly T[] OriginalArray;
        public readonly T[] SortedArray;

        public int Length { get; set; }
        public ulong Iterations { get; set; }
        public double SortingTime_ms { get; set; }

        public BubbleSort(T[] arr)
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

            for (int write = 0; write < SortedArray.Length; write++)
            {
                for (int sort = 0; sort < SortedArray.Length - 1; sort++)
                {
                    if (SortedArray[sort + 1].CompareTo(SortedArray[sort]) == -1)
                    {
                        (SortedArray[sort], SortedArray[sort + 1]) = (SortedArray[sort + 1], SortedArray[sort]);
                    }

                    Iterations++;
                }
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