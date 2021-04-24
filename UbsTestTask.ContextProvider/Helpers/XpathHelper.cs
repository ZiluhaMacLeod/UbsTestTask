using System.Linq;

namespace UbsTestTask.Core.Helpers
{
    public class XpathHelper
    {
        public static string CombineFewTextPartsInOneWithOr(params string[] partsWithText)
        {
            string textParts = string.Empty;
            foreach (var partWithText in partsWithText)
            {
                textParts += $"text()='{partWithText}'";
                if (partWithText != partsWithText.Last())
                {
                    textParts += " or ";
                }
            }

            return textParts;
        }
    }
}
