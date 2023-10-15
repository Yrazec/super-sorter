namespace SuperSorter.SortingAlgorithms
{
    public interface ISorter
    {
        int Length { get; set; }
        ulong Iterations { get; set; }
        double SortingTime_ms { get; set; }

        void Sort();
    }
}