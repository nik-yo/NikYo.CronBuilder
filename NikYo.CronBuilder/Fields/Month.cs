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
    }
}
