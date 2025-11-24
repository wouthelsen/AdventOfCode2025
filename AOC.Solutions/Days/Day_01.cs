using AoCHelper;

namespace AOC.Solutions.Days
{
    public class Day_01 : BaseDay
    {
        public override async ValueTask<string> Solve_1() => new($"{await SolveAsync()}");
        public override async ValueTask<string> Solve_2() => new($"/");

        private async Task<int> SolveAsync()
        {
            return 0;
        }
    }
}