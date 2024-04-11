using Microsoft.Extensions.Options;
using Quartz;

namespace BackgroundTaskPoc.BackgroundTasks.Quartz;

public class QuartzBackgroundJobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        var jobKey = JobKey.Create(nameof(QuartzBackgroundJobImplementation));
        options
            .AddJob<QuartzBackgroundJobImplementation>(jobBuilder => jobBuilder.WithIdentity(jobKey))
            .AddTrigger(trigger => trigger
                    .ForJob(jobKey)
                     .WithSchedule(CronScheduleBuilder
                .DailyAtHourAndMinute(11, 02)
                .InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time"))));
        //.WithCronSchedule("0 43 7 ? * *")); // Cron expression for 10:20 AM in Israel's local time (UTC+3)
        //.WithCronSchedule("0 0 8 * * ?")); // Cron expression for 8:00 AM every day
        //.WithSimpleSchedule(schedule =>schedule.WithIntervalInSeconds(1).RepeatForever()));
        // .WithCronSchedule("0/1 * * * * ?")); // Cron expression for every second


    }
}


