using BackgroundTaskPoc.Data;

namespace BackgroundTaskPoc.BackgroundTasks.Hangfire;

public class HangfireBackgroundJobImplementation : IHangfireBackgroundJob
{
    private readonly HangfireBackgroundJobSampleData _data;

    public HangfireBackgroundJobImplementation(HangfireBackgroundJobSampleData data)
    {
        _data = data;
    }

    public Task ExecuteAsync()
    {
        _data.Data.Add($"Hangfiree Data, data was added at {DateTime.Now.ToLongTimeString()}");
        return Task.CompletedTask;
    }
}