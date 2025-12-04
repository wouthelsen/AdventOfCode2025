namespace AOC.Solutions.Days
{
    public class Day_01 : MyBaseDay
    {
        private int position;

        public override ValueTask<string> Solve_1() => new($"{Solve()}");
        public override ValueTask<string> Solve_2() => new($"{Solve(true)}");

        private int Solve(bool allZeroes = false)
        {
            position = 50;

            return InputLines.Sum(x => ZeroHits(x, allZeroes));
        }

        private int ZeroHits(string line, bool allZeroes)
        {
            var result = 0;
            var direction = line[0] == 'L' ? -1 : 1;
            var distance = int.Parse(line[1..]);

            for (var i = 0; i < distance; i++)
            {
                position += direction;
                if ((allZeroes || i == distance - 1) && position % 100 == 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}