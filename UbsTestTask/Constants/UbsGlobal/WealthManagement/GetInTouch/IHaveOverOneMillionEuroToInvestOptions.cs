using System;
using UbsTestTask.Constants.Constants;

namespace UbsTestTask.Constants.UbsGlobal.WealthManagement.GetInTouch
{
    public class IHaveOverOneMillionEuroToInvestOptions
    {
        public static string Yes
        {
            get
            {
                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.English)
                {
                    return "Yes";
                }

                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.Deutsch)
                {
                    return "Ja";
                }

                throw new ArgumentException($"{TestSettings.UbsGlobalLanguage} language is not supported");
            }
        }

        public static string No
        {
            get
            {
                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.English)
                {
                    return "No";
                }

                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.Deutsch)
                {
                    return "Nein";
                }

                throw new ArgumentException($"{TestSettings.UbsGlobalLanguage} language is not supported");
            }
        }
    }
}
