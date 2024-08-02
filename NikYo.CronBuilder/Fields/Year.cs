namespace NikYo.CronBuilder.Fields
{
    public class Year : CronLastField
    {
        private Year() { }

        internal Year(Dictionary<string, string> cron)
        {
            _cron = cron;
        }
    }

    public class YearFieldValue : CronFieldValue
    {
        private YearFieldValue() { }
        private YearFieldValue(string value) { _value = value; }

        public static YearFieldValue Asterisk => new("*");

        public static YearFieldValue Range(int from, int to) => new($"{from}-{to}");

        public static YearFieldValue Year(int year) => new(year.ToString());
        public static YearFieldValue Fields(params YearFieldValue[] fields) =>
            new(string.Join(",", fields.Select(f => f.Value)));
    }
}
