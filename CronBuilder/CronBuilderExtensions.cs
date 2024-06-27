namespace CronBuilder
{
    internal static class CronBuilderExtensions
    {
        internal static Dictionary<string, string> AddOrUpdate(this Dictionary<string, string> cron, string key, string value)
        {
            if (cron.ContainsKey(key))
            {
                cron[key] = value;
            }
            else
            {
                cron.Add(key, value);
            }

            return cron;
        }
    }
}
