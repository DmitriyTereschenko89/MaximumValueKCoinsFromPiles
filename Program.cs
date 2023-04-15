namespace MaximumValueKCoinsFromPiles
{
    internal class Program
    {
        public class MaximumValueKCoinsFromPiles
        {
            private int DFS(int i, int coins, IList<IList<int>> piles, int[,] dp)
            {
                if (i == piles.Count)
                {
                    return 0;
                }
                if (dp[i, coins] != -1)
                {
                    return dp[i, coins];
                }
                dp[i, coins] = DFS(i + 1, coins, piles, dp);
                int curPiles = 0;
                for(int j = 0; j < Math.Min(coins, piles[i].Count); ++j)
                {
                    curPiles += piles[i][j];
                    dp[i, coins] = Math.Max(dp[i, coins], curPiles + DFS(i + 1, coins - j - 1, piles, dp));
                }
                return dp[i, coins];
            }
            public int MaxValueOfCoins(IList<IList<int>> piles, int k)
            {
                int[,] dp = new int[piles.Count, k + 1];
                for(int i = 0; i < piles.Count; ++i)
                {
                    for(int j = 0; j <= k; ++j)
                    {
                        dp[i, j] = -1;
                    }
                }
                return DFS(0, k, piles, dp);
            }
        }

        static void Main(string[] args)
        {
            MaximumValueKCoinsFromPiles maximumValueKCoinsFrom = new();
            Console.WriteLine(maximumValueKCoinsFrom.MaxValueOfCoins(new int[][]
            {
                new int[] { 1, 100, 3 }, new int[] { 7, 8, 9 }
            }, 2));
            Console.WriteLine(maximumValueKCoinsFrom.MaxValueOfCoins(new int[][]
            {
                new int[] { 100 }, new int[] { 100 }, new int[] { 100 }, new int[] { 100 }, new int[] { 100 }, new int[] { 100 }, new int[] { 1, 1, 1, 1, 1, 1, 700 }
            }, 7));
        }
    }
}