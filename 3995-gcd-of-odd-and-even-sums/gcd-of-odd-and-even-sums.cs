public class Solution {
    private int Gcd(int x, int y) {
        return y == 0 ? x : Gcd(y, x % y);
    }

    public int GcdOfOddEvenSums(int n) {
        return Gcd(n * n, n * (n + 1));
    }
}