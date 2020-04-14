using System;

namespace Maktoob.CrossCuttingConcerns.Settings
{
    public class JsonWebTokenSettings
    {

        public string Audience { get; set; }

        public TimeSpan Expires { get; set; }

        public string Issuer { get; set; }

        public string Key { get; set;  }
    }
}
