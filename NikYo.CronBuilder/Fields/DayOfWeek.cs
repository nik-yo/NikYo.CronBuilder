namespace NikYo.CronBuilder.Fields
{
    public class DayOfWeek : CronLastField
    {
        private DayOfWeek() { }

        internal DayOfWeek(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public Year AddYear(string year)
        {
            _cron.AddOrUpdate(typeof(Year).Name, year);

            return new Year(_cron);
        }

        public Year AddYear(YearFieldValue fieldValue) => AddYear(fieldValue.Value);
    }

    public class DayOfWeekFieldValue : CronFieldValue
    {
        private const int MinValue = 0;
        private const int MaxValue = 6;

        private DayOfWeekFieldValue() { }
        private DayOfWeekFieldValue(string value) { _value = value; }
        
        private static bool IsValidValue(int value) => value < MinValue || value > MaxValue;

        public static DayOfWeekFieldValue Asterisk => new("*");
        /// <summary>
        /// Represents "?"
        /// </summary>
        public static DayOfWeekFieldValue Any => new("?");
        public static DayOfWeekFieldValue Range(int from, int to)
        {
            if (IsValidValue(from))
            {
                throw new ArgumentOutOfRangeException($"\"from\" has to be between {MinValue} and {MaxValue}");
            }

            if (IsValidValue(to))
            {
                throw new ArgumentOutOfRangeException($"\"to\" has to be between {MinValue} and {MaxValue}");
            }

            return new DayOfWeekFieldValue($"{from}-{to}");
        }

        public static DayOfWeekFieldValue Range(DayOfWeekPart from, DayOfWeekPart to) =>
            new($"{from.ToShortString()}-{to.ToShortString()}");

        public static DayOfWeekFieldValue DayOfWeek(int dayOfWeek)
        {
            if (IsValidValue(dayOfWeek))
            {
                throw new ArgumentOutOfRangeException($"Day of week has to be between {MinValue} and {MaxValue}");
            }

            return new DayOfWeekFieldValue(dayOfWeek.ToString());
        }

        public static DayOfWeekFieldValue Fields(params DayOfWeekFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));

        public static DayOfWeekFieldValue DayOfWeek(DayOfWeekPart dayOfWeek) =>
            new(dayOfWeek.ToShortString());

        public static DayOfWeekFieldValue Sunday => DayOfWeek(DayOfWeekPart.Sunday);
        public static DayOfWeekFieldValue Monday => DayOfWeek(DayOfWeekPart.Monday);
        public static DayOfWeekFieldValue Tuesday => DayOfWeek(DayOfWeekPart.Tuesday);
        public static DayOfWeekFieldValue Wednesday => DayOfWeek(DayOfWeekPart.Wednesday);
        public static DayOfWeekFieldValue Thursday => DayOfWeek(DayOfWeekPart.Thursday);
        public static DayOfWeekFieldValue Friday => DayOfWeek(DayOfWeekPart.Friday);
        public static DayOfWeekFieldValue Saturday => DayOfWeek(DayOfWeekPart.Saturday);
    }
}

public enum DayOfWeekPart
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
}

public static class DayOfWeekPartExtension
{
    public static string ToShortString(this DayOfWeekPart dayOfWeek)
    {
        return dayOfWeek switch
        { 
            DayOfWeekPart.Sunday => "SUN",
            DayOfWeekPart.Monday => "MON",
            DayOfWeekPart.Tuesday => "TUE",
            DayOfWeekPart.Wednesday => "WED",
            DayOfWeekPart.Thursday => "THU",
            DayOfWeekPart.Friday => "FRI",
            DayOfWeekPart.Saturday => "SAT",
            _ => string.Empty
        };
    }
}