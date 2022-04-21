using Microsoft.Extensions.Hosting;
using DesafioKPMG.DataService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using DesafioKPMG.Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DesafioKPMG.DataService.IDataConfiguration;

namespace DesafioKPMG.DataService.DataCache
{
    public class ScopedBackgroundService : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ScopedBackgroundService(
            IConfiguration configuration,
            IServiceScopeFactory serviceScopeFactory
            )
        {
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await SaveChangesService();
                }
                finally
                {
                    var secondsDelay = Int32.Parse(_configuration
                        .GetSection("GameResultsSaveIntervalSeconds").Value);
                    await Task.Delay(1000 * secondsDelay, stoppingToken);
                }
            }
        }

        private async Task SaveChangesService()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _cache = scope.ServiceProvider.GetRequiredService<IUnitOfWorkCache>();
                var _unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                long cacheCount = _cache.GameResultsCache.GetCacheCount();
                if (cacheCount > 0)
                {
                    for (long i = 0; i < cacheCount; i++)
                    {
                        var gameResult = _cache.GameResultsCache.Get(i);

                        var player = await _unitOfWork.Players.GetById(gameResult.PlayerId);
                        if (player != null)
                        {
                            await _unitOfWork.GameResults.Add(gameResult);
                            player.Balance += gameResult.Win;
                            player.LastUpdateDate = gameResult.Timestamp;
                        }
                        _cache.GameResultsCache.Delete(i);
                    };
                    await _unitOfWork.CompleteAsync();
                };
                _cache.GameResultsCache.SetCacheCount(0);
            };
        }
    }
}
