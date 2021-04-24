using UbsTestTask.Pages.UbsGlobal.UbsLogins;
using UbsTestTask.Pages.UbsGlobal.WealthManagement;

namespace UbsTestTask.Pages.UbsGlobal
{
    public static class UbsGlobalGenericPages
    {
        public static MainPage MainPage => GetPage<MainPage>();
        public static YourLifeGoalsPage YourLifeGoalsPage => GetPage<YourLifeGoalsPage>();
        public static GetInTouchPage GetInTouchPage => GetPage<GetInTouchPage>();
        public static UbsEbankingSwitzerlandPage UbsEbankingSwitzerlandPage => GetPage<UbsEbankingSwitzerlandPage>();

        private static T GetPage<T>() where T : new() => new T();
    }
}
