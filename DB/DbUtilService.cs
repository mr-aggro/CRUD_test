using CRUD.DB;
using Microsoft.EntityFrameworkCore;

internal class DbUtilService: IHostedService
{
    private readonly IServiceScopeFactory scopeFactory;
    private readonly ILogger<DbUtilService> _logger;

    public DbUtilService(ILogger<DbUtilService> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        this.scopeFactory = scopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
                "DbUtilService StartAsync;");
        using (var scope = scopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            _logger.LogInformation(
                "DbUtilService db.Database.EnsureCreated();");
            db.Database.EnsureCreated();
            _logger.LogInformation(
                "DbUtilService db.Database.Migrate();");
            db.Database.Migrate();
        }
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
                "DbUtilService StopAsync;");
        return Task.CompletedTask;
    }
}