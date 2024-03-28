using BackgroundTaskPoc.Data;

namespace BackgroundTaskPoc.BackgroundTasks.SimpleTask;

public class HostedServiceImplementation : IHostedService, IDisposable
{
    private Timer? _timer;
    private readonly HostedServiceSampleData _data;

    public HostedServiceImplementation(HostedServiceSampleData data)
    {
        _data = data;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(AddToCache, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

        return Task.CompletedTask;
    }

    private void AddToCache(object? state)
    {
        _data.Data.Add($"Hosted Service Data, data was added at {DateTime.Now.ToLongTimeString()}");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
