using System;
using System.Collections.Generic;

public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        // Store the rank for each number
        Dictionary<int, int> numToRank = new Dictionary<int, int>();

        // Create a copy of the original array
        int[] sortedArr = (int[])arr.Clone();

        // Sort the copied array
        Array.Sort(sortedArr);

        int rank = 1;

        // Assign ranks to unique numbers
        for (int i = 0; i < sortedArr.Length; i++)
        {
            if (i > 0 && sortedArr[i] > sortedArr[i - 1])
            {
                rank++;
            }

            numToRank[sortedArr[i]] = rank;
        }

        // Replace each number in the original array with its rank
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = numToRank[arr[i]];
        }

        return arr;
    }
}