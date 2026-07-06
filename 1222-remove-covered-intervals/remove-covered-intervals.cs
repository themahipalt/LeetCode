public class Solution
{
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0])
                return b[1].CompareTo(a[1]); // End descending
            return a[0].CompareTo(b[0]);     // Start ascending
        });

        int remaining = 0;
        int maxEnd = -1;

        foreach (var interval in intervals)
        {
            if (interval[1] > maxEnd)
            {
                remaining++;
                maxEnd = interval[1];
            }
            // else: interval is covered
        }

        return remaining;
    }
}