using palmHillsapp.Classes;
using palmHillsapp.Interfaces;  

namespace palmHillsapp.Services
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly EmailBackgroundQueue _queue;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<EmailBackgroundService> _logger;

        public EmailBackgroundService(
            EmailBackgroundQueue queue,
            IServiceScopeFactory scopeFactory,
            ILogger<EmailBackgroundService> logger)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_queue.TryDequeue(out var req))
                {
                    try
                    {
                        using var scope = _scopeFactory.CreateScope();
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                        
                        await emailService.SendBookCallEmailAsync(req!);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed sending callback email; requeueing.");
                        _queue.Enqueue(req!);
                        await Task.Delay(5000, stoppingToken);
                    }
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}