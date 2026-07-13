public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        List<int> result = new List<int>();

        string digits = "123456789";

        int minLength = low.ToString().Length;
        int maxLength = high.ToString().Length;

        for (int len = minLength; len <= maxLength; len++)
        {
            for (int start = 0; start + len <= digits.Length; start++)
            {
                int num = int.Parse(digits.Substring(start, len));

                if (num >= low && num <= high)
                {
                    result.Add(num);
                }
            }
        }

        return result;
    }
}