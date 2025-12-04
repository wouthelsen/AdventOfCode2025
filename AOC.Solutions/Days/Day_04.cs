namespace AOC.Solutions.Days
{
    public class Day_04 : MyBaseDay
    {
        private char[][] grid;

        public override ValueTask<string> Solve_1() => new($"{Solve()}");
        public override ValueTask<string> Solve_2() => new($"{Solve(true)}");

        private int Solve(bool remove = false)
        {
            grid = InputLines.Select(x => x.ToCharArray()).ToArray();

            return ProcessGrid(remove);
        }

        private int ProcessGrid(bool remove)
        {
            var result = 0;
            var removals = new List<(int x, int y)>();

            do
            {
                removals.Clear();

                for (var i = 0; i < grid.Length; i++)
                {
                    for (var j = 0; j < grid[i].Length; j++)
                    {
                        var currentPosition = (i, j);
                        if (IsPaperRoll(currentPosition) && IsAccessable(currentPosition))
                        {
                            result++;

                            if (remove)
                            {
                                removals.Add(currentPosition);
                            }
                        }
                    }
                }

                removals.ForEach(RemovePaperRoll);

            } while (removals.Count > 0);

            return result;
        }

        private bool IsAccessable((int x, int y) position, int maxNeighbours = 4)
        {
            var count = 0;

            for (var i = position.x - 1; i <= position.x + 1; i++)
            {
                for (var j = position.y - 1; j <= position.y + 1; j++)
                {
                    var currentPosition = (i, j);
                    if (currentPosition != position && IsValidPosition(currentPosition) && IsPaperRoll(currentPosition))
                    {
                        count++;
                    }
                }
            }

            return count < maxNeighbours;
        }

        private bool IsValidPosition((int x, int y) position) => position.x >= 0 && position.x < grid.Length && position.y >= 0 && position.y < grid[position.x].Length;
        private bool IsPaperRoll((int x, int y) position) => grid[position.x][position.y] == '@';
        private void RemovePaperRoll((int x, int y) position) => grid[position.x][position.y] = '.';
    }
}