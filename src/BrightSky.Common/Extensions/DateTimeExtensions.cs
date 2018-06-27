using System;

namespace BrightSky.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBetween(this DateTime dt, DateTime start, DateTime end)
        {
            return dt.Ticks >= start.Ticks && dt.Ticks <= end.Ticks;
        }

        public static bool IsWeekDay(this DateTime dt)
        {
            return dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday;
        }

        public static bool IsWeekend(this DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
        }

        public static DateTime NextWeekday(this DateTime dt)
        {
            var next = dt;
            while (!next.IsWeekDay()) next = next.AddDays(1);

            return next;
        }

        public static DateTime Next(this DateTime dt, DayOfWeek day)
        {
            var offset = day - dt.DayOfWeek;
            if (offset <= 0) offset += 7;

            return dt.AddDays(offset);
        }

        public static string ToReadableTime(this DateTime dt)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - dt.Ticks);
            var delta = ts.TotalSeconds;

            if (delta < 60) return ts.Seconds == 1 ? "one second ago" : $"{ts.Seconds} seconds ago";
            if (delta < 120) return "a minute ago";
            if (delta < 2700) return $"{ts.Minutes} minutes ago";
            if (delta < 5400) return "an hour ago";
            if (delta < 86400) return $"{ts.Hours} hours ago";
            if (delta < 172800) return "yesterday";
            if (delta < 2592000) return $"{ts.Days} days ago";

            if (delta < 31104000)
            {
                var months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : $"{months} months ago";
            }

            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));

            return years <= 1 ? "one year ago" : $"{years} years ago";
        }
    }
}