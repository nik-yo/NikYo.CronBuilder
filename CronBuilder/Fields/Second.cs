using CronBuilder.Granularity;

namespace CronBuilder.Fields
{
    public class Second : CronField
    {
        private Second() { }

        internal Second(Dictionary<string, string> cron)
        {
            _cron = cron;
        }

        public Minute AddMinute(string minute)
        {
            return new MinuteGranularity(_cron).AddMinute(minute);
        }
    }
}
