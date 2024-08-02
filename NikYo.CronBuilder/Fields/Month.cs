namespace NikYo.CronBuilder.Fields
{
    public class Month : CronField
    {
        private Month() { }

        internal Month(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public DayOfWeek AddDayOfWeek(string dayOfWeek)
        {
            _cron.AddOrUpdate(typeof(DayOfWeek).Name, dayOfWeek);

            return new DayOfWeek(_cron);
        }

        public DayOfWeek AddDayOfWeek(DayOfWeekFieldValue fieldValue) =>
            AddDayOfWeek(fieldValue.Value);
    }

    public class MonthFieldValue : CronFieldValue
    {
        private const int MinValue = 1;
        private const int MaxValue = 12;

        private MonthFieldValue() { }
        private MonthFieldValue(string value) { _value = value; }

        private static bool IsValidValue(int value) => value < MinValue || value > MaxValue;

        public static MonthFieldValue Asterisk => new("*");

        public static MonthFieldValue Range(int from, int to)
        {
            if (IsValidValue(from))
            {
                throw new ArgumentOutOfRangeException($"\"from\" has to be between {MinValue} and {MaxValue}");
            }

            if (IsValidValue(to))
            {
                throw new ArgumentOutOfRangeException($"\"to\" has to be between {MinValue} and {MaxValue}");
            }

            return new MonthFieldValue($"{from}-{to}");
        }

        public static MonthFieldValue Range(MonthPart from, MonthPart to) =>
            new($"{from.ToShortString()}-{to.ToShortString()}");

        public static MonthFieldValue Month(int month)
        {
            if (IsValidValue(month))
            {
                throw new ArgumentOutOfRangeException($"Month has to be between {MinValue} and {MaxValue}");
            }

            return new MonthFieldValue(month.ToString());
        }

        public static MonthFieldValue Fields(params MonthFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));

        public static MonthFieldValue Month(MonthPart month) => 
            new(month.ToShortString());

        public static MonthFieldValue January => Month(MonthPart.January);
        public static MonthFieldValue February => Month(MonthPart.February);
        public static MonthFieldValue March => Month(MonthPart.March);
        public static MonthFieldValue April => Month(MonthPart.April);
        public static MonthFieldValue May => Month(MonthPart.May);
        public static MonthFieldValue June => Month(MonthPart.June);
        public static MonthFieldValue July => Month(MonthPart.July);
        public static MonthFieldValue August => Month(MonthPart.August);
        public static MonthFieldValue September => Month(MonthPart.September);
        public static MonthFieldValue October => Month(MonthPart.October);
        public static MonthFieldValue November => Month(MonthPart.November);
        public static MonthFieldValue December => Month(MonthPart.December);
    }
}

public enum MonthPart
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December,
}

public static class MonthPartExtension
{
    public static string ToShortString(this MonthPart month)
    {
        return month switch
        {
            MonthPart.January => "JAN",
            MonthPart.February => "FEB",
            MonthPart.March => "MAR",
            MonthPart.April => "APR",
            MonthPart.May => "MAY",
            MonthPart.June => "JUN",
            MonthPart.July => "JUL",
            MonthPart.August => "AUG",
            MonthPart.September => "SEP",
            MonthPart.October => "AUG",
            MonthPart.November => "NOV",
            MonthPart.December => "DEC",
            _ => string.Empty,
        };
    }
}