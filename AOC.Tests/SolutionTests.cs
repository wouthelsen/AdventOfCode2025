using AOC.Solutions;
using AOC.Solutions.Days;
using NUnit.Framework;

namespace AOC.Tests
{
    public static class SolutionTests
    {
        [TestCase(typeof(Day_01), "3", "6")]
        [TestCase(typeof(Day_02), "1227775554", "4174379265")]
        [TestCase(typeof(Day_03), "357", "3121910778619")]
        [TestCase(typeof(Day_04), "13", "43")]
        [TestCase(typeof(Day_05), "3", "14")]
        public static async Task TestExample(Type type, string sol1, string sol2)
        {
            if (Activator.CreateInstance(type) is MyBaseDay instance)
            {
                instance.UseExample = true;

                await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));
                await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
            }
            else
            {
                Assert.Fail($"{type} is not a MyBaseDay");
            }
        }

        [TestCase(typeof(Day_01), "1172", "6932")]
        [TestCase(typeof(Day_02), "26255179562", "31680313976")]
        [TestCase(typeof(Day_03), "16927", "167384358365132")]
        [TestCase(typeof(Day_04), "1356", "8713")]
        [TestCase(typeof(Day_05), "701", "352340558684863")]
        public static async Task Test(Type type, string sol1, string sol2)
        {
            if (Activator.CreateInstance(type) is MyBaseDay instance)
            {
                await Assert.ThatAsync(async () => await instance.Solve_1(), Is.EqualTo(sol1));
                await Assert.ThatAsync(async () => await instance.Solve_2(), Is.EqualTo(sol2));
            }
            else
            {
                Assert.Fail($"{type} is not a MyBaseDay");
            }
        }
    }
}