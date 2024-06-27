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
    }
}
