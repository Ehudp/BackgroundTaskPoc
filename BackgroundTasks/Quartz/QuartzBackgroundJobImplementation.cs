using BackgroundTaskPoc.Data;
using Quartz;

namespace BackgroundTaskPoc.BackgroundTasks.Quartz;

[DisallowConcurrentExecution]
public class QuartzBackgroundJobImplementation : IJob
{
    private readonly QuartzBackgroundJobSampleData _data;

    public QuartzBackgroundJobImplementation(QuartzBackgroundJobSampleData data)
    {
        _data = data;
    }

    public Task Execute(IJobExecutionContext context)
    {
        _data.Data.Add($"Quartz Data, data was added at {DateTime.Now.ToLongTimeString()}");
        return Task.CompletedTask;
    }
}
