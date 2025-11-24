using AoCHelper;

namespace AOC.Solutions
{
    internal static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("ADVENT OF CODE 2025");
            Console.WriteLine("Enter day number (a for all | q to quit):");
            var dayInput = Console.ReadLine();

            while (dayInput != "q")
            {
                if (string.IsNullOrWhiteSpace(dayInput))
                {
                    await Solver.SolveLast(opt =>
                    {
                        opt.ClearConsole = false;
                        opt.ShowTotalElapsedTimePerDay = false;
                        opt.ShowOverallResults = false;
                    });
                }
                else if (uint.TryParse(dayInput, out var day))
                {
                    await Solver.Solve([day], opt =>
                    {
                        opt.ClearConsole = false;
                        opt.ShowTotalElapsedTimePerDay = false;
                        opt.ShowOverallResults = false;
                    });
                }
                else if (dayInput == "a")
                {
                    await Solver.SolveAll(opt =>
                    {
                        opt.ClearConsole = false;
                        opt.ShowTotalElapsedTimePerDay = false;
                        opt.ShowOverallResults = true;
                    });
                }

                Console.WriteLine("Enter day number (a for all | q to quit):");
                dayInput = Console.ReadLine();
            }
        }
    }
}