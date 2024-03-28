using System.Collections.Concurrent;

namespace BackgroundTaskPoc.Data;

public class QuartzBackgroundJobSampleData
{
    public ConcurrentBag<string> Data { get; set; } = new();
}
