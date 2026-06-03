using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Generate permutations of length 'size' from 'letters'.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: word is complete
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try each unused letter
        foreach (char c in letters)
        {
            if (!word.Contains(c))
            {
                PermutationsChoose(results, letters, size, word + c);
            }
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs using memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Check memo
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive formula
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Expand wildcard binary patterns.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // No wildcard left → full binary string
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace * with 0
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);

        // Replace * with 1
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Solve maze recursively and record all valid paths.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Add current position
        currPath.Add((x, y));

        // If at the end, record path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Possible moves
        var moves = new (int dx, int dy)[] { (1,0), (-1,0), (0,1), (0,-1) };

        foreach (var (dx, dy) in moves)
        {
            int nx = x + dx;
            int ny = y + dy;

            if (maze.IsValidMove(nx, ny, currPath))
            {
                SolveMaze(results, maze, nx, ny, currPath);
            }
        }

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
