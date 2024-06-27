using NikYo.CronBuilder.Fields;

namespace NikYo.CronBuilder.Granularity
{
    public class MinuteGranularity : CronGranularity
    {
        private MinuteGranularity() { }

        internal MinuteGranularity(Dictionary<string, string> cron) : base(cron)
        {
        }

        public Minute AddMinute(string minute)
        {
            _cron.AddOrUpdate(typeof(Minute).Name, minute);

            return new Minute(_cron);
        }
    }
}
