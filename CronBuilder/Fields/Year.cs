namespace CronBuilder.Fields
{
    public class Year : CronLastField
    {
        private Year() { }

        internal Year(Dictionary<string, string> cron)
        {
            _cron = cron;
        }
    }
}
