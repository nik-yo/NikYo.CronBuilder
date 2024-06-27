namespace CronBuilder.Fields
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
    }
}
