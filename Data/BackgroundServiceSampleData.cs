using System.Collections.Concurrent;

namespace BackgroundTaskPoc.Data;

public class BackgroundServiceSampleData
{
    public ConcurrentBag<string> Data { get; set; } = new();
}
