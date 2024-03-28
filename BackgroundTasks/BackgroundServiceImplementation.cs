using BackgroundTaskPoc.Data;

namespace BackgroundTaskPoc.BackgroundTasks;

public class BackgroundServiceImplementation : BackgroundService
{
    private readonly BackgroundServiceSampleData _data;
    private readonly TimeSpan _period = TimeSpan.FromSeconds(1);

    public BackgroundServiceImplementation(BackgroundServiceSampleData data)
    {
        _data = data;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(_period);
        while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
        {
            _data.Data.Add($"Background Service Data, data was added at {DateTime.Now.ToLongTimeString()}");

            // await Task.Delay(_period, stoppingToken);
        }
    }
}