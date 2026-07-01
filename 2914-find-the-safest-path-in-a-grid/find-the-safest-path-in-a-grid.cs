using System;
using System.Collections.Generic;

public class Solution
{
    // Directions: right, left, down, up
    private int[][] dir = new int[][]
    {
        new int[] { 0, 1 },
        new int[] { 0, -1 },
        new int[] { 1, 0 },
        new int[] { -1, 0 }
    };

    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        int n = grid.Count;

        Queue<(int row, int col)> multiSourceQueue = new Queue<(int row, int col)>();

        // Step 1: Put all thief cells into queue
        // thief cell = 0
        // empty cell = -1
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    multiSourceQueue.Enqueue((i, j));
                    grid[i][j] = 0;
                }
                else
                {
                    grid[i][j] = -1;
                }
            }
        }

        // Step 2: Multi-source BFS to calculate distance from nearest thief
        while (multiSourceQueue.Count > 0)
        {
            int size = multiSourceQueue.Count;

            while (size > 0)
            {
                var curr = multiSourceQueue.Dequeue();

                foreach (var d in dir)
                {
                    int newRow = curr.row + d[0];
                    int newCol = curr.col + d[1];

                    int currentValue = grid[curr.row][curr.col];

                    if (IsValidCell(grid, newRow, newCol) && grid[newRow][newCol] == -1)
                    {
                        grid[newRow][newCol] = currentValue + 1;
                        multiSourceQueue.Enqueue((newRow, newCol));
                    }
                }

                size--;
            }
        }

        // Step 3: Binary search on safeness factor
        int start = 0;
        int end = 0;
        int result = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                end = Math.Max(end, grid[i][j]);
            }
        }

        while (start <= end)
        {
            int mid = start + (end - start) / 2;

            if (IsValidSafeness(grid, mid))
            {
                result = mid;
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }

        return result;
    }

    private bool IsValidCell(IList<IList<int>> grid, int i, int j)
    {
        int n = grid.Count;

        return i >= 0 && j >= 0 && i < n && j < n;
    }

    private bool IsValidSafeness(IList<IList<int>> grid, int minSafeness)
    {
        int n = grid.Count;

        // Source or destination itself is not safe enough
        if (grid[0][0] < minSafeness || grid[n - 1][n - 1] < minSafeness)
        {
            return false;
        }

        Queue<(int row, int col)> traversalQueue = new Queue<(int row, int col)>();
        bool[,] visited = new bool[n, n];

        traversalQueue.Enqueue((0, 0));
        visited[0, 0] = true;

        while (traversalQueue.Count > 0)
        {
            var curr = traversalQueue.Dequeue();

            if (curr.row == n - 1 && curr.col == n - 1)
            {
                return true;
            }

            foreach (var d in dir)
            {
                int newRow = curr.row + d[0];
                int newCol = curr.col + d[1];

                if (IsValidCell(grid, newRow, newCol) &&
                    !visited[newRow, newCol] &&
                    grid[newRow][newCol] >= minSafeness)
                {
                    visited[newRow, newCol] = true;
                    traversalQueue.Enqueue((newRow, newCol));
                }
            }
        }

        return false;
    }
}