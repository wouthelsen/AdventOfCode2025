using AOC.Solutions.Days;
using AoCHelper;
using NUnit.Framework;

namespace AOC.Tests
{
    public static class SolutionTests
    {
        [TestCase(typeof(Day_01), "0", "/")]

        public static async Task Test(Type type, string sol1, string sol2)
        {
            if (Activator.CreateInstance(type) is BaseDay instance)
            {
                await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));
                await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
            }
            else
            {
                Assert.Fail($"{type} is not a BaseDay");
            }
        }
    }
}