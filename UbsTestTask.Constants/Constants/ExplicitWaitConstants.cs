using System;

namespace UbsTestTask.Constants.Constants
{
    public class ExplicitWaitConstants
    {
        public static TimeSpan DefaultTimeout = TimeSpan.FromSeconds(TestSettings.DefaultTimeoutSeconds);
        public static TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(TestSettings.DefaultPollingIntervalMilliseconds);
    }
}
