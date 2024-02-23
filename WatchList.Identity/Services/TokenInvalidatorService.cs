﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WatchList.Identity.Services.Interfaces;

namespace WatchList.Identity.Services
{
    public class TokenInvalidatorService: BackgroundService
    {
        private readonly ILogger<TokenInvalidatorService> _logger;

        public TokenInvalidatorService(IServiceProvider services,
            ILogger<TokenInvalidatorService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Token Invalidator Service Hosted Service running.");

            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Token Invalidator Service Hosted Service is working.");

            using var scope = Services.CreateScope();
            var scopedProcessingService =
                scope.ServiceProvider
                    .GetRequiredService<ITokenService>();
            
            await scopedProcessingService.ClearExpiredTokens(stoppingToken);
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "Token Invalidator Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}
