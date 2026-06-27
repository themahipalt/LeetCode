public class Solution
{
    public int MaximumLength(int[] nums)
    {
        Dictionary<long, int> freq = new Dictionary<long, int>();

        // Count frequency of each number
        foreach (int num in nums)
        {
            if (freq.ContainsKey(num))
                freq[num]++;
            else
                freq[num] = 1;
        }

        int answer = 1;

        // Handle number 1 separately
        if (freq.ContainsKey(1))
        {
            int count = freq[1];

            if (count % 2 == 0)
                answer = count - 1;
            else
                answer = count;

            freq.Remove(1);
        }

        // Try every number as a starting point
        foreach (long start in freq.Keys)
        {
            long current = start;
            int length = 0;

            // Continue while current number appears at least twice
            while (freq.ContainsKey(current) && freq[current] >= 2)
            {
                length += 2;
                current = current * current;
            }

            // Check if the last squared number exists
            if (freq.ContainsKey(current))
                length += 1;
            else
                length -= 1;

            answer = Math.Max(answer, length);
        }

        return answer;
    }
}