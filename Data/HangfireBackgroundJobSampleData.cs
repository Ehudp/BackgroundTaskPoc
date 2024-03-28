using System.Collections.Concurrent;

namespace BackgroundTaskPoc.Data;

public class HangfireBackgroundJobSampleData
{
    public ConcurrentBag<string> Data { get; set; } = new();
}
