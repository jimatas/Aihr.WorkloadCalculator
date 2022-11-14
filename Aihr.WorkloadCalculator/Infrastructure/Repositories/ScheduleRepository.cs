using Aihr.WorkloadCalculator.Domain.Model;
using Aihr.WorkloadCalculator.Domain.Repositories;

using Microsoft.Extensions.Caching.Memory;

namespace Aihr.WorkloadCalculator.Infrastructure.Repositories
{
    /// <summary>
    /// Default implementation of the <see cref="IScheduleRepository"/> interface that is backed by a local in-memory cache.
    /// </summary>
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly IMemoryCache memoryCache;

        public ScheduleRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        /// <inheritdoc/>
        public void Add(Schedule schedule)
        {
            var schedules = memoryCache.GetOrCreate(nameof(IScheduleRepository), e =>
            {
                e.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
                return new List<Schedule>();
            });

            schedules!.Add(schedule);
        }

        /// <inheritdoc/>
        public IReadOnlyList<Schedule> GetAll()
        {
            return memoryCache.TryGetValue(nameof(IScheduleRepository), out List<Schedule>? schedules) ? schedules! : Array.Empty<Schedule>();
        }
    }
}
