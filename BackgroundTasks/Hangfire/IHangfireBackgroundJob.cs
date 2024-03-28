namespace BackgroundTaskPoc.BackgroundTasks.Hangfire;

public interface IHangfireBackgroundJob
{
    Task ExecuteAsync();
}
