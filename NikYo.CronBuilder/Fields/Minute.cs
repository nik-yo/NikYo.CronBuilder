namespace NikYo.CronBuilder.Fields
{
    public class Minute : CronField
    {
        private Minute() { }

        internal Minute(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public Hour AddHour(string hour)
        {
            _cron.AddOrUpdate(typeof(Hour).Name, hour);

            return new Hour(_cron);
        }

        public Hour AddHour(HourFieldValue fieldValue) =>
            AddHour(fieldValue.Value);
    }

    public class MinuteFieldValue : CronFieldValue
    {
        private const int MinValue = 0;
        private const int MaxValue = 59;

        private MinuteFieldValue() { }
        private MinuteFieldValue(string value) { _value = value; }

        private static bool IsValidValue(int value) => value < MinValue || value > MaxValue;

        public static MinuteFieldValue Asterisk => new("*");

        public static MinuteFieldValue Range(int from, int to)
        {
            if (IsValidValue(from))
            {
                throw new ArgumentOutOfRangeException($"\"from\" has to be between {MinValue} and {MaxValue}");
            }

            if (IsValidValue(to))
            {
                throw new ArgumentOutOfRangeException($"\"to\" has to be between {MinValue} and {MaxValue}");
            }

            return new MinuteFieldValue($"{from}-{to}");
        }

        public static MinuteFieldValue Fields(params MinuteFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));
    }
}
