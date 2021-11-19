using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOTPAuthenticator
{
    public class TimeProvider
    {
        private static readonly DateTime EPOCH = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static Task<DateTime> GetCurrentTimeAsync()
        {
            return Task.FromResult(DateTime.UtcNow);
        }
        private static long GetTime()
        {
            var value = GetCurrentTimeAsync().Result;
            return (long)(value.ToUniversalTime() - EPOCH).TotalSeconds;
        }
        public static long GetTimeSlice(int offset = 0, int period = 30)
        {
            long timestamp = GetTime();
            return (timestamp / period) + (offset * period);
        }
    }
}
