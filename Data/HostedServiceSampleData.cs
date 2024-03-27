using System.Collections.Concurrent;

namespace BackgroundTaskPoc.Data;

public class HostedServiceSampleData
{
    public ConcurrentBag<string> Data { get; set; } = new();
}
