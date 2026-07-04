public class Solution
{
    public int MinScore(int n, int[][] roads)
    {
        // Create adjacency list
        List<(int city, int distance)>[] graph = new List<(int, int)>[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        // Build graph
        foreach (var road in roads)
        {
            int u = road[0];
            int v = road[1];
            int d = road[2];

            graph[u].Add((v, d));
            graph[v].Add((u, d));
        }

        bool[] visited = new bool[n + 1];
        int answer = int.MaxValue;

        DFS(1);

        return answer;

        void DFS(int node)
        {
            visited[node] = true;

            foreach (var next in graph[node])
            {
                // Keep track of the minimum edge
                answer = Math.Min(answer, next.distance);

                if (!visited[next.city])
                {
                    DFS(next.city);
                }
            }
        }
    }
}