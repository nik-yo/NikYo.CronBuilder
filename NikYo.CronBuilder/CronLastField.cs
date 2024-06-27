using NikYo.CronBuilder.Fields;
using DayOfWeek = NikYo.CronBuilder.Fields.DayOfWeek;

namespace NikYo.CronBuilder
{
    public abstract class CronLastField : CronField
    {
        public string Build()
        {
            var minute = _cron[typeof(Minute).Name];
            var hour = _cron[typeof(Hour).Name];
            var dayOfMonth = _cron[typeof(DayOfMonth).Name];
            var month = _cron[typeof(Month).Name];
            var dayOfWeek = _cron[typeof(DayOfWeek).Name];

            var cronExpression = $"{minute} {hour} {dayOfMonth} {month} {dayOfWeek}";

            var secondKey = typeof(Second).Name;
            if (_cron.ContainsKey(secondKey))
            {
                var second = _cron[secondKey];

                cronExpression = $"{second} {cronExpression}";
            }

            var yearKey = typeof(Year).Name;
            if (_cron.ContainsKey(yearKey))
            {
                var year = _cron[yearKey];

                cronExpression = $"{cronExpression} {year}";
            }

            return cronExpression;
        }
    }
}
