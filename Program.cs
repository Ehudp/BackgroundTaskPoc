using BackgroundTaskPoc;
using BackgroundTaskPoc.BackgroundTasks;
using BackgroundTaskPoc.Data;
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

var app = builder.Build();

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
