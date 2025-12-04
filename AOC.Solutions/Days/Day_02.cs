namespace AOC.Solutions.Days
{
    public class Day_02 : MyBaseDay
    {
        public override ValueTask<string> Solve_1() => new($"{Solve()}");
        public override ValueTask<string> Solve_2() => new($"{Solve(true)}");

        private long Solve(bool allRepetitions = false)
        {
            var ranges = InputLines.SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToList();

            return ranges.Sum(x => CountInvalidIds(x, allRepetitions)); ;
        }

        private static long CountInvalidIds(string range, bool allRepetitions)
        {
            var result = 0L;
            var start = long.Parse(range.Split('-')[0]);
            var end = long.Parse(range.Split('-')[1]);

            for (var i = start; i <= end; i++)
            {
                var id = i.ToString();
                foreach (var repetitionCount in Enumerable.Range(2, allRepetitions ? id.Length - 1 : 1))
                {
                    if (id.Length % repetitionCount != 0)
                    {
                        continue;
                    }

                    var idParts = id.Chunk(id.Length / repetitionCount).Select(x => new string(x)).ToList();
                    if (idParts.Distinct().Count() == 1)
                    {
                        result += i;
                        break;
                    }
                }
            }

            return result;
        }
    }
}