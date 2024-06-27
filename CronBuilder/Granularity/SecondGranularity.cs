using CronBuilder.Fields;

namespace CronBuilder.Granularity
{
    public class SecondGranularity : CronGranularity
    {
        private SecondGranularity() { }

        internal SecondGranularity(Dictionary<string, string> cron) : base(cron)
        {
        }

        public Second AddSecond(string second)
        {
            _cron.AddOrUpdate(typeof(Second).Name, second);

            return new Second(_cron);
        }
    }
}
