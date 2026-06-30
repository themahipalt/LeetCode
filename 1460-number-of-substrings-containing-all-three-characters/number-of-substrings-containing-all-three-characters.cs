public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int left = 0;
        int right = 0;
        int count = 0;


        int[] freq = new int[3];

        while (right < s.Length)
        {
            freq[s[right] - 'a']++;

            while (freq[0] > 0 && freq[1] > 0 && freq[2] > 0)
            {
                count += s.Length - right;

                freq[s[left] - 'a']--;
                left++;
            }

            right++;
        }

        return count;
    }
}