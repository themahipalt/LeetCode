using System;

public class Solution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        Array.Sort(arr);

        int ans = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] >= ans + 1)
            {
                ans++;
            }
        }

        return ans;
    }
}