using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace SuperSorter.SortingAlgorithms
{
    public class BogoSort<T> : ISorter where T : IComparable
    {
        public readonly T[] OriginalArray;
        public readonly T[] SortedArray;

        private readonly Random rand;

        public int Length { get; set; }
        public ulong Iterations { get; set; }
        public double SortingTime_ms { get; set; }

        public BogoSort(T[] arr)
        {
            Globals(arr);

            OriginalArray = new T[Length];
            SortedArray = new T[Length];

            Array.Copy(arr, OriginalArray, Length);
            Array.Copy(arr, SortedArray, Length);

            rand = new Random();
        }

        public void Sort()
        {
            Stopwatch watch = Stopwatch.StartNew();

            while (!IsSorted(SortedArray))
                Array.Copy(Shuffle(SortedArray), SortedArray, SortedArray.Length);

            watch.Stop();
            SortingTime_ms = (Convert.ToDouble(watch.ElapsedTicks) / Convert.ToDouble(Stopwatch.Frequency)) * 1000.0;
        }

        private bool IsSorted(T[] arr)
        {
            for (int i = 0; i < (arr.Length - 1); i++)
            {
                if (arr[i + 1].CompareTo(arr[i]) == -1)
                    return false;
                Iterations++;
            }
            return true;
        }

        private T[] Shuffle(T[] arr)
        {
            List<T> list = new List<T>(arr);
            T[] tmp = new T[arr.Length];

            int numberOfElements = arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {
                int index = rand.Next(0, numberOfElements);
                tmp[i] = list[index];
                list.RemoveAt(index);
                numberOfElements--;
                Iterations++;
            }

            return tmp;
        }

        private void Globals(T[] arr)
        {
            Length = arr.Length;
            Iterations = 0;
            SortingTime_ms = 0.0;
        }
    }
}