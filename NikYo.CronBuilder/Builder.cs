using NikYo.CronBuilder.Fields;
using NikYo.CronBuilder.Granularity;

namespace NikYo.CronBuilder
{
    public class Builder
    {
        private const int HOUR_MIN = 0;
        private const int HOUR_MAX = 23;
        private const int MINUTE_MIN = 0;
        private const int MINUTE_MAX = 59;

        private readonly Dictionary<string, string> _cron = [];

        public Builder Clear()
        {
            _cron.Clear();
            return this;
        }

        public Minute AddMinute(string minute)
        {
            return WithMinuteGranularity().AddMinute(minute);
        }

        public MinuteGranularity WithMinuteGranularity()
        {
            _cron.Clear();
            return new MinuteGranularity(_cron);
        }

        public SecondGranularity WithSecondGranularity()
        {
            _cron.Clear();
            return new SecondGranularity(_cron);
        }

        /* Pre-built expressions */

        /// <summary>
        /// Run yearly at midnight of 1 January
        /// </summary>
        /// <returns>0 0 1 1 *</returns>
        public string Yearly()
        {
            return Clear()
                    .AddMinute("0")
                    .AddHour("0")
                    .AddDayOfMonth("1")
                    .AddMonth("1")
                    .AddDayOfWeek("*")
                    .Build();
        }

        /// <summary>
        /// Run monthly at midnight of the first day of the month
        /// </summary>
        /// <returns>0 0 1 * *</returns>
        public string Monthly()
        {
            return Clear()
                    .AddMinute("0")
                    .AddHour("0")
                    .AddDayOfMonth("1")
                    .AddMonth("*")
                    .AddDayOfWeek("*")
                    .Build();
        }

        /// <summary>
        /// Run weekly at midnight on Sunday
        /// </summary>
        /// <returns>0 0 * * 0</returns>
        public string Weekly()
        {
            return Clear()
                    .AddMinute("0")
                    .AddHour("0")
                    .AddDayOfMonth("*")
                    .AddMonth("*")
                    .AddDayOfWeek("0")
                    .Build();
        }

        /// <summary>
        /// Run daily at midnight
        /// </summary>
        /// <returns>0 0 * * *</returns>
        public string Daily()
        {
            return Clear()
                    .AddMinute("0")
                    .AddHour("0")
                    .AddDayOfMonth("*")
                    .AddMonth("*")
                    .AddDayOfWeek("*")
                    .Build();
        }

        /// <summary>
        /// Run daily at {hour} hour
        /// </summary>
        /// <param name="hour">Hour to run. Value: 0-23 (inclusive)</param>
        /// <returns>0 {hour} * * *</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string DailyAt(int hour)
        {
            if (hour < HOUR_MIN || hour > HOUR_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), $"Hour has to be between {HOUR_MIN}-{HOUR_MAX} (inclusive)");
            }

            return Clear()
                    .AddMinute("0")
                    .AddHour($"{hour}")
                    .AddDayOfMonth("*")
                    .AddMonth("*")
                    .AddDayOfWeek("*")
                    .Build();
        }

        /// <summary>
        /// Run hourly
        /// </summary>
        /// <returns>0 * * * *</returns>
        public string Hourly()
        {
            return Clear()
                    .AddMinute("0")
                    .AddHour("*")
                    .AddDayOfMonth("*")
                    .AddMonth("*")
                    .AddDayOfWeek("*")
                    .Build();
        }

        /// <summary>
        /// Run every {hourInterval} hour(s)
        /// </summary>
        /// <param name="hourInterval">Hour between runs. Value: 0-23 (inclusive)</param>
        /// <returns>0 */{hourInterval} * * *</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public string HourEvery(int hourInterval)
        {
            if (hourInterval < HOUR_MIN || hourInterval > HOUR_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(hourInterval), $"Hour interval has to be between {HOUR_MIN}-{HOUR_MAX} (inclusive)");
            }

            return Clear()
                    .AddMinute("0")
                    .AddHour($"*/{hourInterval}")
                    .AddDayOfMonth("*")
                    .AddMonth("*")
                    .AddDayOfWeek("*")
                    .Build();
        }

        /// <summary>
        /// Run every {minuteInterval} minute(s)
        /// </summary>
        /// <param name="minuteInterval">Minutes between runs. Value: 0-59 (inclusive)</param>
        /// <returns>*/{minuteInterval} * * * *</returns>
        public string MinuteEvery(int minuteInterval)
        {
            if (minuteInterval < MINUTE_MIN || minuteInterval > MINUTE_MAX)
            {
                throw new ArgumentOutOfRangeException(nameof(minuteInterval), $"Minute interval has to be between {MINUTE_MIN}-{MINUTE_MAX} (inclusive)");
            }

            return Clear()
                    .AddMinute($"*/{minuteInterval}")
                    .AddHour("*")
                    .AddDayOfMonth("*")
                    .AddMonth("*")
                    .AddDayOfWeek("*")
                    .Build();
        }
    }
}
