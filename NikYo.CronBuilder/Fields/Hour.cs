namespace NikYo.CronBuilder.Fields
{
    public class Hour : CronField
    {
        private Hour() { }

        internal Hour(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public DayOfMonth AddDayOfMonth(string dayOfMonth)
        {
            _cron.AddOrUpdate(typeof(DayOfMonth).Name, dayOfMonth);

            return new DayOfMonth(_cron);
        }
        
        public DayOfMonth AddDayOfMonth(DayOfMonthFieldValue fieldValue) =>
            AddDayOfMonth(fieldValue.Value);
    }

    public class HourFieldValue : CronFieldValue
    {
        private const int MinValue = 0;
        private const int MaxValue = 23;

        private HourFieldValue() { }
        private HourFieldValue(string value) { _value = value; }
        private static bool IsValidValue(int value) => value < MinValue || value > MaxValue;

        public static HourFieldValue Asterisk => new("*");

        public static HourFieldValue Range(int from, int to)
        {
            if (IsValidValue(from))
            {
                throw new ArgumentOutOfRangeException($"\"from\" has to be between {MinValue} and {MaxValue}");
            }

            if (IsValidValue(to))
            {
                throw new ArgumentOutOfRangeException($"\"to\" has to be between {MinValue} and {MaxValue}");
            }

            return new HourFieldValue($"{from}-{to}");
        }

        public static HourFieldValue Hour(int hour)
        {
            if (IsValidValue(hour))
            {
                throw new ArgumentOutOfRangeException($"Hour has to be between {MinValue} and {MaxValue}");
            }

            return new HourFieldValue(hour.ToString());
        }

        public static HourFieldValue Fields(params HourFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));
    }
}
