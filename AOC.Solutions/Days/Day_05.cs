namespace AOC.Solutions.Days
{
    public class Day_05 : MyBaseDay
    {
        private List<(long min, long max)> mergedRanges;

        public override ValueTask<string> Solve_1() => new($"{Solve()}");
        public override ValueTask<string> Solve_2() => new($"{Solve(true)}");

        private long Solve(bool allFreshIds = false)
        {
            var ranges = InputLines.TakeWhile(x => x != string.Empty).Select(x => (long.Parse(x.Split('-')[0]), long.Parse(x.Split('-')[1]))).ToList();
            var ids = InputLines.TakeLast(InputLines.Length - ranges.Count - 1).Select(long.Parse).ToList();

            mergedRanges = MergeRanges(ranges);

            return allFreshIds ? mergedRanges.Sum(x => x.max - x.min + 1) : ids.Count(IsInAnyRange);
        }

        private bool IsInAnyRange(long id) => mergedRanges.Any(x => id >= x.min && id <= x.max);

        private static List<(long min, long max)> MergeRanges(List<(long min, long max)> ranges)
        {
            var result = new List<(long min, long max)>();
            ranges.Sort((a, b) => a.min.CompareTo(b.min) != 0 ? a.min.CompareTo(b.min) : a.max.CompareTo(b.max));

            var lastRange = ranges.FirstOrDefault();

            foreach (var range in ranges.Skip(1))
            {
                if (range.min > lastRange.max + 1)
                {
                    result.Add(lastRange);
                    lastRange = range;
                }
                else if (range.max > lastRange.max)
                {
                    lastRange = new(lastRange.min, range.max);
                }
            }

            result.Add(lastRange);

            return result;
        }
    }
}