using System;
using System.Collections.Generic;
using System.Text;

namespace Featurify.Business.Mapper
{
    public static class TrackLenghtFormater
    {
        public static string LenghtFormater(int ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);
            string formatedLenght = ms < 3600000 && ms > 0
                ? string.Format($"{t.Minutes:D2}:{t.Seconds:D2}")
                : string.Format($"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}");
            return formatedLenght;
        }
    }
}
