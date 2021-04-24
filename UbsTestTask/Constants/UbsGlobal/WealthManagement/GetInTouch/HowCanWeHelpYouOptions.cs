using System;
using UbsTestTask.Constants.Constants;

namespace UbsTestTask.Constants.UbsGlobal.WealthManagement.GetInTouch
{
    public class HowCanWeHelpYouOptions
    {
        public static string InternationalBanking
        {
            get
            {
                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.English)
                {
                    return "International Banking";
                }

                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.Deutsch)
                {
                    return "Internationales Banking";
                }

                throw new ArgumentException($"{TestSettings.UbsGlobalLanguage} language is not supported");
            }
        }
    }
}
