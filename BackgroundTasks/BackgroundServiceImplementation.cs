using BackgroundTaskPoc.Data;

namespace BackgroundTaskPoc.BackgroundTasks;

public class BackgroundServiceImplementation : BackgroundService
{
    private readonly BackgroundServiceSampleData _data;

    public BackgroundServiceImplementation(BackgroundServiceSampleData data)
    {
        _data = data;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _data.Data.Add($"Background Service Data, data was added at {DateTime.Now.ToLongTimeString()}");

            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}