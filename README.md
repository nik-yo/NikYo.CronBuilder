# CronBuilder

A simple package to build cron expression.

## Version

0.0.1

## Installation

Run the following command in the Nuget Package Manager Console:

```
PM> Install-Package NikYo.CronBuilder
```

### Target Framework

.NET Standard 2.0

## Usage

```
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
    Console.WriteLine($"Every 25 hours: {builder.HourEvery(2)}");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

// Every 5 minutes
Console.WriteLine($"Every 5 minutes: {builder.MinuteEvery(5)}");
```

## Limitations

It doesn't come with expression validation at the moment, but I plan to add it in the future version.

## License

MIT License