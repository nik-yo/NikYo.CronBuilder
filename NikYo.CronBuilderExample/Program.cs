// See https://aka.ms/new-console-template for more information
using NikYo.CronBuilder.Fields;

Console.WriteLine("Hello, World!");

var builder = new NikYo.CronBuilder.Builder();

// Standard (minute granularity)
var cronExp = builder
                .AddMinute("*")
                .AddHour("*")
                .AddDayOfMonth("*")
                .AddMonth("*")
                .AddDayOfWeek("*").Build();

Console.WriteLine($"Standard: {cronExp}");

// Minute granularity
var cronMinuteExp = builder
                        .WithMinuteGranularity()
                        .AddMinute("*")
                        .AddHour("*")
                        .AddDayOfMonth("*")
                        .AddMonth("*")
                        .AddDayOfWeek("*").Build();

Console.WriteLine($"Minute granularity: {cronMinuteExp}");

// Second granularity
var cronSecondExp = builder
                        .WithSecondGranularity()
                        .AddSecond("*")
                        .AddMinute("*")
                        .AddHour("*")
                        .AddDayOfMonth("*")
                        .AddMonth("*")
                        .AddDayOfWeek("*").Build();

Console.WriteLine($"Second granularity: {cronSecondExp}");

// Second granularity with year
var cronSecondYearExp = builder
                        .WithSecondGranularity()
                        .AddSecond("*")
                        .AddMinute("*")
                        .AddHour("*")
                        .AddDayOfMonth("*")
                        .AddMonth("*")
                        .AddDayOfWeek("*")
                        .AddYear("*")
                        .Build();

Console.WriteLine($"Second granularity with year: {cronSecondYearExp}");

// Daily
Console.WriteLine($"Daily: {builder.Daily()}");

// Daily at 3 AM
Console.WriteLine($"Daily at 3 AM: {builder.DailyAt(3)}");

// Hourly
Console.WriteLine($"Hourly: {builder.Hourly()}");

// Every 2 hours
Console.WriteLine($"Every 2 hours: {builder.HourEvery(2)}");

// Every 25 hours (out of range)
// TODO: It is nice to update the next field instead of throwing exception
try
{
    Console.WriteLine($"Every 25 hours: {builder.HourEvery(25)}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

// Every 5 minutes
Console.WriteLine($"Every 5 minutes: {builder.MinuteEvery(5)}");

// Field Value

var cronFieldValueExp = builder
                        .WithSecondGranularity()
                        .AddSecond(SecondFieldValue.Asterisk)
                        .AddMinute(MinuteFieldValue.Range(0, 10))
                        .AddHour(HourFieldValue.Fields(HourFieldValue.Hour(1), HourFieldValue.Range(2, 3)))
                        .AddDayOfMonth(DayOfMonthFieldValue.Any)
                        .AddMonth(MonthFieldValue.Range(MonthPart.January, MonthPart.March))
                        .AddDayOfWeek(DayOfWeekFieldValue.Monday)
                        .AddYear("*").Build();

Console.WriteLine($"Field Value: {cronFieldValueExp}");

Console.ReadKey();
