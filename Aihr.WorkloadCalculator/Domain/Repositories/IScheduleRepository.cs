using Aihr.WorkloadCalculator.Domain.Model;

namespace Aihr.WorkloadCalculator.Domain.Repositories
{
    /// <summary>
    /// Simple repository interface for persisting schedules to a data store.
    /// </summary>
    public interface IScheduleRepository
    {
        /// <summary>
        /// Store a new schedule.
        /// </summary>
        /// <param name="schedule"></param>
        void Add(Schedule schedule);

        /// <summary>
        /// Retrieve all previously stored schedules.
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Schedule> GetAll();
    }
}
