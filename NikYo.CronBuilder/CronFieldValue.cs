namespace NikYo.CronBuilder
{
    public abstract class CronFieldValue
    {
        protected string _value = "*";
        public string Value { get { return _value; } }
    }
}
