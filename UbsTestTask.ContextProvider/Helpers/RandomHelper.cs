using System;
using System.Linq;

namespace UbsTestTask.Core.Helpers
{
    public class RandomHelper
    {
        private const string WithoutSpacesPattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random Random = new Random();

        public static string GetRandomString(int length) =>
            new string(Enumerable.Repeat(WithoutSpacesPattern, length).Select(s => s[Random.Next(s.Length)]).ToArray());

        public static int GetRandomInt(int from = 0, int to = int.MaxValue) => new Random(DateTime.UtcNow.Millisecond).Next(from, to);

        public static string GetRandomEmail() => $"{GetRandomString(10)}@{GetRandomString(5)}.{GetRandomString(3)}";
    }
}
