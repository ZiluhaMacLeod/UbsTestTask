using System;
using UbsTestTask.Constants.Constants;

namespace UbsTestTask.Constants.UbsGlobal.WealthManagement.GetInTouch
{
    public class CountryOrRegionOptions
    {
        public static string Algeria
        {
            get
            {
                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.English)
                {
                    return "Algeria";
                }

                if (TestSettings.UbsGlobalLanguage == UbsGlobalMainPageLanguages.Deutsch)
                {
                    return "Algerien";
                }

                throw new ArgumentException($"{TestSettings.UbsGlobalLanguage} language is not supported");
            }
        }
    }
}
