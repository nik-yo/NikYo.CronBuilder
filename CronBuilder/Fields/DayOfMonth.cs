namespace CronBuilder.Fields
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
    }
}
