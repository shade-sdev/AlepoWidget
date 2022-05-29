using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlepoWSRC
{
    static class Constants
    {
        public readonly static string AUTH_URL = "https://internetaccount.myt.mu/portal-api/auth/login";
        public readonly static string USER_DATA_URL = "https://internetaccount.myt.mu/rest-services/selfcare/subscriber/S03086/bankInstanceList";
        public readonly static string USER_IDENTIFIER_URL = "https://internetaccount.myt.mu/rest-services/selfcare/subscriber/S03086/getSubscriptionIdentifier";
        public readonly static string USERNAME = ResourceHelper.ReadResource("username");
        public readonly static string PASSWORD = ResourceHelper.ReadResource("password");
    }
}
