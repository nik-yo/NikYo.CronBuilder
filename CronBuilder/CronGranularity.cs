namespace CronBuilder
{
    public abstract class CronGranularity
    {
        protected Dictionary<string, string> _cron = null!;

        protected CronGranularity() { }

        protected CronGranularity(Dictionary<string, string> cron) 
        {
            _cron = cron;
        }
    }
}
