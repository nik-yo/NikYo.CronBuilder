using NikYo.CronBuilder.Granularity;

namespace NikYo.CronBuilder.Fields
{
    public class Second : CronField
    {
        private Second() { }

        internal Second(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public Minute AddMinute(string minute) => 
            new MinuteGranularity(_cron).AddMinute(minute);

        public Minute AddMinute(MinuteFieldValue fieldValue) =>
            AddMinute(fieldValue.Value);
    }

    public class SecondFieldValue : CronFieldValue
    {
        private const int MinValue = 0;
        private const int MaxValue = 59;

        private SecondFieldValue() { }
        private SecondFieldValue(string value) { _value = value; }

        private static bool IsValidValue(int value) => value < MinValue || value > MaxValue;

        public static SecondFieldValue Asterisk => new("*");

        public static SecondFieldValue Range(int from, int to)
        {
            if (IsValidValue(from))
            {
                throw new ArgumentOutOfRangeException($"\"from\" has to be between {MinValue} and {MaxValue}");
            }

            if (IsValidValue(to))
            {
                throw new ArgumentOutOfRangeException($"\"to\" has to be between {MinValue} and {MaxValue}");
            }

            return new SecondFieldValue($"{from}-{to}");
        }

        public static SecondFieldValue Second(int second)
        {
            if (IsValidValue(second))
            {
                throw new ArgumentOutOfRangeException($"Second has to be between {MinValue} and {MaxValue}");
            }

            return new SecondFieldValue(second.ToString());
        }

        public static SecondFieldValue Fields(params SecondFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));
    }
}
