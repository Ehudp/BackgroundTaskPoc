using BackgroundTaskPoc.BackgroundTasks.Hangfire;
using BackgroundTaskPoc.BackgroundTasks.Quartz;
using BackgroundTaskPoc.BackgroundTasks.SimpleTask;
using BackgroundTaskPoc.Data;
using Hangfire;
using Hangfire.MemoryStorage;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add HostedService
builder.Services.AddSingleton<HostedServiceSampleData>();
builder.Services.AddHostedService<HostedServiceImplementation>();

// Add ackgroundService
builder.Services.AddSingleton<BackgroundServiceSampleData>();
builder.Services.AddHostedService<BackgroundServiceImplementation>();

// Add Quartz
builder.Services.AddSingleton<QuartzBackgroundJobSampleData>();
builder.Services.AddQuartz(options =>
      {
          options.UseMicrosoftDependencyInjectionJobFactory();
      });

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

builder.Services.ConfigureOptions<QuartzBackgroundJobSetup>();

// Add Hangfire
builder.Services.AddSingleton<HangfireBackgroundJobSampleData>();

builder.Services.AddHangfire(configuration =>
       {
           configuration.UseMemoryStorage();
       });


builder.Services.AddSingleton<IHangfireBackgroundJob, HangfireBackgroundJobImplementation>();

builder.Services.AddHangfireServer();

var app = builder.Build();

var serviceProvider = app.Services;
IRecurringJobManager recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();
recurringJobManager.AddOrUpdate<IHangfireBackgroundJob>("HangfireDataJob", job => job.ExecuteAsync(), "* * * * * *"); // Every 15 second this the minimum 




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
