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
            .AddTrigger(trigger =>
                trigger
                    .ForJob(jobKey)
                                        //.WithSimpleSchedule(schedule =>schedule.WithIntervalInSeconds(1).RepeatForever()));
                                        .WithCronSchedule("0/1 * * * * ?")); // Cron expression for every second

    }
}


