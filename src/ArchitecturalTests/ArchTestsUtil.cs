using NetArchTest.Rules;

namespace ArchitecturalTests
{
    internal static class ArchTestsUtils
    {
        public static string GetFailingTypes(TestResult result)
        {
            if (result.FailingTypes == null || result.FailingTypes.Count == 0)
            {
                return string.Empty;
            }

            return "\r\nFailing Types : \r\n" + result.FailingTypes.Select(c => c.Name).Aggregate((c1, c2) => c1 + "\r\n" + c2) + "\r\n";
        }
    }
}
