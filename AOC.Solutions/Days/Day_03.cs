namespace AOC.Solutions.Days
{
    public class Day_03 : MyBaseDay
    {
        public override ValueTask<string> Solve_1() => new($"{Solve(2)}");
        public override ValueTask<string> Solve_2() => new($"{Solve(12)}");

        private long Solve(int batteryCount)
        {
            return InputLines.Sum(x => TurnOnBatteries(x, batteryCount));
        }

        private static long TurnOnBatteries(string bank, int batteryCount)
        {
            var result = "";

            for (var i = 1; i <= batteryCount; i++)
            {
                var max = bank[..^(batteryCount - i)].Max();
                result += max;
                bank = bank[(bank.IndexOf(max) + 1)..];
            }

            return long.Parse(result);
        }
    }
}