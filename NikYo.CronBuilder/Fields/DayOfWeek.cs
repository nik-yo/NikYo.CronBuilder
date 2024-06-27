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
    }
}
