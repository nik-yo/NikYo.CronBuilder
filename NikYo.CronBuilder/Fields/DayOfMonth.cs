namespace NikYo.CronBuilder.Fields
{
    public class DayOfMonth : CronField
    {
        private DayOfMonth() { }

        internal DayOfMonth(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public Month AddMonth(string month)
        {
            _cron.AddOrUpdate(typeof(Month).Name, month);

            return new Month(_cron);
        }

        public Month AddMonth(MonthFieldValue fieldValue) => AddMonth(fieldValue.Value);
    }

    public class DayOfMonthFieldValue : CronFieldValue
    {
        private const int MinValue = 1;
        private const int MaxValue = 31;

        private DayOfMonthFieldValue() { }
        private DayOfMonthFieldValue(string value) { _value = value; }
        private static bool IsValidValue(int value) => value < MinValue || value > MaxValue;

        public static DayOfMonthFieldValue Asterisk => new("*");
        /// <summary>
        /// Represents "?"
        /// </summary>
        public static DayOfMonthFieldValue Any => new("?");
        public static DayOfMonthFieldValue Range(int from, int to)
        {
            if (IsValidValue(from))
            {
                throw new ArgumentOutOfRangeException($"\"from\" has to be between {MinValue} and {MaxValue}");
            }

            if (IsValidValue(to))
            {
                throw new ArgumentOutOfRangeException($"\"to\" has to be between {MinValue} and {MaxValue}");
            }

            return new DayOfMonthFieldValue($"{from}-{to}");
        }

        public static DayOfMonthFieldValue DayOfMonth(int dayOfMonth)
        {
            if (IsValidValue(dayOfMonth))
            {
                throw new ArgumentOutOfRangeException($"Day of month has to be between {MinValue} and {MaxValue}");
            }

            return new DayOfMonthFieldValue(dayOfMonth.ToString());
        }

        public static DayOfMonthFieldValue Fields(params DayOfMonthFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));
    }
}
