public class Solution {
    public int[] PathExistenceQueries(int n, int[] nums, int maxDiff,
                                      int[][] queries) {
        int[] idx = new int[n];
        for (int i = 0; i < n; i++) {
            idx[i] = i;
        }

        Array.Sort(idx, (a, b) => nums[a].CompareTo(nums[b]));

        int[] pos = new int[n];
        for (int i = 0; i < n; i++) {
            pos[idx[i]] = i;
        }

        int m = (int)Math.Ceiling(Math.Log2(n)) + 1;
        int[][] f = new int [n][];
        for (int i = 0; i < n; i++) {
            f[i] = new int[m];
        }

        int left = 0;
        for (int i = 0; i < n; i++) {
            while (left < i && nums[idx[i]] - nums[idx[left]] > maxDiff) {
                left++;
            }
            f[i][0] = left;
        }

        for (int j = 1; j < m; j++) {
            for (int i = 0; i < n; i++) {
                f[i][j] = f[f[i][j - 1]][j - 1];
            }
        }

        int[] res = new int[queries.Length];
        for (int q = 0; q < queries.Length; q++) {
            int x = pos[queries[q][0]];
            int y = pos[queries[q][1]];

            if (x == y) {
                res[q] = 0;
                continue;
            }

            if (x > y) {
                int temp = x;
                x = y;
                y = temp;
            }

            int step = 0;
            for (int i = m - 1; i >= 0; i--) {
                if (f[y][i] > x) {
                    y = f[y][i];
                    step += 1 << i;
                }
            }

            if (f[y][0] <= x) {
                res[q] = step + 1;
            } else {
                res[q] = -1;
            }
        }

        return res;
    }
}