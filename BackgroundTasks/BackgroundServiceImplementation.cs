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
            // Add your background task logic here
            _data.Data.Add($"The new data was added at {DateTime.Now.ToLongTimeString()}");

            // Adjust the delay as needed for your background task
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}